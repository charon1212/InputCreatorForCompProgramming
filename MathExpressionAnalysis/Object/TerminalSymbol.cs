using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 終端記号
    /// </summary>
    public class TerminalSymbol
    {
        /// <summary>
        /// 終端記号の実際の文字列
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 終端記号の種類
        /// </summary>
        public TerminalSymbolType type { get; set; }
        public TerminalSymbol() {
        }
        public TerminalSymbol(string value, TerminalSymbolType type)
        {
            this.value = value;
            this.type = type;
        }
    }

    /// <summary>
    /// 終端記号の種類。
    /// </summary>
    public enum TerminalSymbolType
    {
        None,
        Integer,
        Decimal,
        LogicTrue, // false
        LogicFalse, // true
        Variable,
        OpAdd,    // +
        OpDiff,   // -
        OpProd,  // *
        OpDivide, // /
        OpMod,    // %
        OpPow,    // ^
        OpNeg,    // -
        OpLt,     // <
        OpLtEq,   // <=
        OpGt,     // >
        OpGtEq,   // >=
        OpEq,     // ==
        OpNotEq,  // !=
        OpNot,    // !
        OpAnd,    // &&
        OpOr,     // ||
        Function,     // Function
        Comma,    // ,
        LeftP,    // Left Parenthesis
        RightP,   // Right Parenthesis
    }

}
