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
    public class UnitTestArithmeticOperatorCombination
    {
        [TestMethod]
        public void TestPattern1()
        {
            string expr = "((((1+-2)-3)*-4)/5)%6";

            // 終端記号化
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(21, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.LeftP, terminalSymbolList[0].type);
            Assert.AreEqual("(", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.LeftP, terminalSymbolList[1].type);
            Assert.AreEqual("(", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.LeftP, terminalSymbolList[2].type);
            Assert.AreEqual("(", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.LeftP, terminalSymbolList[3].type);
            Assert.AreEqual("(", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[4].type);
            Assert.AreEqual("1", terminalSymbolList[4].value);
            Assert.AreEqual(TerminalSymbolType.OpAdd, terminalSymbolList[5].type);
            Assert.AreEqual("+", terminalSymbolList[5].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[6].type);
            Assert.AreEqual("-", terminalSymbolList[6].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[7].type);
            Assert.AreEqual("2", terminalSymbolList[7].value);
            Assert.AreEqual(TerminalSymbolType.RightP, terminalSymbolList[8].type);
            Assert.AreEqual(")", terminalSymbolList[8].value);
            Assert.AreEqual(TerminalSymbolType.OpDiff, terminalSymbolList[9].type);
            Assert.AreEqual("-", terminalSymbolList[9].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[10].type);
            Assert.AreEqual("3", terminalSymbolList[10].value);
            Assert.AreEqual(TerminalSymbolType.RightP, terminalSymbolList[11].type);
            Assert.AreEqual(")", terminalSymbolList[11].value);
            Assert.AreEqual(TerminalSymbolType.OpProd, terminalSymbolList[12].type);
            Assert.AreEqual("*", terminalSymbolList[12].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[13].type);
            Assert.AreEqual("-", terminalSymbolList[13].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[14].type);
            Assert.AreEqual("4", terminalSymbolList[14].value);
            Assert.AreEqual(TerminalSymbolType.RightP, terminalSymbolList[15].type);
            Assert.AreEqual(")", terminalSymbolList[15].value);
            Assert.AreEqual(TerminalSymbolType.OpDivide, terminalSymbolList[16].type);
            Assert.AreEqual("/", terminalSymbolList[16].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[17].type);
            Assert.AreEqual("5", terminalSymbolList[17].value);
            Assert.AreEqual(TerminalSymbolType.RightP, terminalSymbolList[18].type);
            Assert.AreEqual(")", terminalSymbolList[18].value);
            Assert.AreEqual(TerminalSymbolType.OpMod, terminalSymbolList[19].type);
            Assert.AreEqual("%", terminalSymbolList[19].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[20].type);
            Assert.AreEqual("6", terminalSymbolList[20].value);

            // 品詞化
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(13, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(lexicalList[5].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[6].GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(lexicalList[7].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[8].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[9].GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(lexicalList[10].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[11].GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(lexicalList[12].GetType() == typeof(LiteralInteger));
            LiteralInteger l0 = (LiteralInteger)lexicalList[0];
            Assert.AreEqual("1", l0.value);
            LiteralInteger l3 = (LiteralInteger)lexicalList[3];
            Assert.AreEqual("2", l3.value);
            LiteralInteger l5 = (LiteralInteger)lexicalList[5];
            Assert.AreEqual("3", l5.value);
            LiteralInteger l8 = (LiteralInteger)lexicalList[8];
            Assert.AreEqual("4", l8.value);
            LiteralInteger l10 = (LiteralInteger)lexicalList[10];
            Assert.AreEqual("5", l10.value);
            LiteralInteger l12 = (LiteralInteger)lexicalList[12];
            Assert.AreEqual("6", l12.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(45, op1.getPriority());
            Operator op2 = (Operator)lexicalList[2];
            Assert.AreEqual(48, op2.getPriority());
            Operator op4 = (Operator)lexicalList[4];
            Assert.AreEqual(35, op4.getPriority());
            Operator op6 = (Operator)lexicalList[6];
            Assert.AreEqual(26, op6.getPriority());
            Operator op7 = (Operator)lexicalList[7];
            Assert.AreEqual(28, op7.getPriority());
            Operator op9 = (Operator)lexicalList[9];
            Assert.AreEqual(16, op9.getPriority());
            Operator op11 = (Operator)lexicalList[11];
            Assert.AreEqual(6, op11.getPriority());

            // 数式ツリー化
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.left.left.left.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal0 = (LiteralInteger)tree.root.left.left.left.left.left.lex;
            Assert.AreEqual("1", literal0.value);
            Assert.IsTrue(tree.root.left.left.left.left.lex.GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(tree.root.left.left.left.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.left.left.left.left.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal3 = (LiteralInteger)tree.root.left.left.left.left.right.right.lex;
            Assert.AreEqual("2", literal3.value);
            Assert.IsTrue(tree.root.left.left.left.lex.GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(tree.root.left.left.left.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal5 = (LiteralInteger)tree.root.left.left.left.right.lex;
            Assert.AreEqual("3", literal5.value);
            Assert.IsTrue(tree.root.left.left.lex.GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(tree.root.left.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.left.left.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal8 = (LiteralInteger)tree.root.left.left.right.right.lex;
            Assert.AreEqual("4", literal8.value);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(tree.root.left.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal10 = (LiteralInteger)tree.root.left.right.lex;
            Assert.AreEqual("5", literal10.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal12 = (LiteralInteger)tree.root.right.lex;
            Assert.AreEqual("6", literal12.value);

            // データ型評価
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            Assert.AreEqual(dataType, DataType.Integer);

            // 評価値評価
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
            Assert.AreEqual(value.type, DataType.Integer);
            Assert.AreEqual(value.valueInteger, 3);

        }
        [TestMethod]
        public void TestPattern2()
        {
            string expr = "1+-2-3*-4/5%6";
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(13, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[0].type);
            Assert.AreEqual("1", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.OpAdd, terminalSymbolList[1].type);
            Assert.AreEqual("+", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[2].type);
            Assert.AreEqual("-", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[3].type);
            Assert.AreEqual("2", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.OpDiff, terminalSymbolList[4].type);
            Assert.AreEqual("-", terminalSymbolList[4].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[5].type);
            Assert.AreEqual("3", terminalSymbolList[5].value);
            Assert.AreEqual(TerminalSymbolType.OpProd, terminalSymbolList[6].type);
            Assert.AreEqual("*", terminalSymbolList[6].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[7].type);
            Assert.AreEqual("-", terminalSymbolList[7].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[8].type);
            Assert.AreEqual("4", terminalSymbolList[8].value);
            Assert.AreEqual(TerminalSymbolType.OpDivide, terminalSymbolList[9].type);
            Assert.AreEqual("/", terminalSymbolList[9].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[10].type);
            Assert.AreEqual("5", terminalSymbolList[10].value);
            Assert.AreEqual(TerminalSymbolType.OpMod, terminalSymbolList[11].type);
            Assert.AreEqual("%", terminalSymbolList[11].value);
            Assert.AreEqual(TerminalSymbolType.Integer, terminalSymbolList[12].type);
            Assert.AreEqual("6", terminalSymbolList[12].value);

            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(13, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(lexicalList[5].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[6].GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(lexicalList[7].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[8].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[9].GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(lexicalList[10].GetType() == typeof(LiteralInteger));
            Assert.IsTrue(lexicalList[11].GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(lexicalList[12].GetType() == typeof(LiteralInteger));
            LiteralInteger l0 = (LiteralInteger)lexicalList[0];
            Assert.AreEqual("1", l0.value);
            LiteralInteger l3 = (LiteralInteger)lexicalList[3];
            Assert.AreEqual("2", l3.value);
            LiteralInteger l5 = (LiteralInteger)lexicalList[5];
            Assert.AreEqual("3", l5.value);
            LiteralInteger l8 = (LiteralInteger)lexicalList[8];
            Assert.AreEqual("4", l8.value);
            LiteralInteger l10 = (LiteralInteger)lexicalList[10];
            Assert.AreEqual("5", l10.value);
            LiteralInteger l12 = (LiteralInteger)lexicalList[12];
            Assert.AreEqual("6", l12.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(5, op1.getPriority());
            Operator op2 = (Operator)lexicalList[2];
            Assert.AreEqual(8, op2.getPriority());
            Operator op4 = (Operator)lexicalList[4];
            Assert.AreEqual(5, op4.getPriority());
            Operator op6 = (Operator)lexicalList[6];
            Assert.AreEqual(6, op6.getPriority());
            Operator op7 = (Operator)lexicalList[7];
            Assert.AreEqual(8, op7.getPriority());
            Operator op9 = (Operator)lexicalList[9];
            Assert.AreEqual(6, op9.getPriority());
            Operator op11 = (Operator)lexicalList[11];
            Assert.AreEqual(6, op11.getPriority());

            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal0 = (LiteralInteger)tree.root.left.left.lex;
            Assert.AreEqual("1", literal0.value);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(tree.root.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.left.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal3 = (LiteralInteger)tree.root.left.right.right.lex;
            Assert.AreEqual("2", literal3.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(tree.root.right.left.left.left.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal5 = (LiteralInteger)tree.root.right.left.left.left.lex;
            Assert.AreEqual("3", literal5.value);
            Assert.IsTrue(tree.root.right.left.left.lex.GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(tree.root.right.left.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.right.left.left.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal8 = (LiteralInteger)tree.root.right.left.left.right.right.lex;
            Assert.AreEqual("4", literal8.value);
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(tree.root.right.left.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal10 = (LiteralInteger)tree.root.right.left.right.lex;
            Assert.AreEqual("5", literal10.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(LiteralInteger));
            LiteralInteger literal12 = (LiteralInteger)tree.root.right.right.lex;
            Assert.AreEqual("6", literal12.value);

            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            Assert.AreEqual(dataType, DataType.Integer);

            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
            Assert.AreEqual(value.type, DataType.Integer);
            Assert.AreEqual(value.valueInteger, 1);
        }
        [TestMethod]
        public void TestPattern3()
        {
            string expr = "1.3+-2.4-3.5*-4.6/5.7%6.8^-7.9";
            
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            Assert.AreEqual(16, terminalSymbolList.Count);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[0].type);
            Assert.AreEqual("1.3", terminalSymbolList[0].value);
            Assert.AreEqual(TerminalSymbolType.OpAdd, terminalSymbolList[1].type);
            Assert.AreEqual("+", terminalSymbolList[1].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[2].type);
            Assert.AreEqual("-", terminalSymbolList[2].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[3].type);
            Assert.AreEqual("2.4", terminalSymbolList[3].value);
            Assert.AreEqual(TerminalSymbolType.OpDiff, terminalSymbolList[4].type);
            Assert.AreEqual("-", terminalSymbolList[4].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[5].type);
            Assert.AreEqual("3.5", terminalSymbolList[5].value);
            Assert.AreEqual(TerminalSymbolType.OpProd, terminalSymbolList[6].type);
            Assert.AreEqual("*", terminalSymbolList[6].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[7].type);
            Assert.AreEqual("-", terminalSymbolList[7].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[8].type);
            Assert.AreEqual("4.6", terminalSymbolList[8].value);
            Assert.AreEqual(TerminalSymbolType.OpDivide, terminalSymbolList[9].type);
            Assert.AreEqual("/", terminalSymbolList[9].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[10].type);
            Assert.AreEqual("5.7", terminalSymbolList[10].value);
            Assert.AreEqual(TerminalSymbolType.OpMod, terminalSymbolList[11].type);
            Assert.AreEqual("%", terminalSymbolList[11].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[12].type);
            Assert.AreEqual("6.8", terminalSymbolList[12].value);
            Assert.AreEqual(TerminalSymbolType.OpPow, terminalSymbolList[13].type);
            Assert.AreEqual("^", terminalSymbolList[13].value);
            Assert.AreEqual(TerminalSymbolType.OpNeg, terminalSymbolList[14].type);
            Assert.AreEqual("-", terminalSymbolList[14].value);
            Assert.AreEqual(TerminalSymbolType.Decimal, terminalSymbolList[15].type);
            Assert.AreEqual("7.9", terminalSymbolList[15].value);

            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            Assert.AreEqual(16, lexicalList.Count);
            Assert.IsTrue(lexicalList[0].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[1].GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(lexicalList[2].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[3].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[4].GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(lexicalList[5].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[6].GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(lexicalList[7].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[8].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[9].GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(lexicalList[10].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[11].GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(lexicalList[12].GetType() == typeof(LiteralDecimal));
            Assert.IsTrue(lexicalList[13].GetType() == typeof(BinaryOperatorPow));
            Assert.IsTrue(lexicalList[14].GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(lexicalList[15].GetType() == typeof(LiteralDecimal));
            LiteralDecimal l0 = (LiteralDecimal)lexicalList[0];
            Assert.AreEqual("1.3", l0.value);
            LiteralDecimal l3 = (LiteralDecimal)lexicalList[3];
            Assert.AreEqual("2.4", l3.value);
            LiteralDecimal l5 = (LiteralDecimal)lexicalList[5];
            Assert.AreEqual("3.5", l5.value);
            LiteralDecimal l8 = (LiteralDecimal)lexicalList[8];
            Assert.AreEqual("4.6", l8.value);
            LiteralDecimal l10 = (LiteralDecimal)lexicalList[10];
            Assert.AreEqual("5.7", l10.value);
            LiteralDecimal l12 = (LiteralDecimal)lexicalList[12];
            Assert.AreEqual("6.8", l12.value);
            LiteralDecimal l15 = (LiteralDecimal)lexicalList[15];
            Assert.AreEqual("7.9", l15.value);
            Operator op1 = (Operator)lexicalList[1];
            Assert.AreEqual(5, op1.getPriority());
            Operator op2 = (Operator)lexicalList[2];
            Assert.AreEqual(8, op2.getPriority());
            Operator op4 = (Operator)lexicalList[4];
            Assert.AreEqual(5, op4.getPriority());
            Operator op6 = (Operator)lexicalList[6];
            Assert.AreEqual(6, op6.getPriority());
            Operator op7 = (Operator)lexicalList[7];
            Assert.AreEqual(8, op7.getPriority());
            Operator op9 = (Operator)lexicalList[9];
            Assert.AreEqual(6, op9.getPriority());
            Operator op11 = (Operator)lexicalList[11];
            Assert.AreEqual(6, op11.getPriority());
            Operator op13 = (Operator)lexicalList[13];
            Assert.AreEqual(7, op13.getPriority());
            Operator op14 = (Operator)lexicalList[14];
            Assert.AreEqual(8, op14.getPriority());

            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            Assert.IsTrue(tree.root.left.left.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal0 = (LiteralDecimal)tree.root.left.left.lex;
            Assert.AreEqual("1.3", literal0.value);
            Assert.IsTrue(tree.root.left.lex.GetType() == typeof(BinaryOperatorAdd));
            Assert.IsTrue(tree.root.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.left.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal3 = (LiteralDecimal)tree.root.left.right.right.lex;
            Assert.AreEqual("2.4", literal3.value);
            Assert.IsTrue(tree.root.lex.GetType() == typeof(BinaryOperatorDiff));
            Assert.IsTrue(tree.root.right.left.left.left.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal5 = (LiteralDecimal)tree.root.right.left.left.left.lex;
            Assert.AreEqual("3.5", literal5.value);
            Assert.IsTrue(tree.root.right.left.left.lex.GetType() == typeof(BinaryOperatorProd));
            Assert.IsTrue(tree.root.right.left.left.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.right.left.left.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal8 = (LiteralDecimal)tree.root.right.left.left.right.right.lex;
            Assert.AreEqual("4.6", literal8.value);
            Assert.IsTrue(tree.root.right.left.lex.GetType() == typeof(BinaryOperatorDivide));
            Assert.IsTrue(tree.root.right.left.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal10 = (LiteralDecimal)tree.root.right.left.right.lex;
            Assert.AreEqual("5.7", literal10.value);
            Assert.IsTrue(tree.root.right.lex.GetType() == typeof(BinaryOperatorMod));
            Assert.IsTrue(tree.root.right.right.left.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal12 = (LiteralDecimal)tree.root.right.right.left.lex;
            Assert.AreEqual("6.8", literal12.value);
            Assert.IsTrue(tree.root.right.right.lex.GetType() == typeof(BinaryOperatorPow));
            Assert.IsTrue(tree.root.right.right.right.lex.GetType() == typeof(UnaryOperatorNegative));
            Assert.IsTrue(tree.root.right.right.right.right.lex.GetType() == typeof(LiteralDecimal));
            LiteralDecimal literal15 = (LiteralDecimal)tree.root.right.right.right.right.lex;
            Assert.AreEqual("7.9", literal15.value);

            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            Assert.AreEqual(dataType, DataType.Decimal);

            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
            Assert.AreEqual(DataType.Decimal, value.type);
            Assert.AreEqual(1.3 + -2.4 - 3.5 * -4.6 / 5.7 % Math.Pow(6.8, -7.9), value.valueDecimal);

        }
    }
}