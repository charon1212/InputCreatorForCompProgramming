using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class UnaryOperatorNot : UnaryOperator
    {
        public override MathTreeNodeValue eval(MathTreeNodeValue operand, Dictionary<string, Function> functionMap)
        {
            if (operand.type == DataType.Boolean)
            {
                return new MathTreeNodeValue(!operand.valueBool);
            }
            else
            {
                throw new ArgumentException("否定演算子は論理値に対してのみ演算できます。");
            }
        }
        public override DataType getDataType(DataType operand, Dictionary<string, DataType> functionReturnValue)
        {
            if (operand == DataType.Boolean)
            {
                return DataType.Boolean;
            }
            return DataType.None;
        }
        public override string getRPolish()
        {
            return "!";
        }
        protected override int operatorPriority()
        {
            return 8;
        }
    }
}
