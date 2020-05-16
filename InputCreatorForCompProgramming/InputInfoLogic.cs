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
            } else if(divisorIsSpace)
            {
                return DIVISOR_SPACE;
            } else if (divisorIsEmpty)
            {
                return DIVISOR_EMPTY;
            } else if(divisorIsCustom)
            {
                return divisorCustom;
            } else
            {
                throw new ArgumentException("無効なパラメータが指定されました。\r\nbool型の引数がすべてfalseです。");
            }
        }

        private static string createOneInputInfo(InputInfoBase inputInfoBase, Random rnd, Dictionary<string,string> arg)
        {
            switch (inputInfoBase.inputType)
            {
                case InputType.None:
                    throw new ArgumentException("InputTypeに無効な値が設定されました。");
                case InputType.Integer:
                    var inputInfoInteger = (InputInfoInteger)inputInfoBase;
                    return inputInfoInteger.createInputData(rnd, arg);
                case InputType.List:
                    var inputInfoList = (InputInfoList)inputInfoBase;
                    return inputInfoList.createInputData(rnd, arg);
                case InputType.LoopStart:
                case InputType.LoopEnd:
                    return "";
                default:
                    throw new ArgumentException("InputTypeに無効な値が設定されました。");
            }
        }

        public static string createInputInfo(List<InputInfoBase> list, Random rnd)
        {
            var arg = new Dictionary<string, string>(); // のちの機能拡張(他の入力情報を制約に使う(#13))で使う予定
            return createInputInfo(list, rnd, arg);
        }

        private static string createInputInfo(List<InputInfoBase> list, Random rnd, Dictionary<string, string> arg)
        {
            string inputInfoAllStr = "";
            List<InputInfoBase> tempListInputInfo = null;
            InputInfoLoopStart tempInputInfoLoopStart = null;
            int loopDepth = 0;
            foreach(InputInfoBase inputInfo in list)
            {
                if(loopDepth == 0)
                {
                    if(inputInfo.inputType == InputType.LoopStart)
                    {
                        loopDepth++;
                        tempListInputInfo = new List<InputInfoBase>();
                        tempInputInfoLoopStart = (InputInfoLoopStart)inputInfo;
                    } else if(inputInfo.inputType == InputType.LoopEnd)
                    {
                        throw new ArgumentException("ループの開始が存在しないループの終了が登録されています。");
                    } else
                    {
                        inputInfoAllStr += createOneInputInfo(inputInfo, rnd, arg);
                    }
                } else if (loopDepth > 0)
                {
                    loopDepth += getLoopDepthVariation(inputInfo.inputType);
                    if(loopDepth == 0)
                    {
                        // tempListInputInfoに保存しているものをループ回数分吐き出す。
                        int loopLength = tempInputInfoLoopStart.getLoopLength(rnd, arg);
                        string divisorInter = tempInputInfoLoopStart.divisorInter;
                        string divisorLast = tempInputInfoLoopStart.divisorLast;
                        for(int i = 1; i <= loopLength; i++)
                        {
                            inputInfoAllStr += createInputInfo(tempListInputInfo, rnd, arg);
                            inputInfoAllStr += (i == loopLength) ? divisorLast : divisorInter;
                        }
                    } else
                    {
                        tempListInputInfo.Add(inputInfo);
                    }
                } else
                {
                    //ロジック上、到達不能なコード
                    throw new ArgumentException("ループの開始が存在しないループの終了が登録されています。");
                }
            }
            if(loopDepth != 0)
            {
                throw new ArgumentException("ループの終了が登録されていないループがあります。");
            }
            return inputInfoAllStr;
        }

        private static int getLoopDepthVariation(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.LoopStart:
                    return 1;
                case InputType.LoopEnd:
                    return -1;
                default:
                    return 0;
            }
        }

    }
}
