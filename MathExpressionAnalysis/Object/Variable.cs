using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 変数を扱うクラス。
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// 変数のデータ型。
        /// </summary>
        public DataType type { get; }
        private bool _valueBool;
        private long _valueInteger;
        private double _valueDecimal;
        /// <summary>
        /// 変数の値を取得する。
        /// </summary>
        /// <returns>変数の値。</returns>
        public MathTreeNodeValue getValue()
        {
            switch (this.type)
            {
                case DataType.Boolean:
                    return new MathTreeNodeValue(_valueBool);
                case DataType.Integer:
                    return new MathTreeNodeValue(_valueInteger);
                case DataType.Decimal:
                    return new MathTreeNodeValue(_valueDecimal);
                default:
                    throw new ApplicationException("変数の型として取りえない型が指定されました。");
            }
        }
        private Variable() { }
        public Variable(bool value)
        {
            this.type = DataType.Boolean;
            this._valueBool = value;
        }
        public Variable(long value)
        {
            this.type = DataType.Integer;
            this._valueInteger = value;
        }
        public Variable(double value)
        {
            this.type = DataType.Decimal;
            this._valueDecimal = value;
        }
    }
}
