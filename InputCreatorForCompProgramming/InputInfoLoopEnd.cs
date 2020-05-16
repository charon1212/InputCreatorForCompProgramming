using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public class InputInfoLoopEnd : InputInfoBase
    {
        public InputInfoLoopEnd() : base(InputType.LoopEnd)
        {
        }
        public override string makeDisplayText()
        {
            string text = "ループ終了";
            return text;
        }
    }
}
