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

        #region "入力データ情報新規作成"

        /// <summary>
        /// 入力データ情報登録フォームに必要な情報を渡して入力データ情報を作成する。
        /// 作成に成功した場合はメインフォームのリストに登録する。
        /// </summary>
        /// <param name="formEditInputInfo">入力データ情報登録フォーム。</param>
        private void btnNewInputInfo_Click(FormEditInputInfo formEditInputInfo)
        {

            InputInfoBase inputInfo = null;
            formEditInputInfo.variableNameList = this.getVariableNameList();
            formEditInputInfo.availableVariableMap = this.getAvailableVariableMap();

            // フォームを開いて結果を受け取る
            DialogResult dialogResult = formEditInputInfo.ShowDialog(this, out inputInfo);
            if (dialogResult == DialogResult.OK && inputInfo != null)
            {
                listInputInfo.Add(inputInfo);
                if (inputInfo.GetType() == typeof(InputInfoLoopStart))
                {
                    loopDepth++;
                }
            }
            showListInputInfo();

        }

        /// <summary>
        /// 現在利用しているすべての変数名のリストを取得する。
        /// </summary>
        /// <returns>変数名のリスト</returns>
        private List<string> getVariableNameList()
        {
            var variableNameList = new List<string>();
            foreach (InputInfoBase inputInfo in listInputInfo) variableNameList.Add(inputInfo.name);
            return variableNameList;
        }

        /// <summary>
        /// 次の入力データ情報で利用可能な変数の連想配列を取得する。
        /// キーは変数名で、値はデータ型である。
        /// </summary>
        /// <returns>利用可能な変数の連想配列。</returns>
        private Dictionary<string, DataType> getAvailableVariableMap()
        {

            // まず、ループの深さ毎の変数データ型リストを作成していく。
            // その中で、ループの終了点を迎えた変数たちは削除する。
            var variableListByLoopDepth = new List<List<Tuple<string, DataType>>>();
            variableListByLoopDepth.Add(new List<Tuple<string, DataType>>()); //1層目を入力。
            int loopDepth = 0;
            foreach (InputInfoBase inputInfo in listInputInfo)
            {
                if (inputInfo.GetType() == typeof(InputInfoInteger))
                {
                    variableListByLoopDepth[loopDepth].Add(new Tuple<string, DataType>(inputInfo.name, DataType.Integer));
                }
                else if (inputInfo.GetType() == typeof(InputInfoLoopStart))
                {
                    variableListByLoopDepth[loopDepth].Add(new Tuple<string, DataType>(inputInfo.name, DataType.Integer));
                    variableListByLoopDepth.Add(new List<Tuple<string, DataType>>());
                    loopDepth++;
                }
                else if (inputInfo.GetType() == typeof(InputInfoLoopEnd))
                {
                    variableListByLoopDepth.RemoveAt(loopDepth);
                    loopDepth--;
                    if(loopDepth < 0)
                    {
                        throw new ApplicationException("入力データ情報の状態が異常です。対応するループ開始点が存在しないループ終了点があります。");
                    }
                }
            }

            var variableMap = new Dictionary<string, DataType>();
            foreach(List<Tuple<string,DataType>> variableList in variableListByLoopDepth)
            {
                foreach(Tuple<string,DataType> variable in variableList)
                {
                    variableMap.Add(variable.Item1, variable.Item2);
                }
            }

            return variableMap;

        }

        private void btnInteger_Click(object sender, EventArgs e)
        {
            btnNewInputInfo_Click(new FormEditInteger());
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            btnNewInputInfo_Click(new FormEditList());
        }

        private void btnLoopStart_Click(object sender, EventArgs e)
        {
            btnNewInputInfo_Click(new FormEditLoop());
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

        #endregion

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

    }
}
