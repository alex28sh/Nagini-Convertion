using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Microsoft.Dafny;

/// <summary>
/// Represents module X { ... }
/// </summary>
public class LiteralModuleDecl : ModuleDecl, ICanFormat {
  public readonly ModuleDefinition ModuleDef;

  [FilledInDuringResolution] public ModuleSignature DefaultExport;  // the default export set of the module.

  private ModuleSignature emptySignature;
  public override ModuleSignature AccessibleSignature(bool ignoreExports) {
    if (ignoreExports) {
      return Signature;
    }
    return this.AccessibleSignature();
  }
  public override ModuleSignature AccessibleSignature() {
    if (DefaultExport == null) {
      if (emptySignature == null) {
        emptySignature = new ModuleSignature();
      }
      return emptySignature;
    }
    return DefaultExport;
  }

  public override IEnumerable<Node> Children => new[] { ModuleDef };
  public override IEnumerable<Node> PreResolveChildren => Children;

  public LiteralModuleDecl(ModuleDefinition module, ModuleDefinition parent)
    : base(module.RangeToken, module.NameNode, parent, false, false) {
    ModuleDef = module;
    BodyStartTok = module.BodyStartTok;
    TokenWithTrailingDocString = module.TokenWithTrailingDocString;
  }

  public override object Dereference() { return ModuleDef; }
  public bool SetIndent(int indentBefore, TokenNewIndentCollector formatter) {
    var innerIndent = indentBefore + formatter.SpaceTab;
    var allTokens = ModuleDef.OwnedTokens.ToList();
    if (allTokens.Any()) {
      formatter.SetOpeningIndentedRegion(allTokens[0], indentBefore);
    }

    foreach (var token in allTokens) {
      switch (token.val) {
        case "abstract":
        case "module": {
            break;
          }
        case "{": {
            if (TokenNewIndentCollector.IsFollowedByNewline(token)) {
              formatter.SetOpeningIndentedRegion(token, indentBefore);
            } else {
              formatter.SetAlign(indentBefore, token, out innerIndent, out _);
            }

            break;
          }
        case "}": {
            formatter.SetClosingIndentedRegionAligned(token, innerIndent, indentBefore);
            break;
          }
      }
    }

    foreach (var decl2 in ModuleDef.TopLevelDecls) {
      formatter.SetDeclIndentation(decl2, innerIndent);
    }

    foreach (var decl2 in ModuleDef.PrefixNamedModules) {
      formatter.SetDeclIndentation(decl2.Item2, innerIndent);
    }

    return true;
  }

  public void Resolve(Resolver resolver, Program prog, int beforeModuleResolutionErrorCount) {
    // The declaration is a literal module, so it has members and such that we need
    // to resolve. First we do refinement transformation. Then we construct the signature
    // of the module. This is the public, externally visible signature. Then we add in
    // everything that the system defines, as well as any "import" (i.e. "opened" modules)
    // directives (currently not supported, but this is where we would do it.) This signature,
    // which is only used while resolving the members of the module is stored in the (basically)
    // global variable moduleInfo. Then the signatures of the module members are resolved, followed
    // by the bodies.
    var module = ModuleDef;

    var errorCount = resolver.reporter.ErrorCount;
    if (module.RefinementQId != null) {
      ModuleDecl md = resolver.ResolveModuleQualifiedId(module.RefinementQId.Root, module.RefinementQId, resolver.reporter);
      module.RefinementQId.Set(md); // If module is not found, md is null and an error message has been emitted
    }

    foreach (var rewriter in resolver.rewriters) {
      rewriter.PreResolve(module);
    }

    Signature = resolver.RegisterTopLevelDecls(module, true);
    Signature.Refines = resolver.refinementTransformer.RefinedSig;

    var sig = Signature;
    // set up environment
    var preResolveErrorCount = resolver.reporter.ErrorCount;

    resolver.ResolveModuleExport(this, sig);
    var good = module.Resolve(sig, resolver);

    if (good && resolver.reporter.ErrorCount == preResolveErrorCount) {
      // Check that the module export gives a self-contained view of the module.
      resolver.CheckModuleExportConsistency(prog, module);
    }

    var tempVis = new VisibilityScope();
    tempVis.Augment(sig.VisibilityScope);
    tempVis.Augment(resolver.systemNameInfo.VisibilityScope);
    Type.PushScope(tempVis);

    prog.ModuleSigs[module] = sig;

    foreach (var rewriter in resolver.rewriters) {
      if (!good || resolver.reporter.ErrorCount != preResolveErrorCount) {
        break;
      }

      rewriter.PostResolveIntermediate(module);
    }

    if (good && resolver.reporter.ErrorCount == errorCount) {
      module.SuccessfullyResolved = true;
    }

    Type.PopScope(tempVis);

    if (resolver.reporter.ErrorCount == errorCount && !module.IsAbstract) {
      // compilation should only proceed if everything is good, including the signature (which preResolveErrorCount does not include);
      CompilationCloner cloner = new CompilationCloner();
      var compileName = new Name(module.NameNode.RangeToken, module.GetCompileName(resolver.Options) + "_Compile");
      var nw = cloner.CloneModuleDefinition(module, module.EnclosingModule, compileName);
      var oldErrorsOnly = resolver.reporter.ErrorsOnly;
      resolver.reporter.ErrorsOnly = true; // turn off warning reporting for the clone
      // Next, compute the compile signature
      Contract.Assert(!resolver.useCompileSignatures);
      resolver.useCompileSignatures =
        true; // set Resolver-global flag to indicate that Signatures should be followed to their CompiledSignature
      Type.DisableScopes();
      var compileSig = resolver.RegisterTopLevelDecls(nw, true);
      compileSig.Refines = resolver.refinementTransformer.RefinedSig;
      sig.CompileSignature = compileSig;
      foreach (var exportDecl in sig.ExportSets.Values) {
        exportDecl.Signature.CompileSignature = cloner.CloneModuleSignature(exportDecl.Signature, compileSig);
      }
      // Now we're ready to resolve the cloned module definition, using the compile signature

      nw.Resolve(compileSig, resolver);

      foreach (var rewriter in resolver.rewriters) {
        rewriter.PostCompileCloneAndResolve(nw);
      }

      prog.CompileModules.Add(nw);
      resolver.useCompileSignatures = false; // reset the flag
      Type.EnableScopes();
      resolver.reporter.ErrorsOnly = oldErrorsOnly;
    }

    /* It's strange to stop here when _any_ module has had resolution errors.
     * Either stop here when _this_ module has had errors,
     * or completely stop module resolution after one of them has errors
     */
    if (resolver.reporter.ErrorCount != beforeModuleResolutionErrorCount) {
      return;
    }

    Type.PushScope(tempVis);
    resolver.ComputeIsRecursiveBit(module);
    resolver.FillInDecreasesClauses(module);

    foreach (var iter in module.TopLevelDecls.OfType<IteratorDecl>()) {
      resolver.reporter.Info(MessageSource.Resolver, iter.tok, Printer.IteratorClassToString(resolver.Reporter.Options, iter));
    }

    foreach (var rewriter in resolver.rewriters) {
      rewriter.PostDecreasesResolve(module);
    }

    resolver.FillInAdditionalInformation(module);
    resolver.CheckForFuelAdjustments(module);

    Type.PopScope(tempVis);
  }
}