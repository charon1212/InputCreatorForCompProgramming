using MathExpressionAnalysis.Object;
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
        public InputInfoBase()
        {
            name = "";
        }

        /// <summary>
        /// InputInfoの設定をユーザーに伝える文字列を作成します。
        /// </summary>
        abstract public string makeDisplayText();
        /// <summary>
        /// 入力データを作成して文字列で出力する。
        /// </summary>
        /// <param name="rnd">乱数生成器を指定する。</param>
        /// <param name="arg">引数のリストを指定する。</param>
        /// <returns>入力データの文字列表現。分割文字列も含む。</returns>
        abstract public string createInputData(Random rnd, ref Dictionary<string, Variable> arg);

    }
}
