using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class LiteralTrue : Literal
    {
        public override MathTreeNodeValue eval(Dictionary<string, Variable> variableMap)
        {
            return new MathTreeNodeValue(true);
        }

        public override DataType getDataType(Dictionary<string, DataType> variableDataTypeMap)
        {
            return DataType.Boolean;
        }

        public override string getRPolish()
        {
            return "true";
        }
    }
}
