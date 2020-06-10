using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class BinaryOperatorPow : BinaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand)
        {
            double leftValue;
            if (leftOperand.type == DataType.Integer)
            {
                leftValue = leftOperand.valueInteger;
            }
            else if (leftOperand.type == DataType.Decimal)
            {
                leftValue = leftOperand.valueDecimal;
            }
            else
            {
                throw new ArgumentException("指数演算子は整数または小数に対してのみ演算できます。");
            }
            double rightValue;
            if (rightOperand.type == DataType.Integer)
            {
                rightValue = rightOperand.valueInteger;
            }
            else if (rightOperand.type == DataType.Decimal)
            {
                rightValue = rightOperand.valueDecimal;
            }
            else
            {
                throw new ArgumentException("指数演算子は整数または小数に対してのみ演算できます。");
            }
            return new MathTreeNodeValue(Math.Pow(leftValue, rightValue));
        }

        public override DataType getDataType(DataType leftOperand, DataType rightOperand)
        {
            if ((leftOperand == DataType.Integer || leftOperand == DataType.Decimal) && (rightOperand == DataType.Integer || rightOperand == DataType.Decimal))
            {
                return DataType.Decimal;
            }
            return DataType.None;
        }

        public override string getRPolish()
        {
            return "^";
        }

        protected override int operatorPriority()
        {
            return 7;
        }
    }
}
