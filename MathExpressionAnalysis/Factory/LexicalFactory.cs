using MathExpressionAnalysis.Object;
using MathExpressionAnalysis.Object.Lex;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Factory
{
    public static class LexicalFactory
    {
        public static Lexical create(TerminalSymbol terminalSymbol, int parenthesisDepth)
        {
            switch (terminalSymbol.type)
            {
                case TerminalSymbolType.Integer:
                    var literalInteger = new LiteralInteger();
                    literalInteger.value = terminalSymbol.value;
                    return literalInteger;
                case TerminalSymbolType.Decimal:
                    var literalDecimal = new LiteralDecimal();
                    literalDecimal.value = terminalSymbol.value;
                    return literalDecimal;
                case TerminalSymbolType.LogicTrue:
                    var literalTrue = new LiteralTrue();
                    literalTrue.value = terminalSymbol.value;
                    return literalTrue;
                case TerminalSymbolType.LogicFalse:
                    var literalFalse = new LiteralFalse();
                    literalFalse.value = terminalSymbol.value;
                    return literalFalse;
                case TerminalSymbolType.Variable:
                    var literalVariable = new LiteralVariable();
                    literalVariable.value = terminalSymbol.value;
                    return literalVariable;
                case TerminalSymbolType.OpAdd:
                    var binaryOperatorAdd = new BinaryOperatorAdd();
                    binaryOperatorAdd.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorAdd;
                case TerminalSymbolType.OpDiff:
                    var binaryOperatorDiff = new BinaryOperatorDiff();
                    binaryOperatorDiff.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorDiff;
                case TerminalSymbolType.OpProd:
                    var binaryOperatorProd = new BinaryOperatorProd();
                    binaryOperatorProd.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorProd;
                case TerminalSymbolType.OpDivide:
                    var binaryOperatorDivide = new BinaryOperatorDivide();
                    binaryOperatorDivide.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorDivide;
                case TerminalSymbolType.OpMod:
                    var binaryOperatorMod = new BinaryOperatorMod();
                    binaryOperatorMod.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorMod;
                case TerminalSymbolType.OpPow:
                    var binaryOperatorPow = new BinaryOperatorPow();
                    binaryOperatorPow.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorPow;
                case TerminalSymbolType.OpNeg:
                    var unaryOperatorNegative = new UnaryOperatorNegative();
                    unaryOperatorNegative.parenthesisDepth = parenthesisDepth;
                    return unaryOperatorNegative;
                case TerminalSymbolType.OpLt:
                    var binaryOperatorLt = new BinaryOperatorLt();
                    binaryOperatorLt.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorLt;
                case TerminalSymbolType.OpLtEq:
                    var binaryOperatorLtEq = new BinaryOperatorLtEq();
                    binaryOperatorLtEq.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorLtEq;
                case TerminalSymbolType.OpGt:
                    var binaryOperatorGt = new BinaryOperatorGt();
                    binaryOperatorGt.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorGt;
                case TerminalSymbolType.OpGtEq:
                    var binaryOperatorGtEq = new BinaryOperatorGtEq();
                    binaryOperatorGtEq.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorGtEq;
                case TerminalSymbolType.OpEq:
                    var binaryOperatorEqual = new BinaryOperatorEqual();
                    binaryOperatorEqual.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorEqual;
                case TerminalSymbolType.OpNotEq:
                    var binaryOperatorNotEqual = new BinaryOperatorNotEqual();
                    binaryOperatorNotEqual.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorNotEqual;
                case TerminalSymbolType.OpNot:
                    var unaryOperatorNot = new UnaryOperatorNot();
                    unaryOperatorNot.parenthesisDepth = parenthesisDepth;
                    return unaryOperatorNot;
                case TerminalSymbolType.OpAnd:
                    var binaryOperatorAnd = new BinaryOperatorAnd();
                    binaryOperatorAnd.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorAnd;
                case TerminalSymbolType.OpOr:
                    var binaryOperatorOr = new BinaryOperatorOr();
                    binaryOperatorOr.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorOr;
                case TerminalSymbolType.Function:
                    var unaryOperatorFunction = new UnaryOperatorFunction(terminalSymbol.value); // 演算子の中で、関数だけ変数名を登録する必要がある。
                    unaryOperatorFunction.parenthesisDepth = parenthesisDepth;
                    return unaryOperatorFunction;
                case TerminalSymbolType.Comma:
                    var binaryOperatorComma = new BinaryOperatorComma();
                    binaryOperatorComma.parenthesisDepth = parenthesisDepth;
                    return binaryOperatorComma;
                default:
                    throw new ApplicationException("品詞に変換できない終端記号が指定されました。");
            }
        }

    }
}
