using MathExpressionAnalysis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public static class InputInfoLogic
    {
        // 区切り文字：半角スペース
        public const string DIVISOR_SPACE = " ";
        // 区切り文字：改行
        public const string DIVISOR_NEWLINE = "\r\n";
        // 区切り文字；なし
        public const string DIVISOR_EMPTY = "";
        /// <summary>
        /// 区切り文字を取得する
        /// </summary>
        /// <param name="divisorIsNewLine">区切り文字として改行を使用する場合はtrue。</param>
        /// <param name="divisorIsSpace">区切り文字として半角スペースを使用する場合はtrue。</param>
        /// <param name="divisorIsEmpty">区切り文字としてから文字列を使用する場合はtrue。</param>
        /// <param name="divisorIsCustom">区切り文字をユーザーがカスタマイズする場合はtrue。</param>
        /// <param name="divisorCustom">区切り文字をユーザーがカスタマイズする場合、ユーザーが指定した区切り文字を指定。</param>
        /// <returns>区切り文字を文字列で返却する。</returns>
        /// <remarks>divisorIsNewLine,divisorIsSpace,divisorEmpty,divisorIsCustomのいずれかはtrueとしてください。
        /// 複数trueが指定された場合は、この順で左から優先します。</remarks>
        public static string getDivisor(bool divisorIsNewLine, bool divisorIsSpace, bool divisorIsEmpty, bool divisorIsCustom, string divisorCustom)
        {
            if (divisorIsNewLine)
            {
                return DIVISOR_NEWLINE;
            }
            else if (divisorIsSpace)
            {
                return DIVISOR_SPACE;
            }
            else if (divisorIsEmpty)
            {
                return DIVISOR_EMPTY;
            }
            else if (divisorIsCustom)
            {
                return divisorCustom;
            }
            else
            {
                throw new ArgumentException("無効なパラメータが指定されました。\r\nbool型の引数がすべてfalseです。");
            }
        }

        /// <summary>
        /// 入力データ情報をもとに入力データを作成し、文字列表現を返す。
        /// </summary>
        /// <param name="list">入力データ情報のリスト。</param>
        /// <param name="rnd">乱数生成器。</param>
        /// <returns></returns>
        public static string createInputInfo(List<InputInfoBase> list, Random rnd)
        {
            var arg = new Dictionary<string, string>(); // のちの機能拡張(他の入力情報を制約に使う(#13))で使う予定
            return createInputInfo(list, rnd, ref arg);
        }

        /// <summary>
        /// 入力データ情報をもとに入力データを作成し、文字列表現を返す。
        /// </summary>
        /// <param name="list">入力データ情報のリスト。</param>
        /// <param name="rnd">乱数生成器。</param>
        /// <param name="arg">引数情報。</param>
        /// <returns></returns>
        private static string createInputInfo(List<InputInfoBase> list, Random rnd, ref Dictionary<string, string> arg)
        {

            // 上からi番目の「ループの深さ1以上であるグループ」の入力データ情報のリストのリスト。
            List<List<InputInfoBase>> inLoopInputInfoList;
            // ループの深さ1以上の部分を取り除いた入力データ情報のリスト。
            List<InputInfoBase> inputInfoListExceptInLoop;
            // 入力データ情報のリストから、ループの深さ1以上の部分を分離する。
            excludeInLoop(list, out inputInfoListExceptInLoop, out inLoopInputInfoList);

            string inputInfoAllStr = "";
            int cntInLoopInputInfoList = 0;
            foreach (InputInfoBase inputInfo in inputInfoListExceptInLoop)
            {
                inputInfoAllStr += inputInfo.createInputData(rnd, ref arg);
                if (inputInfo is InputInfoLoopStart inputInfoLoopStart)
                {
                    // tempListInputInfoに保存しているものをループ回数分吐き出す。
                    long loopLength = inputInfoLoopStart.getLoopLength(rnd, ref arg);
                    string divisorInter = inputInfoLoopStart.divisorInter;
                    string divisorLast = inputInfoLoopStart.divisorLast;
                    for (long i = 1; i <= loopLength; i++)
                    {
                        inputInfoAllStr += createInputInfo(inLoopInputInfoList[cntInLoopInputInfoList], rnd, ref arg);
                        inputInfoAllStr += (i == loopLength) ? divisorLast : divisorInter;
                    }
                    cntInLoopInputInfoList++;
                }
            }

            return inputInfoAllStr;
        }

        /// <summary>
        /// 入力データ情報のリストから、ループの深さ1以上の部分を部分を分離する。
        /// また、ループの深さ0に戻るループ終了点の入力データ情報を削除する。
        /// ループの深さ0→1のループ開始点の入力データ情報は、そのまま残す。
        /// </summary>
        /// <param name="list">入力データ情報のリスト</param>
        /// <param name="inputInfoListExceptInLoop">出力用の変数。引数listからループの深さ1以上の部分と、ループの深さ1→0のループ終了点を削除したもの。</param>
        /// <param name="inLoopInputInfoList">listからループの深さ1以上の部分入力データ情報のリストのリスト。
        /// 外側のリストは、上から数えて何番目のループの深さ1以上のグループであるかを表す。
        /// 内側のリストは、そのグループ内の入力データ情報のリストを表す。</param>
        /// <example>
        /// 例えば、listが以下のような構成の場合：
        /// LoopStart_1 Integer_2 LoopStart_3 Integer_4 List_5 LoopEnd_6 LoopEnd_7 Integer_8 LoopStart_9 List_10 LoopEnd_11 List_12 List_13
        /// inputInfoListExceptInLoopは以下の通り：
        /// LoopStart_1 Integer_8 LoopStart_9 List_12 List_13
        /// inLoopInputInfoListはサイズ2のリストで、以下の通り：
        /// [0] → Integer_2 LoopStart_3 Integer_4 List_5 LoopEnd_6
        /// [1] → List_10
        /// </example>
        private static void excludeInLoop(List<InputInfoBase> list, out List<InputInfoBase> inputInfoListExceptInLoop, out List<List<InputInfoBase>> inLoopInputInfoList)
        {
            inputInfoListExceptInLoop = new List<InputInfoBase>();
            inLoopInputInfoList = new List<List<InputInfoBase>>();
            int loopDepth = 0;
            var tempInLoopInputInfoList = new List<InputInfoBase>();

            foreach (InputInfoBase inputInfo in list)
            {
                if (loopDepth == 0)
                {
                    loopDepth += getLoopDepthVariation(inputInfo);
                    if (loopDepth > 0)
                    {
                        // 深さが0→1となった場合、一時的にループ深さ1以上の部分を保存しておくtemp変数を初期化する。
                        tempInLoopInputInfoList = new List<InputInfoBase>();
                    }
                    else if (loopDepth < 0)
                    {
                        // 深さが0→-1となった場合、入力エラー。
                        throw new ArgumentException("ループの開始が存在しないループの終了が登録されています。");
                    }
                    // 深さが0の部分は、ループ終了点以外、どの入力データ情報でも戻り値用の変数に保存する。
                    inputInfoListExceptInLoop.Add(inputInfo);
                }
                else
                {
                    loopDepth += getLoopDepthVariation(inputInfo);
                    if (loopDepth == 0)
                    {
                        // ループの深さが1→0となったら、tempを戻り値用の変数に保存する。
                        inLoopInputInfoList.Add(tempInLoopInputInfoList);
                    }
                    else
                    {
                        // 深さが1以上の部分に居続けている場合、tempにいったん保存する。
                        tempInLoopInputInfoList.Add(inputInfo);
                    }
                }
            }
            // 全てのループを調べても、深さが0に戻らない場合、入力エラー。
            if (loopDepth != 0) throw new ArgumentException("ループの終了が登録されていないループがあります。");
        }

        private static int getLoopDepthVariation(InputInfoBase inputInfoBase)
        {
            if (inputInfoBase is InputInfoLoopStart inputInfoLoopStart)
            {
                return 1;
            }
            else if (inputInfoBase is InputInfoLoopEnd inputInfoLoopEnd)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
