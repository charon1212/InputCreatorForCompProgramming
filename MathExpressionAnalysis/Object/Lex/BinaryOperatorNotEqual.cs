using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class BinaryOperatorNotEqual : BinaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue leftOperand, MathTreeNodeValue rightOperand)
        {
            if (leftOperand.type == DataType.Integer && rightOperand.type == DataType.Integer)
            {
                return new MathTreeNodeValue(leftOperand.valueInteger != rightOperand.valueInteger);
            }
            else if (leftOperand.type == DataType.Boolean && rightOperand.type == DataType.Boolean)
            {
                return new MathTreeNodeValue(leftOperand.valueBool != rightOperand.valueBool);
            }
            throw new ArgumentException("不等価演算子は整数と整数または論理値と論理値に対してのみ演算できます。");
        }

        public override DataType getDataType(DataType leftOperand, DataType rightOperand)
        {
            if (leftOperand == DataType.Integer && rightOperand == DataType.Integer) return DataType.Boolean;
            if (leftOperand == DataType.Boolean && rightOperand == DataType.Boolean) return DataType.Boolean;
            return DataType.None;
        }

        public override string getRPolish()
        {
            return "!=";
        }

        protected override int operatorPriority()
        {
            return 3;
        }
    }
}
