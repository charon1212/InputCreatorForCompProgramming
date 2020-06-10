using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class BinaryOperatorComma : BinaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand)
        {
            var list = new List<double>();
            if (leftOperand.type == DataType.Integer)
            {
                list.Add(leftOperand.valueInteger);
            }
            else if (leftOperand.type == DataType.Decimal)
            {
                list.Add(leftOperand.valueDecimal);
            }
            else if (leftOperand.type == DataType.DecimalList)
            {
                list.AddRange(leftOperand.valueDecimalList);
            }
            else
            {
                throw new ArgumentException("カンマ演算子は整数、小数、小数リストに対してのみ演算できます。");
            }
            if (rightOperand.type == DataType.Integer)
            {
                list.Add(rightOperand.valueInteger);
            }
            else if (rightOperand.type == DataType.Decimal)
            {
                list.Add(rightOperand.valueDecimal);
            }
            else if (rightOperand.type == DataType.DecimalList)
            {
                list.AddRange(rightOperand.valueDecimalList);
            }
            else
            {
                throw new ArgumentException("カンマ演算子は整数、小数、小数リストに対してのみ演算できます。");
            }
            return new MathTreeNodeValue(list);
        }

        public override DataType getDataType(DataType leftOperand, DataType rightOperand)
        {
            if ((leftOperand == DataType.Integer || leftOperand == DataType.Decimal || leftOperand == DataType.DecimalList) &&
                (rightOperand == DataType.Integer || rightOperand == DataType.Decimal || rightOperand == DataType.DecimalList))
            {
                return DataType.DecimalList;
            }
            return DataType.None;
        }

        public override string getRPolish()
        {
            return ",";
        }

        protected override int operatorPriority()
        {
            return 1;
        }
    }
}
