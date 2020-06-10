using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathExpressionAnalysis;
using MathExpressionAnalysis.Factory;
using MathExpressionAnalysis.Object;
using MathExpressionAnalysis.Object.Lex;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UnitTestMathExpressionAnalysis
{
    [TestClass]
    public class UnitTestLogicalOperatorCombination
    {
        [TestMethod]
        public void TestPattern1()
        {
            string expr = "true && 1 < 5 == 2 <= 6.3";
            // 終端記号化
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(9, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.LogicTrue, terminalSymbolList[0].type);
            Assert.AreEqual("true", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.OpAnd, terminalSymbolList[1].type);
            Assert.AreEqual("&&", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[2].type);
            Assert.AreEqual("1", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.OpLt, terminalSymbolList[3].type);
            Assert.AreEqual("<", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[4].type);
            Assert.AreEqual("5", terminalSymbolList[4].value);
            Assert.AreEqual(TerminalSymbolType.OpEq, terminalSymbolList[5].type);
            Assert.AreEqual("==", terminalSymbolList[5].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[6].type);
            Assert.AreEqual("2", terminalSymbolList[6].value);
            Assert.AreEqual(TerminalSymbolType.OpLtEq, terminalSymbolList[7].type);
            Assert.AreEqual("<=", terminalSymbolList[7].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[8].type);
            Assert.AreEqual("6.3", terminalSymbolList[8].value);

            // 品詞化
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(9, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralTrue));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorAnd));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(BinaryOperatorLt));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[5].GetType() == typeof(BinaryOperatorEqual));
            Assert.IsTrue(lexicalList[6].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[7].GetType() == typeof(BinaryOperatorLtEq));
            Assert.IsTrue(lexicalList[8].GetType() == typeof(LiteralDecimal));
            LiteralTrue l0 = (LiteralTrue)lexicalList[0];
            Assert.AreEqual("true", l0.value);
            LiteralInteger l2 = (LiteralInteger)lexicalList[2];
            Assert.AreEqual("1", l2.value);
            LiteralInteger l4 = (LiteralInteger)lexicalList[4];
            Assert.AreEqual("5", l4.value);
            LiteralInteger l6 = (LiteralInteger)lexicalList[6];
            Assert.AreEqual("2", l6.value);
            LiteralDecimal l8 = (LiteralDecimal)lexicalList[8];
            Assert.AreEqual("6.3", l8.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(2, op1.getPriority());
            Operator op3 = (Operator)lexicalList[3];
            Assert.AreEqual(4, op3.getPriority());
            Operator op5 = (Operator)lexicalList[5];
            Assert.AreEqual(3, op5.getPriority());
            Operator op7 = (Operator)lexicalList[7];
            Assert.AreEqual(4, op7.getPriority());

            // 数式ツリー化
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(LiteralTrue));
            LiteralTrue literal0 = (LiteralTrue)tree.root.left.lex;
            Assert.AreEqual("true", literal0.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorAnd));
            Assert.IsTrue(tree.root.right.left.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal2 = (LiteralInteger)tree.root.right.left.left.lex;
            Assert.AreEqual("1", literal2.value);
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(BinaryOperatorLt));
            Assert.IsTrue(tree.root.right.left.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal4 = (LiteralInteger)tree.root.right.left.right.lex;
            Assert.AreEqual("5", literal4.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorEqual));
            Assert.IsTrue(tree.root.right.right.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal6 = (LiteralInteger)tree.root.right.right.left.lex;
            Assert.AreEqual("2", literal6.value);
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(BinaryOperatorLtEq));
            Assert.IsTrue(tree.root.right.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal8 = (LiteralDecimal)tree.root.right.right.right.lex;
            Assert.AreEqual("6.3", literal8.value);

            // データ型評価
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            Assert.AreEqual(dataType, DataType.Boolean);

            // 評価値評価
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
            Assert.AreEqual(value.type, DataType.Boolean);
            Assert.AreEqual(value.valueBool, true);

        }
        [TestMethod]
        public void TestPattern2()
        {
            string expr = "!true || 1 > 5 != 2 >= 6.3";
            // 終端記号化
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(10, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.OpNot, terminalSymbolList[0].type);
            Assert.AreEqual("!", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.LogicTrue, terminalSymbolList[1].type);
            Assert.AreEqual("true", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.OpOr, terminalSymbolList[2].type);
            Assert.AreEqual("||", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[3].type);
            Assert.AreEqual("1", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.OpGt, terminalSymbolList[4].type);
            Assert.AreEqual(">", terminalSymbolList[4].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[5].type);
            Assert.AreEqual("5", terminalSymbolList[5].value);
            Assert.AreEqual(TerminalSymbolType.OpNotEq, terminalSymbolList[6].type);
            Assert.AreEqual("!=", terminalSymbolList[6].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[7].type);
            Assert.AreEqual("2", terminalSymbolList[7].value);
            Assert.AreEqual(TerminalSymbolType.OpGtEq, terminalSymbolList[8].type);
            Assert.AreEqual(">=", terminalSymbolList[8].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[9].type);
            Assert.AreEqual("6.3", terminalSymbolList[9].value);

            // 品詞化
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(10, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(UnaryOperatorNot));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(LiteralTrue));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(BinaryOperatorOr));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(BinaryOperatorGt));
            Assert.IsTrue(lexicalList[5].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[6].GetType() == typeof(BinaryOperatorNotEqual));
            Assert.IsTrue(lexicalList[7].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[8].GetType() == typeof(BinaryOperatorGtEq));
            Assert.IsTrue(lexicalList[9].GetType() == typeof(LiteralDecimal));
            LiteralTrue l1 = (LiteralTrue)lexicalList[1];
            Assert.AreEqual("true", l1.value);
            LiteralInteger l3 = (LiteralInteger)lexicalList[3];
            Assert.AreEqual("1", l3.value);
            LiteralInteger l5 = (LiteralInteger)lexicalList[5];
            Assert.AreEqual("5", l5.value);
            LiteralInteger l7 = (LiteralInteger)lexicalList[7];
            Assert.AreEqual("2", l7.value);
            LiteralDecimal l9 = (LiteralDecimal)lexicalList[9];
            Assert.AreEqual("6.3", l9.value);
            Operator op0 = (Operator)lexicalList[0];
            Assert.AreEqual(8, op0.getPriority());
            Operator op2 = (Operator)lexicalList[2];
            Assert.AreEqual(2, op2.getPriority());
            Operator op4 = (Operator)lexicalList[4];
            Assert.AreEqual(4, op4.getPriority());
            Operator op6 = (Operator)lexicalList[6];
            Assert.AreEqual(3, op6.getPriority());
            Operator op8 = (Operator)lexicalList[8];
            Assert.AreEqual(4, op8.getPriority());

            // 数式ツリー化
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(UnaryOperatorNot));
            Assert.IsTrue(tree.root.left.right.lex.GetType() == typeof(LiteralTrue));
            LiteralTrue literal1 = (LiteralTrue)tree.root.left.right.lex;
            Assert.AreEqual("true", literal1.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorOr));
            Assert.IsTrue(tree.root.right.left.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal3 = (LiteralInteger)tree.root.right.left.left.lex;
            Assert.AreEqual("1", literal3.value);
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(BinaryOperatorGt));
            Assert.IsTrue(tree.root.right.left.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal5 = (LiteralInteger)tree.root.right.left.right.lex;
            Assert.AreEqual("5", literal5.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorNotEqual));
            Assert.IsTrue(tree.root.right.right.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal7 = (LiteralInteger)tree.root.right.right.left.lex;
            Assert.AreEqual("2", literal7.value);
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(BinaryOperatorGtEq));
            Assert.IsTrue(tree.root.right.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal9 = (LiteralDecimal)tree.root.right.right.right.lex;
            Assert.AreEqual("6.3", literal9.value);

            // データ型評価
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            Assert.AreEqual(dataType, DataType.Boolean);

            // 評価値評価
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
            Assert.AreEqual(value.type, DataType.Boolean);
            Assert.AreEqual(value.valueBool, false);


        }
    }
}
