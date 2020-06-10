using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 関数を扱うクラス。
    /// </summary>
    public class Function
    {
        /// <summary>
        /// 戻り値のデータ型
        /// </summary>
        public DataType returnDataType { get; }
        private Func<List<double>, bool> _funcBool;
        private Func<List<double>, long> _funcInteger;
        private Func<List<double>, double> _funcDecimal;
        /// <summary>
        /// 関数を評価する。
        /// </summary>
        /// <param name="operand">関数の引数。</param>
        /// <returns>関数を評価した値。</returns>
        public MathTreeNodeValue eval(List<double> operand)
        {
            switch (this.returnDataType)
            {
                case DataType.Boolean:
                    return new MathTreeNodeValue(_funcBool(operand));
                case DataType.Integer:
                    return new MathTreeNodeValue(_funcInteger(operand));
                case DataType.Decimal:
                    return new MathTreeNodeValue(_funcDecimal(operand));
                default:
                    throw new ApplicationException("関数の戻り値の型として取りえない型が指定されました。");
            }
        }
        private Function() { }
        public Function(Func<List<double>, bool> funcBool)
        {
            this.returnDataType = DataType.Boolean;
            this._funcBool = funcBool;
        }
        public Function(Func<List<double>, long> funcInteger)
        {
            this.returnDataType = DataType.Integer;
            this._funcInteger = funcInteger;
        }
        public Function(Func<List<double>, double> funcDecimal)
        {
            this.returnDataType = DataType.Decimal;
            this._funcDecimal = funcDecimal;
        }
    }
}
