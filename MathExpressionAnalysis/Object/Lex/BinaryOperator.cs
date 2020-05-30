using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public abstract class BinaryOperator : Operator
    {
        /// <summary>
        /// 演算結果のデータ型を取得する。
        /// 引数エラーの場合、DataType.Noneを返却する。
        /// </summary>
        /// <param name="leftOperand">演算子の左側の値のデータ型。</param>
        /// <param name="rightOperand">演算子の右側の値のデータ型。</param>
        /// <returns>演算結果の評価値のデータ型。</returns>
        public abstract DataType getDataType(DataType leftOperand, DataType rightOperand);
        /// <summary>
        /// 演算結果を評価する。
        /// </summary>
        /// <param name="leftOperand">演算子の左側の評価値。</param>
        /// <param name="rightOperand">演算子の右側の評価値。</param>
        /// <returns>演算結果の評価値。</returns>
        public abstract MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand);
    }
}
