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
    public partial class FormMain : Form
    {

        // 入力データの情報
        List<InputInfoBase> listInputInfo;
        // 入力データの情報のうち、現在のループ深さカウント
        int loopDepth = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnInteger_Click(object sender, EventArgs e)
        {
            InputInfoBase inputInfo = null;
            var formEditInteger = new FormEditInteger();
            formEditInteger.variableNameList = this.getVariableNameList();

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditInteger.ShowDialog(this, out inputInfo);

            if (dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
            }
            showListInputInfo();

        }
        private void btnList_Click(object sender, EventArgs e)
        {
            InputInfoBase inputInfo = null;
            var formEditList = new FormEditList();
            formEditList.variableNameList = this.getVariableNameList();

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditList.ShowDialog(this, out inputInfo);
            if (dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
            }
            showListInputInfo();
        }

        private void btnLoopStart_Click(object sender, EventArgs e)
        {
            InputInfoBase inputInfo = null;
            var formEditLoop = new FormEditLoop();
            formEditLoop.variableNameList = this.getVariableNameList();

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditLoop.ShowDialog(this, out inputInfo);
            if (dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
                loopDepth++;
            }
            showListInputInfo();
        }

        private void btnLoopLast_Click(object sender, EventArgs e)
        {
            if (loopDepth <= 0)
            {
                MessageBox.Show("ループ開始を登録してください。");
                return;
            }
            InputInfoBase inputInfo = new InputInfoLoopEnd();
            listInputInfo.Add(inputInfo);
            loopDepth--;
            showListInputInfo();
        }

        private void btnCreateInputData_Click(object sender, EventArgs e)
        {
            // ループの開始にループの終了が対応づくか調べる。
            if (loopDepth != 0)
            {
                MessageBox.Show("ループの開始・終了が一致しません。");
                return;
            }
            var rnd = new Random();
            txtOutput.Text = InputInfoLogic.createInputInfo(listInputInfo, rnd);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listInputInfo = new List<InputInfoBase>();
            loopDepth = 0;
        }

        private void showListInputInfo()
        {
            listBoxInputInfo.Items.Clear();
            int loopDepth = 0;
            foreach (InputInfoBase inputInfo in listInputInfo)
            {
                if (inputInfo is InputInfoLoopEnd) loopDepth--;
                listBoxInputInfo.Items.Add(makeIndent(loopDepth) + inputInfo.makeDisplayText());
                if (inputInfo is InputInfoLoopStart) loopDepth++;
            }
        }

        private string makeIndent(int loopDepth)
        {
            string indent = "";
            for (int i = 0; i < loopDepth; i++) indent += "  ";
            return indent;
        }

        private List<string> getVariableNameList()
        {
            var variableNameList = new List<string>();
            foreach (InputInfoBase inputInfo in listInputInfo) variableNameList.Add(inputInfo.name);
            return variableNameList;
        }

    }
}
