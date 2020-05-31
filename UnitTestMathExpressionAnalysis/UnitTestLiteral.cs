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
    public class UnitTestLiteral
    {
        [TestMethod]
        public void TestMethodLiteralTrue()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalTrue = new LiteralTrue();
            Assert.AreEqual("true", literalTrue.getRPolish());
            Assert.AreEqual(DataType.Boolean, literalTrue.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(true, literalTrue.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralFalse()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalFalse = new LiteralFalse();
            Assert.AreEqual("false", literalFalse.getRPolish());
            Assert.AreEqual(DataType.Boolean, literalFalse.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(false, literalFalse.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralInteger1()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalInteger = new LiteralInteger();
            literalInteger.value = "12345";
            Assert.AreEqual("Int[12345]", literalInteger.getRPolish());
            Assert.AreEqual(DataType.Integer, literalInteger.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(12345L, literalInteger.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralInteger2()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalInteger = new LiteralInteger();
            literalInteger.value = "0987";
            Assert.AreEqual("Int[0987]", literalInteger.getRPolish());
            Assert.AreEqual(DataType.Integer, literalInteger.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(987L, literalInteger.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralDecimal1()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalDecimal = new LiteralDecimal();
            literalDecimal.value = "12345.678";
            Assert.AreEqual("Dec[12345.678]", literalDecimal.getRPolish());
            Assert.AreEqual(DataType.Decimal, literalDecimal.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(12345.678, literalDecimal.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralDecimal2()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            var variableMap = new Dictionary<string, Variable>();
            var literalDecimal = new LiteralDecimal();
            literalDecimal.value = "12345678.";
            Assert.AreEqual("Dec[12345678.]", literalDecimal.getRPolish());
            Assert.AreEqual(DataType.Decimal, literalDecimal.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue((double)12345678, literalDecimal.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralVariableBoolean()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            variableDataTypeMap.Add("testVariable", DataType.Boolean);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("testVariable", new Variable(true));
            var literalVariable = new LiteralVariable();
            literalVariable.value = "testVariable";
            Assert.AreEqual("Var[testVariable]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Boolean, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(true, literalVariable.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralVariableInteger()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            variableDataTypeMap.Add("testVariable", DataType.Integer);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("testVariable", new Variable(12345));
            var literalVariable = new LiteralVariable();
            literalVariable.value = "testVariable";
            Assert.AreEqual("Var[testVariable]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Integer, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(12345, literalVariable.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralVariableDecimal()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            variableDataTypeMap.Add("testVariable", DataType.Decimal);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("testVariable", new Variable(123.45));
            var literalVariable = new LiteralVariable();
            literalVariable.value = "testVariable";
            Assert.AreEqual("Var[testVariable]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Decimal, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(123.45, literalVariable.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralVariableMultiVariable()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            variableDataTypeMap.Add("testVariable1", DataType.Boolean);
            variableDataTypeMap.Add("testVariable2", DataType.Integer);
            variableDataTypeMap.Add("testVariable3", DataType.Decimal);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("testVariable1", new Variable(true));
            variableMap.Add("testVariable2", new Variable(222));
            variableMap.Add("testVariable3", new Variable(333.33));
            var literalVariable = new LiteralVariable();
            literalVariable.value = "testVariable1";
            Assert.AreEqual("Var[testVariable1]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Boolean, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(true, literalVariable.eval(variableMap));
            literalVariable.value = "testVariable2";
            Assert.AreEqual("Var[testVariable2]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Integer, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(222, literalVariable.eval(variableMap));
            literalVariable.value = "testVariable3";
            Assert.AreEqual("Var[testVariable3]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.Decimal, literalVariable.getDataType(variableDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(333.33, literalVariable.eval(variableMap));
        }
        [TestMethod]
        public void TestMethodLiteralVariableNoMatch()
        {
            var variableDataTypeMap = new Dictionary<string, DataType>();
            variableDataTypeMap.Add("testVariable1", DataType.Boolean);
            variableDataTypeMap.Add("testVariable2", DataType.Integer);
            variableDataTypeMap.Add("testVariable3", DataType.Decimal);
            var variableMap = new Dictionary<string, Variable>();
            variableMap.Add("testVariable1", new Variable(true));
            variableMap.Add("testVariable2", new Variable(222));
            variableMap.Add("testVariable3", new Variable(333.33));
            var literalVariable = new LiteralVariable();
            literalVariable.value = "testVariable";
            Assert.AreEqual("Var[testVariable]", literalVariable.getRPolish());
            Assert.AreEqual(DataType.None, literalVariable.getDataType(variableDataTypeMap));
            try
            {
                literalVariable.eval(variableMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
        }
    }
}
