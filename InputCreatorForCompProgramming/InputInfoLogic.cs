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
        public const string DIVISOR_SPACE = " ";
        public const string DIVISOR_NEWLINE = "\r\n";
        public const string DIVISOR_EMPTY = "";
        public static bool validateMathTreeDataType(MathTree tree, DataType dataType)
        {
            return tree.checkDataType() == dataType;
        }
        public static readonly string variableLetterChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
        /// <summary>
        /// 文字列が変数名として使用できることをチェックする。
        /// 使用可能文字：a～z,A～Z,0～9,_　（ただし、先頭は0～9以外）
        /// 文字列長：1以上
        /// </summary>
        /// <param name="str">調べる対象の文字列</param>
        /// <returns>使用できる場合はtrueを返す。</returns>
        public static bool validateVariableName(String str)
        {
            if (str.Length == 0) return false;
            if (!checkIsLetterChar(str[0])) return false;
            for (int i = 1; i < str.Length; i++) if (!checkIsLetterChar(str[i]) || !Char.IsDigit(str[i])) return false;
            return true;
        }
        private static bool checkIsLetterChar(Char c)
        {
            for (int i = 0; i < variableLetterChar.Length; i++) if (c == variableLetterChar[i]) return true;
            return false;
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
