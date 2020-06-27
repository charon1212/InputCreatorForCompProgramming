using MathExpressionAnalysis.Object;
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
    public partial class FormEditList : FormEditInputInfo
    {

        /// <summary>
        /// 入力項目のリスト
        /// </summary>
        List<string> inputValueList;
        public FormEditList()
        {
            InitializeComponent();
            inputValueList = new List<string>();
            this.DialogResult = DialogResult.Cancel;
        }

        private void rbDivisorCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtDivisorCustom.Enabled = rbDivisorCustom.Checked;
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text;
            if (item.Length == 0)
            {
                MessageBox.Show("項目を入力してください。");
                return;
            }
            inputValueList.Add(item);
            redrawList();
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxMain.SelectedIndex;
            if (index < 0) return;
            if (index >= inputValueList.Count) return;
            inputValueList.RemoveAt(index);
            redrawList();
        }

        private void redrawList()
        {
            listBoxMain.Items.Clear();
            listBoxMain.Items.AddRange(inputValueList.ToArray());
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // バリデーション
            string validateMessage = "";
            if (inputValueList.Count == 0)
            {
                validateMessage += "項目を1つ以上登録してください。\r\n";
            }
            if (!rbDivisorNewLine.Checked && !rbDivisorSpace.Checked &&
                    !rbDivisorEmpty.Checked && !rbDivisorCustom.Checked)
            {
                validateMessage += "区切り文字を指定してください。\r\n";
            }

            string name = txtName.Text;
            if (!InputInfoValidation.validateVariableName(name))
            {
                validateMessage += "名前に使用できない文字列が含まれているか、または名前の先頭が数値です。\r\n";
            } else if (variableNameList.Contains(name))
            {
                validateMessage += "この変数名はすでに使用されています。\r\n";
            }

            if (validateMessage.Length > 0)
            {
                MessageBox.Show(validateMessage);
                return;
            }

            // 変換
            string divisor = InputInfoLogic.getDivisor(rbDivisorNewLine.Checked, rbDivisorSpace.Checked, rbDivisorEmpty.Checked, rbDivisorCustom.Checked, txtDivisorCustom.Text);

            // FormEditIntegerの戻り値設定
            var inputInfoList = new InputInfoList(inputValueList, divisor);
            inputInfoList.name = name;
            this.inputInfo = inputInfoList;

            // DialogResultの設定
            this.DialogResult = DialogResult.OK;

            // フォームを閉じる
            this.Close();

        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox) textBox.SelectAll();
        }

        private void FormEditList_Load(object sender, EventArgs e)
        {

        }
    }
}
