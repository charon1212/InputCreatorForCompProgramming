using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MathExpressionAnalysis.Object
{
    /// <summary>
    /// 数式ツリー
    /// </summary>
    public class MathTree
    {
        /// <summary>
        /// ルートノード。
        /// </summary>
        public MathTreeNode root { get; set; }

        public MathTreeNodeValue eval(Dictionary<string, Variable> variableMap = null, Dictionary<string, Function> functionMap = null)
        {
            return MathExpressionAnalysisLogic.eval(this, variableMap, functionMap);
        }
        public DataType checkDataType(Dictionary<string, DataType> variableDataTypeMap = null,
            Dictionary<string, DataType> functionDataTypeMap = null)
        {
            return MathExpressionAnalysisLogic.checkDataType(this, variableDataTypeMap, functionDataTypeMap);
        }
        public DataType checkDataType(Dictionary<string, Variable> variableMap,
            Dictionary<string, Function> functionMap)
        {
            return MathExpressionAnalysisLogic.checkDataType(this, variableMap, functionMap);
        }
    }
}
