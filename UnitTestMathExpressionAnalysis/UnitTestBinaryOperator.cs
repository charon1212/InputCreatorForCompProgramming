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
    public class UnitTestBinaryOperator
    {
        [TestMethod]
        public void TestMethodBinaryOperatorAdd()
        {
            var binaryOperatorAdd = new BinaryOperatorAdd();
            Assert.AreEqual(5, binaryOperatorAdd.getPriority());
            Assert.AreEqual("+", binaryOperatorAdd.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Integer, binaryOperatorAdd.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorAdd.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorAdd.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorAdd.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAdd.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(11, binaryOperatorAdd.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(11.1, binaryOperatorAdd.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(11.5, binaryOperatorAdd.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(11.6, binaryOperatorAdd.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorDiff()
        {
            var binaryOperatorDiff = new BinaryOperatorDiff();
            Assert.AreEqual(5, binaryOperatorDiff.getPriority());
            Assert.AreEqual("--", binaryOperatorDiff.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Integer, binaryOperatorDiff.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDiff.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDiff.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDiff.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDiff.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(-5, binaryOperatorDiff.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(-5.1, binaryOperatorDiff.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(-4.5, binaryOperatorDiff.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(-4.6, binaryOperatorDiff.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorProd()
        {
            var binaryOperatorProd = new BinaryOperatorProd();
            Assert.AreEqual(6, binaryOperatorProd.getPriority());
            Assert.AreEqual("*", binaryOperatorProd.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Integer, binaryOperatorProd.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorProd.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorProd.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorProd.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorProd.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(24, binaryOperatorProd.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.0 * 8.1, binaryOperatorProd.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 * 8.0, binaryOperatorProd.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 * 8.1, binaryOperatorProd.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorDivide()
        {
            var binaryOperatorDivide = new BinaryOperatorDivide();
            Assert.AreEqual(6, binaryOperatorDivide.getPriority());
            Assert.AreEqual("/", binaryOperatorDivide.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Integer, binaryOperatorDivide.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDivide.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDivide.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorDivide.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorDivide.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(0, binaryOperatorDivide.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.0 / 8.1, binaryOperatorDivide.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 / 8.0, binaryOperatorDivide.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 / 8.1, binaryOperatorDivide.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorMod()
        {
            var binaryOperatorMod = new BinaryOperatorMod();
            Assert.AreEqual(6, binaryOperatorMod.getPriority());
            Assert.AreEqual("%", binaryOperatorMod.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Integer, binaryOperatorMod.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorMod.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorMod.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorMod.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorMod.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(3, binaryOperatorMod.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.0 % 8.1, binaryOperatorMod.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 % 8.0, binaryOperatorMod.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(3.5 % 8.1, binaryOperatorMod.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorPow()
        {
            var binaryOperatorPow = new BinaryOperatorPow();
            Assert.AreEqual(7, binaryOperatorPow.getPriority());
            Assert.AreEqual("^", binaryOperatorPow.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorPow.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorPow.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Decimal, binaryOperatorPow.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Decimal, binaryOperatorPow.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorPow.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(Math.Pow(3, 8), binaryOperatorPow.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(Math.Pow(3.0, 8.1), binaryOperatorPow.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8.1)));
            UnitTestUtil.AssertMathTreeNodeValue(Math.Pow(3.5, 8.0), binaryOperatorPow.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(Math.Pow(3.5, 8.1), binaryOperatorPow.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorLt()
        {
            var binaryOperatorLt = new BinaryOperatorLt();
            Assert.AreEqual(4, binaryOperatorLt.getPriority());
            Assert.AreEqual("<", binaryOperatorLt.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLt.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLt.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLt.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLt.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLt.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorLt.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorLt.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorLt.eval(new MathTreeNodeValue(8), new MathTreeNodeValue(3.5)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorLt.eval(new MathTreeNodeValue(8.1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorLt.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorLtEq()
        {
            var binaryOperatorLtEq = new BinaryOperatorLtEq();
            Assert.AreEqual(4, binaryOperatorLtEq.getPriority());
            Assert.AreEqual("<=", binaryOperatorLtEq.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLtEq.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLtEq.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLtEq.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorLtEq.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorLtEq.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorLtEq.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorLtEq.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorLtEq.eval(new MathTreeNodeValue(8), new MathTreeNodeValue(3.5)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorLtEq.eval(new MathTreeNodeValue(8.1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorLtEq.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorGt()
        {
            var binaryOperatorGt = new BinaryOperatorGt();
            Assert.AreEqual(4, binaryOperatorGt.getPriority());
            Assert.AreEqual(">", binaryOperatorGt.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGt.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGt.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGt.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGt.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGt.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorGt.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorGt.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorGt.eval(new MathTreeNodeValue(8), new MathTreeNodeValue(3.5)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorGt.eval(new MathTreeNodeValue(8.1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorGt.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorGtEq()
        {
            var binaryOperatorGtEq = new BinaryOperatorGtEq();
            Assert.AreEqual(4, binaryOperatorGtEq.getPriority());
            Assert.AreEqual(">=", binaryOperatorGtEq.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGtEq.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGtEq.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGtEq.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.Boolean, binaryOperatorGtEq.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorGtEq.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorGtEq.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorGtEq.eval(new MathTreeNodeValue(3), new MathTreeNodeValue(8)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorGtEq.eval(new MathTreeNodeValue(8), new MathTreeNodeValue(3.5)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorGtEq.eval(new MathTreeNodeValue(8.1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorGtEq.eval(new MathTreeNodeValue(3.5), new MathTreeNodeValue(8.1)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorEqual()
        {
            var binaryOperatorEqual = new BinaryOperatorEqual();
            Assert.AreEqual(3, binaryOperatorEqual.getPriority());
            Assert.AreEqual("==", binaryOperatorEqual.getRPolish());

            Assert.AreEqual(DataType.Boolean, binaryOperatorEqual.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorEqual.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorEqual.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorEqual.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorEqual.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorEqual.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorEqual.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(false)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorNotEqual()
        {
            var binaryOperatorNotEqual = new BinaryOperatorNotEqual();
            Assert.AreEqual(3, binaryOperatorNotEqual.getPriority());
            Assert.AreEqual("!=", binaryOperatorNotEqual.getRPolish());

            Assert.AreEqual(DataType.Boolean, binaryOperatorNotEqual.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.Boolean, binaryOperatorNotEqual.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorNotEqual.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorNotEqual.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(1)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorNotEqual.eval(new MathTreeNodeValue(1), new MathTreeNodeValue(3)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorNotEqual.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorNotEqual.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(false)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorAnd()
        {
            var binaryOperatorAnd = new BinaryOperatorAnd();
            Assert.AreEqual(2, binaryOperatorAnd.getPriority());
            Assert.AreEqual("&&", binaryOperatorAnd.getRPolish());

            Assert.AreEqual(DataType.Boolean, binaryOperatorAnd.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorAnd.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorAnd.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorAnd.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(false)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorAnd.eval(new MathTreeNodeValue(false), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorAnd.eval(new MathTreeNodeValue(false), new MathTreeNodeValue(false)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorOr()
        {
            var binaryOperatorOr = new BinaryOperatorOr();
            Assert.AreEqual(2, binaryOperatorOr.getPriority());
            Assert.AreEqual("||", binaryOperatorOr.getRPolish());

            Assert.AreEqual(DataType.Boolean, binaryOperatorOr.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorOr.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorOr.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorOr.eval(new MathTreeNodeValue(true), new MathTreeNodeValue(false)));
            UnitTestUtil.AssertMathTreeNodeValue(true, binaryOperatorOr.eval(new MathTreeNodeValue(false), new MathTreeNodeValue(true)));
            UnitTestUtil.AssertMathTreeNodeValue(false, binaryOperatorOr.eval(new MathTreeNodeValue(false), new MathTreeNodeValue(false)));
        }
        [TestMethod]
        public void TestMethodBinaryOperatorComma()
        {
            var binaryOperatorComma = new BinaryOperatorComma();
            Assert.AreEqual(1, binaryOperatorComma.getPriority());
            Assert.AreEqual(",", binaryOperatorComma.getRPolish());

            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Boolean, DataType.Boolean));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Boolean, DataType.Integer));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Boolean, DataType.Decimal));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Boolean, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Integer, DataType.Boolean));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Integer, DataType.Integer));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Integer, DataType.Decimal));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Integer, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.Decimal, DataType.Boolean));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Decimal, DataType.Integer));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Decimal, DataType.Decimal));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.Decimal, DataType.DecimalList));
            Assert.AreEqual(DataType.None, binaryOperatorComma.getDataType(DataType.DecimalList, DataType.Boolean));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.DecimalList, DataType.Integer));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.DecimalList, DataType.Decimal));
            Assert.AreEqual(DataType.DecimalList, binaryOperatorComma.getDataType(DataType.DecimalList, DataType.DecimalList));

            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 2, 2 },
                binaryOperatorComma.eval(new MathTreeNodeValue(2), new MathTreeNodeValue(2)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 2, 4 },
                binaryOperatorComma.eval(new MathTreeNodeValue(2), new MathTreeNodeValue(4.0)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 2, 5.6, 7.8 },
                binaryOperatorComma.eval(new MathTreeNodeValue(2), new MathTreeNodeValue(new List<double>() { 5.6, 7.8 })));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 4, 2 },
                binaryOperatorComma.eval(new MathTreeNodeValue(4.0), new MathTreeNodeValue(2)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 4, 4 },
                binaryOperatorComma.eval(new MathTreeNodeValue(4.0), new MathTreeNodeValue(4.0)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 4, 5.6, 7.8 },
                binaryOperatorComma.eval(new MathTreeNodeValue(4.0), new MathTreeNodeValue(new List<double>() { 5.6, 7.8 })));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 1.2, 3.4, 2 },
                binaryOperatorComma.eval(new MathTreeNodeValue(new List<double>() { 1.2, 3.4 }), new MathTreeNodeValue(2)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 1.2, 3.4, 4 },
                binaryOperatorComma.eval(new MathTreeNodeValue(new List<double>() { 1.2, 3.4 }), new MathTreeNodeValue(4.0)));
            UnitTestUtil.AssertMathTreeNodeValue(new List<double>() { 1.2, 3.4, 5.6, 7.8 },
                binaryOperatorComma.eval(new MathTreeNodeValue(new List<double>() { 1.2, 3.4 }), new MathTreeNodeValue(new List<double>() { 5.6, 7.8 })));
        }

    }
}