using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class UnaryOperatorFunction : UnaryOperator
    {
        public string functionName { get; set; }
        public override MathTreeNodeValue eval(MathTreeNodeValue operand, Dictionary<string, Function> functionMap)
        {
            var arguments = new List<double>();
            if (operand.type == DataType.Integer)
            {
                arguments.Add(operand.valueInteger);
            }
            else if (operand.type == DataType.Decimal)
            {
                arguments.Add(operand.valueDecimal);
            }
            else if (operand.type == DataType.DecimalList)
            {
                arguments.AddRange(operand.valueDecimalList);
            }
            else
            {
                throw new ArgumentException("関数の引数は整数、小数、小数リストのいずれかである必要があります。");
            }
            Function function = functionMap[this.functionName];
            return function.eval(arguments);
        }
        public override DataType getDataType(DataType operand, Dictionary<string, DataType> functionReturnValue)
        {
            if (operand == DataType.Integer || operand == DataType.Decimal || operand == DataType.DecimalList)
            {
                return functionReturnValue[this.functionName];
            }
            else
            {
                return DataType.None;
            }
        }
        public override string getRPolish()
        {
            return "Func[" + this.functionName + "]";
        }
        protected override int operatorPriority()
        {
            return 9;
        }
        public UnaryOperatorFunction(string functionName) : base()
        {
            this.functionName = functionName;
        }
    }
}
