using MathExpressionAnalysis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public class InputInfoLoopEnd : InputInfoBase
    {
        public InputInfoLoopEnd()
        {
        }
        public override string makeDisplayText()
        {
            string text = "ループ終了";
            return text;
        }
        public override string createInputData(Random rnd, ref Dictionary<string, Variable> arg)
        {
            return "";
        }
    }
}
