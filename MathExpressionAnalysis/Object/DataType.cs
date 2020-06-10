using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 数式のデータ型。
    /// </summary>
    public enum DataType
    {
        None,
        Boolean, // true/false
        Integer, // 整数
        Decimal, // 小数
        DecimalList, // 小数のリスト
    }

    /// <summary>
    /// 数式データ型の拡張クラス。
    /// </summary>
    public static class DataTypeExtend
    {
        public static string toString(this DataType dataType)
        {
            switch (dataType)
            {
                case DataType.None:
                    return null;
                case DataType.Boolean:
                    return "論理値";
                case DataType.Integer:
                    return "整数";
                case DataType.Decimal:
                    return "小数";
                case DataType.DecimalList:
                    return "小数リスト";
                default:
                    throw new ApplicationException("データ型 + " + dataType.ToString() + "は存在しません。");
            }
        }
    }

}
