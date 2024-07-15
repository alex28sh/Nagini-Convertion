// Dafny program the_program compiled into C#
// To recompile, you will need the libraries
//     System.Runtime.Numerics.dll System.Collections.Immutable.dll
// but the 'dotnet' tool in net6.0 should pick those up automatically.
// Optionally, you may want to include compiler switches like
//     /debug /nowarn:162,164,168,183,219,436,1717,1718

using System;
using System.Numerics;
using System.Collections;

namespace DafnyToRustCompilerCoverage.RASTCoverage {

  public partial class __default {
    public static void TestNoOptimize(RAST._IExpr e)
    {
    }
    public static RAST._IExpr ConversionNum(RAST._IType t, RAST._IExpr x)
    {
      return RAST.Expr.create_Call(RAST.Expr.create_MemberSelect(RAST.Expr.create_MemberSelect(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("dafny_runtime")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("truncate!")), Dafny.Sequence<RAST._IExpr>.FromElements(x, RAST.Expr.create_ExprFromType(t)));
    }
    public static RAST._IExpr DafnyIntLiteral(Dafny.ISequence<Dafny.Rune> s) {
      return RAST.Expr.create_Call(RAST.Expr.create_MemberSelect(RAST.__default.dafny__runtime, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("int!")), Dafny.Sequence<RAST._IExpr>.FromElements(RAST.Expr.create_LiteralInt(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("1"))));
    }
    public static void TestOptimizeToString()
    {
      RAST._IExpr _1016_x;
      _1016_x = RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"));
      RAST._IExpr _1017_y;
      _1017_y = RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("y"));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), RAST.Expr.create_Call(RAST.Expr.create_Select(_1016_x, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("clone")), Dafny.Sequence<RAST._IExpr>.FromElements()), DAST.Format.UnaryOpFormat.create_NoFormat())).Optimize(), RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), _1016_x, DAST.Format.UnaryOpFormat.create_NoFormat())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), RAST.Expr.create_Call(RAST.Expr.create_Select(_1016_x, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("clone")), Dafny.Sequence<RAST._IExpr>.FromElements(_1017_y)), DAST.Format.UnaryOpFormat.create_NoFormat()));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!"), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("=="), _1016_x, _1017_y, DAST.Format.BinaryOpFormat.create_NoFormat()), DAST.Format.UnaryOpFormat.create_CombineFormat())).Optimize(), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!="), _1016_x, _1017_y, DAST.Format.BinaryOpFormat.create_NoFormat())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!"), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<"), _1016_x, _1017_y, DAST.Format.BinaryOpFormat.create_NoFormat()), DAST.Format.UnaryOpFormat.create_CombineFormat())).Optimize(), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(">="), _1016_x, _1017_y, DAST.Format.BinaryOpFormat.create_NoFormat())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!"), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<"), _1016_x, _1017_y, DAST.Format.BinaryOpFormat.create_ReverseFormat()), DAST.Format.UnaryOpFormat.create_CombineFormat())).Optimize(), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<="), _1017_y, _1016_x, DAST.Format.BinaryOpFormat.create_NoFormat())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_I128(), DafnyToRustCompilerCoverage.RASTCoverage.__default.DafnyIntLiteral(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("1")))).Optimize(), RAST.Expr.create_LiteralInt(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("1"))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_I128(), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_StmtExpr(RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), _1017_y), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("return"))))).Optimize(), RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_Some(_1017_y)), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("return")))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_StmtExpr(RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("w"), _1017_y), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("return")))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(_1016_x);
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(_1016_x, _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_Match(_1016_x, Dafny.Sequence<RAST._IMatchCase>.FromElements()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_StructBuild(_1016_x, Dafny.Sequence<RAST._IAssignIdentifier>.FromElements()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_Tuple(Dafny.Sequence<RAST._IExpr>.FromElements()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), _1016_x, DAST.Format.UnaryOpFormat.create_NoFormat()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&&"), _1016_x, _1016_x, DAST.Format.BinaryOpFormat.create_NoFormat()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_TypeAscription(_1016_x, RAST.Type.create_I128()), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_LiteralInt(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("1")), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_LiteralString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("2"), true, false), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoOptimize(RAST.Expr.create_StmtExpr(RAST.Expr.create_LiteralString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("3"), false, true), _1016_x));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_StmtExpr(RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), _1017_y), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("return"))))).Optimize(), RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("z"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_Some(_1017_y)), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("return")))));
      Dafny.ISequence<RAST._IExpr> _1018_coverageExpression;
      _1018_coverageExpression = Dafny.Sequence<RAST._IExpr>.FromElements(RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Match(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<RAST._IMatchCase>.FromElements(RAST.MatchCase.create(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))))), RAST.Expr.create_StmtExpr(RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("panic!()")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("a"))), RAST.Expr.create_Block(RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"))), RAST.Expr.create_StructBuild(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("dummy")), Dafny.Sequence<RAST._IAssignIdentifier>.FromElements(RAST.AssignIdentifier.create(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("foo"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("bar"))))), RAST.Expr.create_StructBuild(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("dummy")), Dafny.Sequence<RAST._IAssignIdentifier>.FromElements(RAST.AssignIdentifier.create(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("foo"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("bar"))), RAST.AssignIdentifier.create(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("foo2"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("bar"))))), RAST.Expr.create_Tuple(Dafny.Sequence<RAST._IExpr>.FromElements(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")))), RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("-"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), DAST.Format.UnaryOpFormat.create_NoFormat()), RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("+"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("y")), DAST.Format.BinaryOpFormat.create_NoFormat()), RAST.Expr.create_TypeAscription(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Type.create_I128()), RAST.Expr.create_LiteralInt(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("322")), RAST.Expr.create_LiteralString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), true, false), RAST.Expr.create_LiteralString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), false, true), RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_DeclareVar(RAST.DeclareType.create_CONST(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), Std.Wrappers.Option<RAST._IType>.create_None(), Std.Wrappers.Option<RAST._IExpr>.create_Some(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")))), RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_IfExpr(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_Loop(Std.Wrappers.Option<RAST._IExpr>.create_Some(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_For(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_Labelled(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))), RAST.Expr.create_Break(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_None()), RAST.Expr.create_Break(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_Some(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("l"))), RAST.Expr.create_Continue(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_None()), RAST.Expr.create_Continue(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_Some(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("l"))), RAST.Expr.create_Return(Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_Return(Std.Wrappers.Option<RAST._IExpr>.create_Some(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")))), RAST.Expr.create_Call(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<RAST._IExpr>.FromElements()), RAST.Expr.create_Call(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<RAST._IExpr>.FromElements(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("y")))), RAST.Expr.create_CallType(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<RAST._IType>.FromElements(RAST.Type.create_I128(), RAST.Type.create_U32())), RAST.Expr.create_Select(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc")), RAST.Expr.create_MemberSelect(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc")));
      BigInteger _hi4 = new BigInteger((_1018_coverageExpression).Count);
      for (BigInteger _1019_i = BigInteger.Zero; _1019_i < _hi4; _1019_i++) {
        RAST._IExpr _1020_c;
        _1020_c = (_1018_coverageExpression).Select(_1019_i);
        RAST._IPrintingInfo _1021___v0;
        _1021___v0 = (_1020_c).printingInfo;
        RAST._IExpr _1022___v1;
        _1022___v1 = (_1020_c).Optimize();
        Dafny.IMap<RAST._IExpr,Dafny.ISequence<Dafny.Rune>> _1023___v2;
        _1023___v2 = Dafny.Map<RAST._IExpr, Dafny.ISequence<Dafny.Rune>>.FromElements(new Dafny.Pair<RAST._IExpr, Dafny.ISequence<Dafny.Rune>>(_1020_c, (_1020_c)._ToString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(""))));
        RAST._IExpr _1024___v3;
        _1024___v3 = (RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), _1020_c)).Optimize();
        RAST._IExpr _1025___v4;
        _1025___v4 = (RAST.Expr.create_StmtExpr(RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), Std.Wrappers.Option<RAST._IType>.create_Some(RAST.Type.create_I128()), Std.Wrappers.Option<RAST._IExpr>.create_None()), RAST.Expr.create_StmtExpr(RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), _1020_c), RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(""))))).Optimize();
        RAST._IExpr _1026___v5;
        _1026___v5 = (RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), _1020_c, DAST.Format.UnaryOpFormat.create_NoFormat())).Optimize();
        RAST._IExpr _1027___v6;
        _1027___v6 = (RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!"), _1020_c, DAST.Format.UnaryOpFormat.create_NoFormat())).Optimize();
        RAST._IExpr _1028___v7;
        _1028___v7 = (DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_U8(), _1020_c)).Optimize();
        RAST._IExpr _1029___v8;
        _1029___v8 = (DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_U8(), RAST.Expr.create_Call(_1020_c, Dafny.Sequence<RAST._IExpr>.FromElements()))).Optimize();
        RAST._IExpr _1030___v9;
        _1030___v9 = (DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_U8(), RAST.Expr.create_Call(RAST.Expr.create_MemberSelect(_1020_c, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("int!")), Dafny.Sequence<RAST._IExpr>.FromElements()))).Optimize();
        RAST._IExpr _1031___v10;
        _1031___v10 = (DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_U8(), RAST.Expr.create_Call(RAST.Expr.create_MemberSelect(RAST.Expr.create_MemberSelect(_1020_c, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("dafny_runtime")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("int!")), Dafny.Sequence<RAST._IExpr>.FromElements()))).Optimize();
        RAST._IExpr _1032___v11;
        _1032___v11 = (DafnyToRustCompilerCoverage.RASTCoverage.__default.ConversionNum(RAST.Type.create_U8(), RAST.Expr.create_Call(RAST.Expr.create_MemberSelect(RAST.Expr.create_MemberSelect(RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("dafny_runtime")), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("int!")), Dafny.Sequence<RAST._IExpr>.FromElements(_1020_c)))).Optimize();
        Std.Wrappers._IOption<Dafny.ISequence<Dafny.Rune>> _1033___v12;
        _1033___v12 = (_1020_c).RightMostIdentifier();
      }
    }
    public static void TestPrintingInfo()
    {
      RAST._IExpr _1034_x;
      _1034_x = RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"));
      RAST._IExpr _1035_y;
      _1035_y = RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("y"));
      DAST.Format._IBinaryOpFormat _1036_bnf;
      _1036_bnf = DAST.Format.BinaryOpFormat.create_NoFormat();
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(((RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))).printingInfo).is_UnknownPrecedence);
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((_1034_x).printingInfo, RAST.PrintingInfo.create_Precedence(BigInteger.One)));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_LiteralInt(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("3"))).printingInfo, RAST.PrintingInfo.create_Precedence(BigInteger.One)));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_LiteralString(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("abc"), true, false)).printingInfo, RAST.PrintingInfo.create_Precedence(BigInteger.One)));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("?"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_SuffixPrecedence(new BigInteger(5))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("-"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_Precedence(new BigInteger(6))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("*"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_Precedence(new BigInteger(6))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_Precedence(new BigInteger(6))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_Precedence(new BigInteger(6))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&mut"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_Precedence(new BigInteger(6))));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_UnaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!!"), _1034_x, DAST.Format.UnaryOpFormat.create_NoFormat())).printingInfo, RAST.PrintingInfo.create_UnknownPrecedence()));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_Select(_1034_x, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("name"))).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(2), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_MemberSelect(_1034_x, Dafny.Sequence<Dafny.Rune>.UnicodeFromString("name"))).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(2), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_Call(_1034_x, Dafny.Sequence<RAST._IExpr>.FromElements())).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(2), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_TypeAscription(_1034_x, RAST.Type.create_I128())).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(10), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("*"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(20), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("/"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(20), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("%"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(20), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("+"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(30), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("-"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(30), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<<"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(40), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(">>"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(40), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(50), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("^"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(60), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("|"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(70), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("=="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("!="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(">"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(">="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(80), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&&"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(90), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("||"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(100), RAST.Associativity.create_LeftToRight())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(".."), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("..="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("+="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("-="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("*="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("/="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("%="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("&="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("|="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("^="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("<<="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(">>="), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(new BigInteger(110), RAST.Associativity.create_RightToLeft())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_BinaryOp(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("?!?"), _1034_x, _1035_y, _1036_bnf)).printingInfo, RAST.PrintingInfo.create_PrecedenceAssociativity(BigInteger.Zero, RAST.Associativity.create_RequiresParentheses())));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(object.Equals((RAST.Expr.create_Break(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_None())).printingInfo, RAST.PrintingInfo.create_UnknownPrecedence()));
    }
    public static void TestExpr()
    {
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestOptimizeToString();
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestPrintingInfo();
      DafnyToRustCompilerCoverage.RASTCoverage.__default.TestNoExtraSemicolonAfter();
    }
    public static void AssertCoverage(bool x)
    {
    }
    public static void TestNoExtraSemicolonAfter()
    {
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString(";"))).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(!((RAST.Expr.create_RawExpr(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("a"))).NoExtraSemicolonAfter()));
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.Expr.create_Return(Std.Wrappers.Option<RAST._IExpr>.create_None())).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.Expr.create_Continue(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_None())).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.Expr.create_Break(Std.Wrappers.Option<Dafny.ISequence<Dafny.Rune>>.create_None())).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.__default.AssignVar(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"), RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("y")))).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage((RAST.Expr.create_DeclareVar(RAST.DeclareType.create_MUT(), Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"), Std.Wrappers.Option<RAST._IType>.create_None(), Std.Wrappers.Option<RAST._IExpr>.create_None())).NoExtraSemicolonAfter());
      DafnyToRustCompilerCoverage.RASTCoverage.__default.AssertCoverage(!((RAST.Expr.create_Identifier(Dafny.Sequence<Dafny.Rune>.UnicodeFromString("x"))).NoExtraSemicolonAfter()));
    }
  }
} // end of namespace DafnyToRustCompilerCoverage.RASTCoverage