using System;
using System.Collections.Generic;
using System.Text;
using MathExpressionAnalysis.Object.Lex;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 数式ツリーのノード
    /// </summary>
    public class MathTreeNode
    {
        public MathTreeNode()
        {
            master = null;
            lex = null;
            left = null;
            right = null;
        }
        /// <summary>
        /// このツリーのマスター。
        /// </summary>
        public MathTree master { get; set; }
        /// <summary>
        /// leafノードはリテラルを、それ以外は演算子を格納します。
        /// </summary>
        public Lexical lex { get; set; }
        /// <summary>
        /// 左子ノード。
        /// </summary>
        public MathTreeNode left { get; set; }
        /// <summary>
        /// 右子ノード。
        /// </summary>
        public MathTreeNode right { get; set; }
    }
}
