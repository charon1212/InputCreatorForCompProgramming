using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class LiteralInteger : Literal
    {
        public override MathTreeNodeValue eval(Dictionary<string, Variable> variableMap)
        {
            long valueInt = Int64.Parse(this.value);
            return new MathTreeNodeValue(valueInt);
        }
        public override DataType getDataType(Dictionary<string, DataType> variableDataTypeMap)
        {
            return DataType.Integer;
        }
        public override string getRPolish()
        {
            return "Int[" + this.value + "]";
        }
    }
}
