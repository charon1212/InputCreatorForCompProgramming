using MathExpressionAnalysis.Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestMathExpressionAnalysis
{
    public static class UnitTestUtil
    {
        public static void AssertMathTreeNodeValue(bool expected, MathTreeNodeValue actual)
        {
            Assert.AreEqual(DataType.Boolean, actual.type);
            Assert.AreEqual(expected, actual.valueBool);
        }
        public static void AssertMathTreeNodeValue(long expected, MathTreeNodeValue actual)
        {
            Assert.AreEqual(DataType.Integer, actual.type);
            Assert.AreEqual(expected, actual.valueInteger);
        }
        public static void AssertMathTreeNodeValue(double expected, MathTreeNodeValue actual)
        {
            Assert.AreEqual(DataType.Decimal, actual.type);
            Assert.AreEqual(expected, actual.valueDecimal);
        }
        public static void AssertMathTreeNodeValue(List<double> expected, MathTreeNodeValue actual)
        {
            Assert.AreEqual(DataType.DecimalList, actual.type);
            CollectionAssert.AreEqual(expected, actual.valueDecimalList);
        }
    }
}
