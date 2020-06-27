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
    public partial class FormEditLoop : FormEditInputInfo
    {

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

        private void btnEnter_Click(object sender, EventArgs e)
        {

            // バリデーション
            string validateMessage = "";

            // 数式をツリーに変換。
            MathTree treeLoopMin = new MathTree();
            MathTree treeLoopMax = new MathTree();
            try
            {
                treeLoopMin = MathExpressionAnalysisLogic.getMathTreeFromString(txtLoopMin.Text);
                if (!InputInfoValidation.validateMathTreeDataType(treeLoopMin, DataType.Integer, this.availableVariableMap))
                {
                    validateMessage += "最小値の評価結果が整数になりません。\r\n";
                }
            }
            catch (ArgumentException argEx)
            {
                validateMessage += "最小値を数式に変換できませんでした。\r\n" + "エラーメッセージ：" + argEx.Message + "\r\n";
            }
            try
            {
                treeLoopMax = MathExpressionAnalysisLogic.getMathTreeFromString(txtLoopMax.Text);
                if (!InputInfoValidation.validateMathTreeDataType(treeLoopMax, DataType.Integer, this.availableVariableMap))
                {
                    validateMessage += "最大値の評価結果が整数になりません。\r\n";
                }
            }
            catch (ArgumentException argEx)
            {
                validateMessage += "最大値を数式に変換できませんでした。\r\n" + "エラーメッセージ：" + argEx.Message + "\r\n";
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

            string name = txtName.Text;
            if (!InputInfoValidation.validateVariableName(name))
            {
                validateMessage += "名前に使用できない文字列が含まれているか、または名前の先頭が数値です。\r\n";
            }
            else if (variableNameList.Contains(name))
            {
                validateMessage += "この変数名はすでに使用されています。\r\n";
            }

            if (validateMessage.Length > 0)
            {
                MessageBox.Show(validateMessage);
                return;
            }

            // 変換
            string divisorInter = InputInfoLogic.getDivisor(rbDivisorInterNewLine.Checked, rbDivisorInterSpace.Checked, rbDivisorInterEmpty.Checked, rbDivisorInterCustom.Checked, txtDivisorInterCustom.Text);
            string divisorLast = InputInfoLogic.getDivisor(rbDivisorLastNewLine.Checked, rbDivisorLastSpace.Checked, rbDivisorLastEmpty.Checked, rbDivisorLastCustom.Checked, txtDivisorLastCustom.Text);

            // FormEditIntegerの戻り値設定
            var inputInfoLoopStart = new InputInfoLoopStart(treeLoopMin, treeLoopMax, txtLoopMin.Text, txtLoopMax.Text, divisorInter, divisorLast);
            inputInfoLoopStart.name = name;
            this.inputInfo = inputInfoLoopStart;

            // DialogResultの設定
            this.DialogResult = DialogResult.OK;

            // フォームを閉じる
            this.Close();

        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox) textBox.SelectAll();
        }

    }
}
