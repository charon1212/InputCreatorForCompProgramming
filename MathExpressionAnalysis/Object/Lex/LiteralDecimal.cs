using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class LiteralDecimal : Literal
    {
        public override MathTreeNodeValue eval(Dictionary<string, Variable> variableMap)
        {
            double valueDouble = Double.Parse(this.value);
            return new MathTreeNodeValue(valueDouble);
        }
        public override DataType getDataType(Dictionary<string, DataType> variableDataTypeMap)
        {
            return DataType.Decimal;
        }
        public override string getRPolish()
        {
            return "Dec[" + this.value + "]";
        }
    }
}
