using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCreatorForCompProgramming
{
    public partial class FormEditInteger : Form
    {

        // 戻り値保存用のデータ
        InputInfoInteger inputInfoInteger = null;

        public FormEditInteger()
        {
            InitializeComponent();
        }

        private void rbDivisorCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtDivisorCustom.Enabled = rbDivisorCustom.Checked;
        }

        public DialogResult ShowDialog(IWin32Window owner, out InputInfoBase inputInfo)
        {
            var dialogResult = this.ShowDialog(owner);
            if (dialogResult == DialogResult.OK && inputInfoInteger != null)
            {
                inputInfo = this.inputInfoInteger;
                return DialogResult.OK;
            } else
            {
                inputInfo = null;
                return DialogResult.Cancel;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // バリデーション
            string validateMessage = "";
            if (!InputInfoLogic.validateIntegerMin(txtMin.Text))
            {
                validateMessage += "最小値に数値を入力してください。\r\n";
            }
            if (!InputInfoLogic.validateIntegerMax(txtMax.Text))
            {
                validateMessage += "最大値に数値を入力してください。\r\n";
            }
            if(!rbDivisorNewLine.Checked && !rbDivisorSpace.Checked &&
                    !rbDivisorEmpty.Checked && !rbDivisorCustom.Checked){
                validateMessage += "区切り文字を指定してください。\r\n";
            }
            
            if(validateMessage.Length > 0)
            {
                MessageBox.Show(validateMessage);
                return;
            }

            // 変換
            long min, max;
            if(!long.TryParse(txtMin.Text, out min)) return;
            if(!long.TryParse(txtMax.Text, out max)) return;
            string divisor = InputInfoLogic.getDivisor(rbDivisorNewLine.Checked, rbDivisorSpace.Checked, rbDivisorEmpty.Checked, rbDivisorCustom.Checked, txtDivisorCustom.Text);

            // FormEditIntegerの戻り値設定
            var inputinfoInteger = new InputInfoInteger(min, max, divisor);
            this.inputInfoInteger = inputinfoInteger;

            // DialogResultの設定
            this.DialogResult = DialogResult.OK;

            // フォームを閉じる
            this.Close();

        }
    }
}
