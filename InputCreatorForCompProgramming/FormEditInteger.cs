﻿using MathExpressionAnalysis;
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

            // 数式をツリーに変換。
            MathTree treeMin = new MathTree();
            MathTree treeMax = new MathTree();
            try
            {
                treeMin = MathExpressionAnalysisLogic.getMathTreeFromString(txtMin.Text);
                if (!InputInfoLogic.validateMathTreeDataType(treeMin, DataType.Integer))
                {
                    validateMessage += "最小値の評価結果が整数になりません。\r\n";
                }
            } catch (ArgumentException argEx)
            {
                validateMessage += "最小値を数式に変換できませんでした。\r\n" + "エラーメッセージ：" + argEx.Message + "\r\n";
            }
            try
            {
                treeMax = MathExpressionAnalysisLogic.getMathTreeFromString(txtMax.Text);
                if (!InputInfoLogic.validateMathTreeDataType(treeMax, DataType.Integer))
                {
                    validateMessage += "最大値の評価結果が整数になりません。\r\n";
                }
            }
            catch (ArgumentException argEx)
            {
                validateMessage += "最小値を数式に変換できませんでした。\r\n" + "エラーメッセージ：" + argEx.Message + "\r\n";
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
            string divisor = InputInfoLogic.getDivisor(rbDivisorNewLine.Checked, rbDivisorSpace.Checked, rbDivisorEmpty.Checked, rbDivisorCustom.Checked, txtDivisorCustom.Text);

            // FormEditIntegerの戻り値設定
            var inputinfoInteger = new InputInfoInteger(treeMin, treeMax, divisor);
            this.inputInfoInteger = inputinfoInteger;

            // DialogResultの設定
            this.DialogResult = DialogResult.OK;

            // フォームを閉じる
            this.Close();

        }
    }
}
