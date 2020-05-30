using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class BinaryOperatorAdd : BinaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand)
        {
            if (leftOperand.type == DataType.Integer)
            {
                if (rightOperand.type == DataType.Integer)
                {
                    return new MathTreeNodeValue(leftOperand.valueInteger + rightOperand.valueInteger);
                }
                else if (rightOperand.type == DataType.Decimal)
                {
                    return new MathTreeNodeValue(leftOperand.valueInteger + rightOperand.valueDecimal);
                }
            }
            else if (rightOperand.type == DataType.Decimal)
            {
                if (rightOperand.type == DataType.Integer)
                {
                    return new MathTreeNodeValue(leftOperand.valueDecimal + rightOperand.valueInteger);
                }
                else if (rightOperand.type == DataType.Decimal)
                {
                    return new MathTreeNodeValue(leftOperand.valueDecimal + rightOperand.valueDecimal);
                }
            }
            throw new ArgumentException("加算演算子は整数または小数に対してのみ演算できます。");
        }

        public override DataType getDataType(DataType leftOperand, DataType rightOperand)
        {
            if (leftOperand == DataType.Integer && rightOperand == DataType.Integer)
            {
                return DataType.Integer;
            }
            else if ((leftOperand == DataType.Integer || leftOperand == DataType.Decimal) && (rightOperand == DataType.Integer || rightOperand == DataType.Decimal))
            {
                return DataType.Decimal;
            }
            return DataType.None;
        }

        public override string getRPolish()
        {
            return "+";
        }

        protected override int operatorPriority()
        {
            return 5;
        }
    }
}
