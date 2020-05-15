using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public class InputInfoIteratorEnd : InputInfoBase
    {
        public InputInfoIteratorEnd() : base(InputType.IteratorEnd)
        {
        }
        public override string makeDisplayText()
        {
            string text = "ループ終了";
            return text;
        }
    }
}
