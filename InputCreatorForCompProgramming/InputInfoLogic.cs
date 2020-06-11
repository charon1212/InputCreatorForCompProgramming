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
        public const string DIVISOR_SPACE = " ";
        public const string DIVISOR_NEWLINE = "\r\n";
        public const string DIVISOR_EMPTY = "";
        public static bool validateIntegerMin(string s)
        {
            return canParseInt64(s);
        }
        public static bool validateIntegerMax(string s)
        {
            return canParseInt64(s);
        }
        private static bool canParseInt64(string s)
        {
            Int64 value;
            bool parseResult = Int64.TryParse(s, out value);
            return parseResult;
        }

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

        public static string createInputInfo(List<InputInfoBase> list, Random rnd)
        {
            var arg = new Dictionary<string, string>(); // のちの機能拡張(他の入力情報を制約に使う(#13))で使う予定
            return createInputInfo(list, rnd, ref arg);
        }

        private static string createInputInfo(List<InputInfoBase> list, Random rnd, ref Dictionary<string, string> arg)
        {
            List<List<InputInfoBase>> inLoopInputInfoList;
            List<InputInfoBase> inputInfoListExceptInLoop;
            excludeInLoop(list, out inputInfoListExceptInLoop, out inLoopInputInfoList);

            string inputInfoAllStr = "";
            int cntInLoopInputInfoList = 0;
            foreach (InputInfoBase inputInfo in inputInfoListExceptInLoop)
            {
                inputInfoAllStr += inputInfo.createInputData(rnd, ref arg);
                if (inputInfo is InputInfoLoopStart inputInfoLoopStart)
                {
                    // tempListInputInfoに保存しているものをループ回数分吐き出す。
                    int loopLength = inputInfoLoopStart.getLoopLength(rnd, ref arg);
                    string divisorInter = inputInfoLoopStart.divisorInter;
                    string divisorLast = inputInfoLoopStart.divisorLast;
                    for (int i = 1; i <= loopLength; i++)
                    {
                        inputInfoAllStr += createInputInfo(inLoopInputInfoList[cntInLoopInputInfoList], rnd, ref arg);
                        inputInfoAllStr += (i == loopLength) ? divisorLast : divisorInter;
                    }
                    cntInLoopInputInfoList++;
                }
            }

            return inputInfoAllStr;
        }

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
                        tempInLoopInputInfoList = new List<InputInfoBase>();
                    }
                    else if (loopDepth < 0)
                    {
                        throw new ArgumentException("ループの開始が存在しないループの終了が登録されています。");
                    }
                    inputInfoListExceptInLoop.Add(inputInfo);
                }
                else
                {
                    loopDepth += getLoopDepthVariation(inputInfo);
                    if (loopDepth == 0)
                    {
                        inLoopInputInfoList.Add(tempInLoopInputInfoList);
                    }
                    else
                    {
                        tempInLoopInputInfoList.Add(inputInfo);
                    }
                }
            }
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
