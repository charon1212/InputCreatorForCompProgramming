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
        int loopCount = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnInteger_Click(object sender, EventArgs e)
        {
            InputInfoBase inputInfo = null;
            var formEditInteger = new FormEditInteger();

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

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditList.ShowDialog(this, out inputInfo);
            if(dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
            }
            showListInputInfo();
        }

        private void btnLoopStart_Click(object sender, EventArgs e)
        {
            InputInfoBase inputInfo = null;
            var formEditLoop = new FormEditLoop();

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditLoop.ShowDialog(this, out inputInfo);
            if (dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
                loopCount++;
            }
            showListInputInfo();
        }

        private void btnLoopLast_Click(object sender, EventArgs e)
        {
            if(loopCount <= 0)
            {
                MessageBox.Show("ループ開始を登録してください。");
                return;
            }
            InputInfoBase inputInfo = new InputInfoLoopEnd();
            listInputInfo.Add(inputInfo);
            loopCount--;
            showListInputInfo();
        }

        private void btnCreateInputData_Click(object sender, EventArgs e)
        {
            // ループの開始にループの終了が対応づくか調べる。
            if(loopCount != 0)
            {
                MessageBox.Show("ループの開始・終了が一致しません。");
                return;
            }
            txtOutput.Text = "";
            var rnd = new Random();
            var arg = new Dictionary<string, string>();
            foreach (InputInfoBase inputInfo in listInputInfo)
            {
                txtOutput.Text += InputInfoUtil.createInputInfo(inputInfo, rnd, arg);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listInputInfo = new List<InputInfoBase>();
            loopCount = 0;
        }

        private void showListInputInfo()
        {
            listBoxInputInfo.Items.Clear();
            foreach (InputInfoBase inputInfo in listInputInfo)
            {
                listBoxInputInfo.Items.Add(inputInfo.makeDisplayText());
            }
        }

    }
}
