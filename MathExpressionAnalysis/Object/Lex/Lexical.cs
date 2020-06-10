using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public abstract class Lexical
    {
        /// <summary>
        /// 品詞の逆ポーランド記法表現を取得する。
        /// </summary>
        /// <returns>品詞の逆ポーランド記法表現</returns>
        public abstract string getRPolish();
    }
}
