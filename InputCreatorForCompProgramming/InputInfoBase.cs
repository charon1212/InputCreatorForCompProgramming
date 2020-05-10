using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    abstract public class InputInfoBase
    {
        public string name { get; set; }
        public InputType inputType { get; }
        public InputInfoBase(InputType inputType)
        {
            name = "";
            this.inputType = inputType;
        }

        /// <summary>
        /// InputInfoの設定をユーザーに伝える文字列を作成します。
        /// </summary>
        abstract public string makeDisplayText();
    }

    public enum InputType
    {
        None,
        Integer,
    }
}
