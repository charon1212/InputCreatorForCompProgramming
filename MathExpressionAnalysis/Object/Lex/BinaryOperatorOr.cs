using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class BinaryOperatorOr : BinaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand)
        {
            if (leftOperand.type == DataType.Boolean && rightOperand.type == DataType.Boolean)
            {
                return new MathTreeNodeValue(leftOperand.valueBool || rightOperand.valueBool);
            }
            throw new ArgumentException("OR演算子は論理値に対してのみ演算できます。");
        }

        public override DataType getDataType(DataType leftOperand, DataType rightOperand)
        {
            if (leftOperand == DataType.Boolean && rightOperand == DataType.Boolean) return DataType.Boolean;
            return DataType.None;
        }

        public override string getRPolish()
        {
            return "||";
        }

        protected override int operatorPriority()
        {
            return 2;
        }
    }
}
