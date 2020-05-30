using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    /// <summary>
    /// リテラルを扱う基底クラス。
    /// </summary>
    public abstract class Literal : Lexical
    {
        /// <summary>
        /// リテラル値の文字列表現
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// リテラルのデータ型を取得する。
        /// </summary>
        /// <param name="variableDataTypeMap">変数の名前とデータ型の連想配列。</param>
        /// <returns>リテラルのデータ型。</returns>
        public abstract DataType getDataType(Dictionary<string, DataType> variableDataTypeMap);
        /// <summary>
        /// リテラル値を評価する。
        /// </summary>
        /// <param name="variableMap">変数の連想配列。キーは変数名を指定する。</param>
        /// <returns>リテラルの評価値</returns>
        public abstract MathTreeNodeValue eval(Dictionary<string, Variable> variableMap);
    }
}
