using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathExpressionAnalysis;
using MathExpressionAnalysis.Factory;
using MathExpressionAnalysis.Object;
using MathExpressionAnalysis.Object.Lex;
using System.Collections.Generic;
using System;

namespace UnitTestMathExpressionAnalysis
{
    [TestClass]
    public class UnitTestVariable
    {
        [TestMethod]
        public void TestMethodIntegerVariable()
        {

            string expr = "var1 + var2 * 5";
            Variable var1 = new Variable(13);
            Variable var2 = new Variable(29);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("var1", var1);
            variableMap.Add("var2", var2);
            var functionMap = new Dictionary<string, Function>();

            // 終端記号化
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(5, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.Variable, terminalSymbolList[0].type);
            Assert.AreEqual("var1", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.OpAdd, terminalSymbolList[1].type);
            Assert.AreEqual("+", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.Variable, terminalSymbolList[2].type);
            Assert.AreEqual("var2", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.OpProd, terminalSymbolList[3].type);
            Assert.AreEqual("*", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[4].type);
            Assert.AreEqual("5", terminalSymbolList[4].value);

            // 品詞化
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(5, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralVariable));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(LiteralVariable));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(LiteralInteger));
            LiteralVariable l0 = (LiteralVariable)lexicalList[0];
            Assert.AreEqual("var1", l0.value);
            LiteralVariable l2 = (LiteralVariable)lexicalList[2];
            Assert.AreEqual("var2", l2.value);
            LiteralInteger l4 = (LiteralInteger)lexicalList[4];
            Assert.AreEqual("5", l4.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(5, op1.getPriority());
            Operator op3 = (Operator)lexicalList[3];
            Assert.AreEqual(6, op3.getPriority());

            // 数式ツリー化
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(LiteralVariable));
            LiteralVariable literal0 = (LiteralVariable)tree.root.left.lex;
            Assert.AreEqual("var1", literal0.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(LiteralVariable));
            LiteralVariable literal2 = (LiteralVariable)tree.root.right.left.lex;
            Assert.AreEqual("var2", literal2.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal4 = (LiteralInteger)tree.root.right.right.lex;
            Assert.AreEqual("5", literal4.value);

            // データ型評価
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree, variableMap, functionMap);
            Assert.AreEqual(dataType, DataType.Integer);

            // 評価値評価
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree, variableMap, functionMap);
            Assert.AreEqual(value.type, DataType.Integer);
            Assert.AreEqual(value.valueInteger, 158);

        }

        [TestMethod]
        public void TestMethodDecimalVariable()
        {

            string expr = "var1 - var2 / 2.1";
            Variable var1 = new Variable(2.3);
            Variable var2 = new Variable(12.6);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("var1", var1);
            variableMap.Add("var2", var2);
            var functionMap = new Dictionary<string, Function>();

            // 終端記号化
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(5, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.Variable, terminalSymbolList[0].type);
            Assert.AreEqual("var1", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.OpDiff, terminalSymbolList[1].type);
            Assert.AreEqual("-", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.Variable, terminalSymbolList[2].type);
            Assert.AreEqual("var2", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.OpDivide, terminalSymbolList[3].type);
            Assert.AreEqual("/", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[4].type);
            Assert.AreEqual("2.1", terminalSymbolList[4].value);

            // 品詞化
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(5, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralVariable));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(LiteralVariable));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(LiteralDecimal));
            LiteralVariable l0 = (LiteralVariable)lexicalList[0];
            Assert.AreEqual("var1", l0.value);
            LiteralVariable l2 = (LiteralVariable)lexicalList[2];
            Assert.AreEqual("var2", l2.value);
            LiteralDecimal l4 = (LiteralDecimal)lexicalList[4];
            Assert.AreEqual("2.1", l4.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(5, op1.getPriority());
            Operator op3 = (Operator)lexicalList[3];
            Assert.AreEqual(6, op3.getPriority());

            // 数式ツリー化
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(LiteralVariable));
            LiteralVariable literal0 = (LiteralVariable)tree.root.left.lex;
            Assert.AreEqual("var1", literal0.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(LiteralVariable));
            LiteralVariable literal2 = (LiteralVariable)tree.root.right.left.lex;
            Assert.AreEqual("var2", literal2.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal4 = (LiteralDecimal)tree.root.right.right.lex;
            Assert.AreEqual("2.1", literal4.value);

            // データ型評価
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree, variableMap, functionMap);
            Assert.AreEqual(dataType, DataType.Decimal);

            // 評価値評価
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree, variableMap, functionMap);
            Assert.AreEqual(value.type, DataType.Decimal);
            Assert.AreEqual(value.valueDecimal, -3.7);

        }
    }
}
