using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class UnaryOperatorNegative : UnaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue operand, Dictionary<string, Function> functionMap)
        {
            if (operand.type == DataType.Integer)
            {
                return new MathTreeNodeValue(-operand.valueInteger);
            }
            else if (operand.type == DataType.Decimal)
            {
                return new MathTreeNodeValue(-operand.valueDecimal);
            }
            else
            {
                throw new ArgumentException("負数演算子は整数または小数に対してのみ演算できます。");
            }
        }
        public override DataType getDataType(DataType operand, Dictionary<string, DataType> functionReturnValue)
        {
            if (operand == DataType.Integer)
            {
                return DataType.Integer;
            }
            else if (operand == DataType.Decimal)
            {
                return DataType.Decimal;
            }
            return DataType.None;
        }
        public override string getRPolish()
        {
            return "-";
        }
        protected override int operatorPriority()
        {
            return 8;
        }
    }
}
