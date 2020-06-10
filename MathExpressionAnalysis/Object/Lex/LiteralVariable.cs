using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis.Object.Lex
{
    public class LiteralVariable : Literal
    {
        public override MathTreeNodeValue eval(Dictionary<string, Variable> variableMap)
        {
            if (!variableMap.ContainsKey(this.value))
            {
                throw new ArgumentException("変数" + this.value + "が見つかりません。");
            }
            Variable variable = variableMap[this.value];
            return variable.getValue();
        }

        public override DataType getDataType(Dictionary<string, DataType> variableDataTypeMap)
        {
            if (!variableDataTypeMap.ContainsKey(this.value)) return DataType.None;
            DataType variableDataType = variableDataTypeMap[this.value];
            return variableDataType;
        }

        public override string getRPolish()
        {
            return "Var[" + this.value + "]";
        }
    }
}
