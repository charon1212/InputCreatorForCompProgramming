using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public static class InputInfoUtil
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

    }
}
