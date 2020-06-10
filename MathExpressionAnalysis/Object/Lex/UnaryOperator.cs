using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    /// <summary>
    /// 単項演算子の基底クラス。
    /// </summary>
    public abstract class UnaryOperator : Operator
    {
        /// <summary>
        /// 演算結果のデータ型を取得する。
        /// </summary>
        /// <param name="operand">オペランドのデータ型</param>
        /// <param name="functionReturnValue">関数の名前とデータ型の連想配列。</param>
        /// <returns>演算結果のデータ型。</returns>
        public abstract DataType getDataType(DataType operand, Dictionary<string, DataType> functionReturnValue);
        /// <summary>
        /// 演算結果を評価する。
        /// </summary>
        /// <param name="operand">オペランドの値</param>
        /// <param name="functionMap">関数の連想配列。</param>
        /// <returns>演算後の評価値。</returns>
        public abstract MathTreeNodeValue eval(MathTreeNodeValue operand, Dictionary<string, Function> functionMap);
    }
}
