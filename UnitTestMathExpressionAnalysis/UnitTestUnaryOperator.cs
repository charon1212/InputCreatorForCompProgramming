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
    public class UnitTestUnaryOperator
    {
        [TestMethod]
        public void TestMethodUnaryOperatorNegative()
        {
            var functionDataTypeMap = new Dictionary<string, DataType>();
            var functionMap = new Dictionary<string, Function>();
            var unaryOperatorNegative = new UnaryOperatorNegative();
            Assert.AreEqual("-", unaryOperatorNegative.getRPolish());
            Assert.AreEqual(8, unaryOperatorNegative.getPriority());
            Assert.AreEqual(DataType.None, unaryOperatorNegative.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorNegative.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorNegative.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorNegative.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorNegative.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(-12345, unaryOperatorNegative.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(-12345.678, unaryOperatorNegative.eval(new MathTreeNodeValue(12345.678), functionMap));
            try
            {
                unaryOperatorNegative.eval(new MathTreeNodeValue(new List<double>() { 1.2, 3.4, 5.6 }), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
        }
        [TestMethod]
        public void TestMethodUnaryOperatorNot()
        {
            var functionDataTypeMap = new Dictionary<string, DataType>();
            var functionMap = new Dictionary<string, Function>();
            var unaryOperatorNot = new UnaryOperatorNot();
            Assert.AreEqual("!", unaryOperatorNot.getRPolish());
            Assert.AreEqual(8, unaryOperatorNot.getPriority());
            Assert.AreEqual(DataType.Boolean, unaryOperatorNot.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorNot.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorNot.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorNot.getDataType(DataType.DecimalList, functionDataTypeMap));
            UnitTestUtil.AssertMathTreeNodeValue(false, unaryOperatorNot.eval(new MathTreeNodeValue(true), functionMap));
            try
            {
                unaryOperatorNot.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorNot.eval(new MathTreeNodeValue(12345.678), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorNot.eval(new MathTreeNodeValue(new List<double>() { 1.2, 3.4, 5.6 }), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
        }
        [TestMethod]
        public void TestMethodUnaryOperatorFunction()
        {
            var functionDataTypeMap = new Dictionary<string, DataType>();
            functionDataTypeMap.Add("testFunction1", DataType.Boolean);
            functionDataTypeMap.Add("testFunction2", DataType.Boolean);
            functionDataTypeMap.Add("testFunction3", DataType.Boolean);
            functionDataTypeMap.Add("testFunction4", DataType.Integer);
            functionDataTypeMap.Add("testFunction5", DataType.Integer);
            functionDataTypeMap.Add("testFunction6", DataType.Integer);
            functionDataTypeMap.Add("testFunction7", DataType.Decimal);
            functionDataTypeMap.Add("testFunction8", DataType.Decimal);
            functionDataTypeMap.Add("testFunction9", DataType.Decimal);
            var functionMap = new Dictionary<string, Function>();
            functionMap.Add("testFunction1", new Function(this.testFunction1));
            functionMap.Add("testFunction2", new Function(this.testFunction2));
            functionMap.Add("testFunction3", new Function(this.testFunction3));
            functionMap.Add("testFunction4", new Function(this.testFunction4));
            functionMap.Add("testFunction5", new Function(this.testFunction5));
            functionMap.Add("testFunction6", new Function(this.testFunction6));
            functionMap.Add("testFunction7", new Function(this.testFunction7));
            functionMap.Add("testFunction8", new Function(this.testFunction8));
            functionMap.Add("testFunction9", new Function(this.testFunction9));

            var unaryOperatorFunction = new UnaryOperatorFunction();
            Assert.AreEqual(9, unaryOperatorFunction.getPriority());

            unaryOperatorFunction.functionName = "testFunction1";
            Assert.AreEqual("Func[testFunction1]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(true, unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(false, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(true, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction2";
            Assert.AreEqual("Func[testFunction2]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(true, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction3";
            Assert.AreEqual("Func[testFunction3]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Boolean, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(true, unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(false, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(true, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction4";
            Assert.AreEqual("Func[testFunction4]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(12348, unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(-121, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(4, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction5";
            Assert.AreEqual("Func[testFunction5]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(3, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction6";
            Assert.AreEqual("Func[testFunction6]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Integer, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(12345, unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(-124, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(10, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction7";
            Assert.AreEqual("Func[testFunction7]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue(Math.Sqrt((double)12345), unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(Double.NaN, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue((double)1, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction8";
            Assert.AreEqual("Func[testFunction8]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentOutOfRangeException));
            }
            UnitTestUtil.AssertMathTreeNodeValue((double)0, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction9";
            Assert.AreEqual("Func[testFunction9]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.Decimal, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            UnitTestUtil.AssertMathTreeNodeValue((double)152399025, unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue(15239.9025, unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap));
            UnitTestUtil.AssertMathTreeNodeValue((double)30, unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap));

            unaryOperatorFunction.functionName = "testFunction10";
            Assert.AreEqual("Func[testFunction10]", unaryOperatorFunction.getRPolish());
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Boolean, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Integer, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.Decimal, functionDataTypeMap));
            Assert.AreEqual(DataType.None, unaryOperatorFunction.getDataType(DataType.DecimalList, functionDataTypeMap));
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(true), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(12345), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(-123.45), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
            try
            {
                unaryOperatorFunction.eval(new MathTreeNodeValue(new List<double>() { 1, 2, 3, 4 }), functionMap);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ArgumentException));
            }
        }
        private bool testFunction1(List<double> arguments)
        {
            return arguments[0] > 0;
        }
        private bool testFunction2(List<double> arguments)
        {
            return arguments[0] < arguments[1];
        }
        private bool testFunction3(List<double> arguments)
        {
            return arguments.All(x => x > 0);
        }
        private long testFunction4(List<double> arguments)
        {
            return (long)Math.Floor(arguments[0] + 3);
        }
        private long testFunction5(List<double> arguments)
        {
            return (long)Math.Floor(arguments[0] + arguments[1]);
        }
        private long testFunction6(List<double> arguments)
        {
            double sum = 0;
            foreach (var item in arguments) sum += item;
            return (long)Math.Floor(sum);
        }
        private double testFunction7(List<double> arguments)
        {
            return Math.Sqrt(arguments[0]);
        }
        private double testFunction8(List<double> arguments)
        {
            return Math.Log(arguments[0]) / Math.Log(arguments[1]);
        }
        private double testFunction9(List<double> arguments)
        {
            double sumSq = 0;
            foreach (var item in arguments) sumSq += item * item;
            return sumSq;
        }
    }
}
