using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCreatorForCompProgramming
{
    public class FormEditInputInfo:Form
    {

        /// <summary>
        /// 戻り値の入力情報を格納する変数。
        /// </summary>
        protected InputInfoBase inputInfo = null;
        // 変数名のリスト
        public List<string> variableNameList { protected get; set; }

        public DialogResult ShowDialog(IWin32Window owner, out InputInfoBase inputInfo)
        {
            var dialogResult = this.ShowDialog(owner);
            if (dialogResult == DialogResult.OK && this.inputInfo != null)
            {
                inputInfo = this.inputInfo;
                return DialogResult.OK;
            }
            else
            {
                inputInfo = null;
                return DialogResult.Cancel;
            }
        }

    }
}
