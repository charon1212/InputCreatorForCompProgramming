using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 数式ツリーの各ノードの評価後の値を保存するクラス。
    /// </summary>
    public class MathTreeNodeValue
    {
        /// <summary>
        /// ノード評価値のデータ型。
        /// </summary>
        public DataType type { get; }
        private bool _valueBool;
        public bool valueBool
        {
            get
            {
                if (this.type == DataType.Boolean)
                {
                    return this._valueBool;
                }
                else
                {
                    throw new ApplicationException("異なるデータ型のノード評価値を取得することはできません。");
                }
            }
            private set
            {
                this._valueBool = value;
            }
        }
        private long _valueInteger;
        public long valueInteger
        {
            get
            {
                if (this.type == DataType.Integer)
                {
                    return this._valueInteger;
                }
                else
                {
                    throw new ApplicationException("異なるデータ型のノード評価値を取得することはできません。");
                }
            }
            private set
            {
                this._valueInteger = value;
            }
        }
        private double _valueDecimal;
        public double valueDecimal
        {
            get
            {
                if (this.type == DataType.Decimal)
                {
                    return this._valueDecimal;
                }
                else
                {
                    throw new ApplicationException("異なるデータ型のノード評価値を取得することはできません。");
                }
            }
            private set
            {
                this._valueDecimal = value;
            }
        }
        private List<double> _valueDecimalList;
        public List<double> valueDecimalList
        {
            get
            {
                if (this.type == DataType.DecimalList)
                {
                    return this._valueDecimalList;
                }
                else
                {
                    throw new ApplicationException("異なるデータ型のノード評価値を取得することはできません。");
                }
            }
            private set
            {
                this._valueDecimalList = value;
            }
        }
        private MathTreeNodeValue() { }
        public MathTreeNodeValue(bool value)
        {
            this.type = DataType.Boolean;
            this.valueBool = value;
        }
        public MathTreeNodeValue(long value)
        {
            this.type = DataType.Integer;
            this.valueInteger = value;
        }
        public MathTreeNodeValue(double value)
        {
            this.type = DataType.Decimal;
            this.valueDecimal = value;
        }
        public MathTreeNodeValue(List<double> value)
        {
            this.type = DataType.DecimalList;
            this.valueDecimalList = value;
        }
    }

}
