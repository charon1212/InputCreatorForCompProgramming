using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    /// <summary>
    /// 演算子の基底クラス。
    /// </summary>
    public abstract class Operator : Lexical
    {
        /// <summary>
        /// 演算子の優先順位の最大値+1
        /// </summary>
        private static readonly int MAX_OPERATOR_PRIORITY_PLUS_ONE = 10;
        /// <summary>
        /// 演算子の()の深さ。もっとも外側は0。
        /// </summary>
        public int parenthesisDepth { get; set; }
        /// <summary>
        /// 演算子固有の優先順位。
        /// </summary>
        /// <returns></returns>
        protected abstract int operatorPriority();
        /// <summary>
        /// 演算子の優先順位を取得する。
        /// </summary>
        /// <returns>演算子の優先順位。</returns>
        public int getPriority()
        {
            return parenthesisDepth * MAX_OPERATOR_PRIORITY_PLUS_ONE + operatorPriority();
        }
    }
}
