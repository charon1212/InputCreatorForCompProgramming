using MathExpressionAnalysis.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    /// <summary>
    /// 入力情報の汎用的なバリデーションをまとめたクラス
    /// </summary>
    public static class InputInfoValidation
    {

        /// <summary>
        /// 数式の評価結果を確認する。
        /// </summary>
        /// <param name="tree">評価対象の数式</param>
        /// <param name="dataType">期待する評価結果のデータ型</param>
        /// <returns>期待するデータ型になる場合はtrueを返す。</returns>
        public static bool validateMathTreeDataType(MathTree tree, DataType dataType)
        {
            return tree.checkDataType() == dataType;
        }

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
            for (int i = 1; i < str.Length; i++) if (!checkIsLetterChar(str[i]) && !Char.IsDigit(str[i])) return false;
            return true;
        }

        public static readonly string variableLetterChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
        private static bool checkIsLetterChar(Char c)
        {
            for (int i = 0; i < variableLetterChar.Length; i++) if (c == variableLetterChar[i]) return true;
            return false;
        }

    }
}
