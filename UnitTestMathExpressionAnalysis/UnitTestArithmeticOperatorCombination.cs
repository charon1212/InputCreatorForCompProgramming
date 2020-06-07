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
            List<TerminalSymbol> terminalSymbolList = MathExpressionAnalysisLogic.convertTerminalSymbolList(expr);
            List<Lexical> lexicalList = MathExpressionAnalysisLogic.convertLexicalList(terminalSymbolList);
            MathTree tree = MathExpressionAnalysisLogic.makeMathTree(lexicalList);
            DataType dataType = MathExpressionAnalysisLogic.checkDataType(tree);
            MathTreeNodeValue value = MathExpressionAnalysisLogic.eval(tree);
        }
    }
}