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
    public partial class FormEditLoop : Form
    {
        // 戻り値保存用のデータ
        InputInfoLoopStart inputInfoLoopStart = null;

        public FormEditLoop()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void rbDivisorInterCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtDivisorInterCustom.Enabled = rbDivisorInterCustom.Checked;
        }

        private void rbDivisorLastCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtDivisorLastCustom.Enabled = rbDivisorLastCustom.Checked;
        }

        public DialogResult ShowDialog(IWin32Window owner, out InputInfoBase inputInfo)
        {
            var dialogResult = this.ShowDialog(owner);
            if (dialogResult == DialogResult.OK && inputInfoLoopStart != null)
            {
                inputInfo = this.inputInfoLoopStart;
                return DialogResult.OK;
            }
            else
            {
                inputInfo = null;
                return DialogResult.Cancel;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            // バリデーション
            string validateMessage = "";
            if (!InputInfoUtil.validateIntegerMin(txtLoopMin.Text))
            {
                validateMessage += "ループ最小値に数値を入力してください。\r\n";
            }
            if (!InputInfoUtil.validateIntegerMax(txtLoopMax.Text))
            {
                validateMessage += "ループ最大値に数値を入力してください。\r\n";
            }
            if (!rbDivisorInterNewLine.Checked && !rbDivisorInterSpace.Checked &&
                    !rbDivisorInterEmpty.Checked && !rbDivisorInterCustom.Checked)
            {
                validateMessage += "区切り文字を指定してください。\r\n";
            }
            if (!rbDivisorLastNewLine.Checked && !rbDivisorLastSpace.Checked &&
                    !rbDivisorLastEmpty.Checked && !rbDivisorLastCustom.Checked)
            {
                validateMessage += "区切り文字を指定してください。\r\n";
            }

            if (validateMessage.Length > 0)
            {
                MessageBox.Show(validateMessage);
                return;
            }

            // 変換
            int loopMin, loopMax;
            if (!int.TryParse(txtLoopMin.Text, out loopMin)) return;
            if (!int.TryParse(txtLoopMax.Text, out loopMax)) return;
            string divisorInter = InputInfoUtil.getDivisor(rbDivisorInterNewLine.Checked, rbDivisorInterSpace.Checked, rbDivisorInterEmpty.Checked, rbDivisorInterCustom.Checked, txtDivisorInterCustom.Text);
            string divisorLast = InputInfoUtil.getDivisor(rbDivisorLastNewLine.Checked, rbDivisorLastSpace.Checked, rbDivisorLastEmpty.Checked, rbDivisorLastCustom.Checked, txtDivisorLastCustom.Text);

            // FormEditIntegerの戻り値設定
            var inputInfoLoopStart = new InputInfoLoopStart(loopMin, loopMax, divisorInter, divisorLast);
            this.inputInfoLoopStart = inputInfoLoopStart;

            // DialogResultの設定
            this.DialogResult = DialogResult.OK;

            // フォームを閉じる
            this.Close();

        }

    }
}
