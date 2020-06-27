using System;
using System.Collections.Generic;
using MathExpressionAnalysis.Object;
using MathExpressionAnalysis.Object.Lex;
using MathExpressionAnalysis.Factory;
using System.Linq;

namespace MathExpressionAnalysis
{
    public class MathExpressionAnalysisLogic
    {
        #region"1.終端記号解析"
        /// <summary>
        /// 文字列の数式を、終端記号のリストに変換する。
        /// </summary>
        /// <param name="expr">文字列の数式。</param>
        /// <returns>終端記号のリスト。</returns>
        public static List<TerminalSymbol> convertTerminalSymbolList(string expr)
        {
            if (expr == "") return new List<TerminalSymbol>();
            List<string> terminalSymbolListStr = divideTerminalSymbol(expr);
            List<TerminalSymbol> terminalSymbolList = assignTerminalSymbolList(terminalSymbolListStr);
            return terminalSymbolList;
        }
        /// <summary>
        /// 文字列を、終端記号ごとに区切る。
        /// スペースは終端記号の区切りとして扱い、結果のリストからは取り除く。
        /// </summary>
        /// <param name="expr">文字列の数式</param>
        /// <returns>終端記号ごとに区切られた文字列のリスト。</returns>
        private static List<string> divideTerminalSymbol(string expr)
        {
            var TerminalSymbolList = new List<string>();
            // tempにexprの文字列を1文字ずつ追加し、、終端記号の境界が来たらリストへしまってtempを空文字列にする。
            string temp = expr[0].ToString();
            for (int i = 0; i < expr.Length - 1; i++)
            {
                if (checkTerminalSymbolBoundary(expr[i], expr[i + 1]))
                {
                    if (temp != " ") TerminalSymbolList.Add(temp);
                    temp = expr[i + 1].ToString();
                }
                else
                {
                    temp += expr[i + 1].ToString();
                }
            }
            if (temp != " ") TerminalSymbolList.Add(temp);
            return TerminalSymbolList;
        }
        /// <summary>
        /// 終端記号の境界を判定する。
        /// </summary>
        /// <param name="before">境界の直前の文字</param>
        /// <param name="after">境界の直後の文字</param>
        /// <returns>終端記号の境界であればtrueを返す。</returns>
        private static bool checkTerminalSymbolBoundary(char before, char after)
        {
            // 境界でないケースを調べてfalseを返し、最後にtrueを返す。
            if (checkVarNameChar(before) && checkVarNameChar(after))
            {
                // 両方とも変数名に使える文字列の場合、false。
                return false;
            }
            else if (before == '&' && after == '&')
            {
                // 「&&」は一つの演算子なので、false。
                return false;
            }
            else if (before == '|' && after == '|')
            {
                // 「||」は一つの演算子なので、false。
                return false;
            }
            else if (after == '=')
            {
                // <=.>=,!=,==はそれぞれ、一つの演算子なので、false。
                if (before == '<' || before == '>' || before == '!' || before == '=')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 関数名・変数名に使用できる文字であるかを判定する。
        /// 使えるのは、小文字・大文字の半角英字、0～9の数字、.、_の4種類。
        /// ※ただし、文法規則上は、関数・変数名の最初は英字のみ。
        /// </summary>
        /// <param name="c">対象の文字</param>
        /// <returns>関数名・変数名に利用できる文字列であればtrueを、それ以外はfalseを返す。</returns>
        private static bool checkVarNameChar(char c)
        {
            return Char.IsLetterOrDigit(c) || c == '.' || c == '_';
        }
        /// <summary>
        /// 0～9の数字であるかどうかを判定する。
        /// </summary>
        /// <param name="c">対象の文字</param>
        /// <returns>0～9の数字であればtrueを、それ以外はfalseを返す。</returns>
        private static bool checkDigit(char c)
        {
            return Char.IsDigit(c);
        }
        /// <summary>
        /// 終端記号ごとに区切った文字列にタイプを割り当て、終端記号のリストを取得する。
        /// </summary>
        /// <param name="terminalSymbolListStr">終端記号ごとに区切った文字列のリスト</param>
        /// <returns>終端記号のリスト</returns>
        private static List<TerminalSymbol> assignTerminalSymbolList(List<string> terminalSymbolListStr)
        {
            var terminalSymbolList = new List<TerminalSymbol>();

            int n = terminalSymbolListStr.Count;
            terminalSymbolListStr.Add(null);
            TerminalSymbol prevTerminalSymbol = new TerminalSymbol(null, TerminalSymbolType.None);
            for (int i = 0; i < n; i++)
            {
                TerminalSymbol terminalSymbol;
                bool assignResult = assignTerminalSymbol(prevTerminalSymbol, terminalSymbolListStr[i], terminalSymbolListStr[i + 1], out terminalSymbol);
                if (!assignResult)
                {
                    throw new ArgumentException("終端記号タイプの割り当てに失敗しました。");
                }
                prevTerminalSymbol = terminalSymbol;
                terminalSymbolList.Add(terminalSymbol);
            }
            return terminalSymbolList;

        }
        /// <summary>
        /// 文字列に終端記号を割り当てる。
        /// </summary>
        /// <param name="prevExpr">評価対象の前の終端記号。</param>
        /// <param name="expr">評価対象の文字列。</param>
        /// <param name="nextExpr">評価対象の次の文字列。
        /// <param name="terminalSymbol">結果を保存する変数。
        /// exprに終端記号を割り当てて返却する。</param>
        /// 評価対象の文字列が式の最後の場合は、nullを指定する。</param>
        /// <returns>終端記号割り当てに成功した場合、trueを返却する。</returns>
        private static bool assignTerminalSymbol(TerminalSymbol prevExpr, string expr, string nextExpr, out TerminalSymbol terminalSymbol)
        {

            terminalSymbol = new TerminalSymbol(null, TerminalSymbolType.None);
            if (expr.Length == 0) return false;

            switch (expr)
            {
                case "+":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpAdd);
                    return true;
                case "-":
                    TerminalSymbolType hyphenTerminalSymbolType = getHyphenTerminalSymbolType(prevExpr.type);
                    if (hyphenTerminalSymbolType == TerminalSymbolType.None) return false;
                    terminalSymbol = new TerminalSymbol(expr, hyphenTerminalSymbolType);
                    return true;
                case "*":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpProd);
                    return true;
                case "/":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpDivide);
                    return true;
                case "%":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpMod);
                    return true;
                case "^":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpPow);
                    return true;
                case "<":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpLt);
                    return true;
                case "<=":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpLtEq);
                    return true;
                case ">":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpGt);
                    return true;
                case ">=":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpGtEq);
                    return true;
                case "==":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpEq);
                    return true;
                case "!=":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpNotEq);
                    return true;
                case "!":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpNot);
                    return true;
                case "&&":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpAnd);
                    return true;
                case "||":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.OpOr);
                    return true;
                case ",":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Comma);
                    return true;
                case "(":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.LeftP);
                    return true;
                case ")":
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.RightP);
                    return true;
            }
            if (expr == "true")
            {
                terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.LogicTrue);
                return true;
            }
            else if (expr == "false")
            {
                terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.LogicFalse);
                return true;
            }
            else if (checkDigit(expr[0]))
            {
                // 数値であることを判定する。
                int countDot = 0;
                for (int i = 1; i < expr.Length; i++)
                {
                    if (expr[i] == '.')
                    {
                        countDot++;
                    }
                    else if (!checkDigit(expr[i]))
                    {
                        return false;
                    }
                }
                if (countDot == 0)
                {
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Integer);
                    return true;
                }
                else if (countDot == 1)
                {
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Decimal);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Char.IsLetter(expr[0]))
            {
                // 全ての文字が関数・変数で利用可能であることを確認する。
                for (int i = 1; i < expr.Length; i++)
                {
                    if (!checkVarNameChar(expr[i])) return false;
                }
                // 次のexprの種類によって関数又は変数が決まる。
                // funcになるパターンは、次の終端記号が整数、小数、変数、関数、左括弧のどれかの場合。
                // true/falseが続く場合は文法エラーなので除外すると、以下の条件式で識別できる。
                if (nextExpr == null)
                {
                    terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Variable);
                    return true;
                }
                else
                {
                    if (nextExpr.Length == 0) return false;
                    if (checkVarNameChar(nextExpr[0]) || nextExpr == "(")
                    {
                        terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Function);
                        return true;
                    }
                    else
                    {
                        terminalSymbol = new TerminalSymbol(expr, TerminalSymbolType.Variable);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// ハイフン「-」が負数演算子として使うか、減算演算子として使うかを判定する。
        /// </summary>
        /// <param name="prevTerminalSymbolType">ハイフンのひとつ前の終端記号のタイプ</param>
        /// <returns>ハイフンの終端記号タイプ。ひとつ前の終端記号タイプが論理値の場合、Noneを返却する。</returns>
        private static TerminalSymbolType getHyphenTerminalSymbolType(TerminalSymbolType prevTerminalSymbolType)
        {
            switch (prevTerminalSymbolType)
            {
                case TerminalSymbolType.Integer:
                case TerminalSymbolType.Decimal:
                case TerminalSymbolType.Variable:
                case TerminalSymbolType.RightP:
                    return TerminalSymbolType.OpDiff;
                case TerminalSymbolType.None:
                case TerminalSymbolType.OpAdd:
                case TerminalSymbolType.OpDiff:
                case TerminalSymbolType.OpProd:
                case TerminalSymbolType.OpDivide:
                case TerminalSymbolType.OpMod:
                case TerminalSymbolType.OpPow:
                case TerminalSymbolType.OpNeg:
                case TerminalSymbolType.OpLt:
                case TerminalSymbolType.OpLtEq:
                case TerminalSymbolType.OpGt:
                case TerminalSymbolType.OpGtEq:
                case TerminalSymbolType.OpEq:
                case TerminalSymbolType.OpNotEq:
                case TerminalSymbolType.OpNot:
                case TerminalSymbolType.OpAnd:
                case TerminalSymbolType.OpOr:
                case TerminalSymbolType.Function:
                case TerminalSymbolType.Comma:
                case TerminalSymbolType.LeftP:
                    return TerminalSymbolType.OpNeg;
                case TerminalSymbolType.LogicTrue:
                case TerminalSymbolType.LogicFalse:
                default:
                    return TerminalSymbolType.None;
            }
        }
        #endregion

        #region "2.品詞変換"
        /// <summary>
        /// 終端記号のリストを、品詞のリストに変換する。
        /// </summary>
        /// <param name="terminalSymbolList">終端記号のリスト。</param>
        /// <returns>品詞のリスト。</returns>
        public static List<Lexical> convertLexicalList(List<TerminalSymbol> terminalSymbolList)
        {
            var lexicalList = new List<Lexical>();
            int parenthesisDepth = 0; //括弧の深さ。
            foreach (TerminalSymbol terminalSymbol in terminalSymbolList)
            {
                if (terminalSymbol.type == TerminalSymbolType.LeftP)
                {
                    parenthesisDepth++;
                }
                else if (terminalSymbol.type == TerminalSymbolType.RightP)
                {
                    parenthesisDepth--;
                    if (parenthesisDepth < 0)
                    {
                        throw new ArgumentException("対応する「(」が存在しない「)」があります。");
                    }
                }
                else
                {
                    Lexical lexical = LexicalFactory.create(terminalSymbol, parenthesisDepth);
                    lexicalList.Add(lexical);
                }
            }
            if (parenthesisDepth != 0)
            {
                throw new ArgumentException("「(」の数と「)」の数が一致しません。");
            }
            return lexicalList;
        }
        #endregion

        #region "3.数式ツリー解析"
        /// <summary>
        /// 品詞のリストを解析して、数式ツリーを作成する。
        /// </summary>
        /// <param name="lexicalList">品詞のリスト。</param>
        /// <returns>数式ツリー。</returns>
        public static MathTree makeMathTree(List<Lexical> lexicalList)
        {
            if (lexicalList.Count == 0) throw new ArgumentException("品詞のリストが空です。");
            var tree = new MathTree();
            tree.root = makeMathTreeNode(lexicalList, ref tree);
            return tree;
        }
        /// <summary>
        /// 品詞のリストを解析し、数式ツリーの1ノードを作成する。
        /// </summary>
        /// <param name="lexicalList">品詞のリスト。</param>
        /// <param name="master">数式ツリーのマスター。</param>
        /// <returns>数式ツリーのノード。</returns>
        private static MathTreeNode makeMathTreeNode(List<Lexical> lexicalList, ref MathTree master)
        {
            if (lexicalList.Count == 0)
            {
                throw new ApplicationException("無効な式が指定されました。");
            }
            var node = new MathTreeNode();
            node.master = master;
            if (lexicalList.Count == 1)
            {
                Lexical lex = lexicalList[0];
                if (!(lex is Literal))
                {
                    throw new ArgumentException("最終評価が演算子となる品詞が存在します。");
                }
                node.lex = lex;
                return node;
            }
            else
            {
                int operatorIndex = leastPrioritizedRightOperatorIndex(lexicalList);
                if (operatorIndex == -1) // 2つ以上項があるのに、演算子が見つからない場合
                {
                    throw new ArgumentException("複数のリテラルからなる式が評価されました。");
                }
                Operator op = (Operator)lexicalList[operatorIndex];
                var leftLexicalList = new List<Lexical>();
                for (int i = 0; i < operatorIndex; i++)
                {
                    leftLexicalList.Add(lexicalList[i]);
                }
                var rightLexicalList = new List<Lexical>();
                for (int i = operatorIndex + 1; i < lexicalList.Count; i++)
                {
                    rightLexicalList.Add(lexicalList[i]);
                }
                if (op is UnaryOperator)
                {
                    if (leftLexicalList.Count != 0)
                    {
                        throw new ArgumentException("単項演算子の左側にオペランドを持つことはできません。");
                    }
                    else if (rightLexicalList.Count == 0)
                    {
                        throw new ArgumentException("単項演算子の右側にオペランドが存在しません。");
                    }
                    node.lex = op;
                    node.left = null;
                    node.right = makeMathTreeNode(rightLexicalList, ref master);
                    return node;
                }
                else if (op is BinaryOperator)
                {
                    if (leftLexicalList.Count == 0)
                    {
                        throw new ArgumentException("2項演算子の左側にオペランドが存在しません。");
                    }
                    else if (rightLexicalList.Count == 0)
                    {
                        throw new ArgumentException("2項演算子の右側にオペランドが存在しません。");
                    }
                    node.lex = op;
                    node.left = makeMathTreeNode(leftLexicalList, ref master);
                    node.right = makeMathTreeNode(rightLexicalList, ref master);
                    return node;
                }
                else
                {
                    throw new ApplicationException("単項演算子、2項演算子以外の品詞が、演算子として評価されました。");
                }

            }
        }
        /// <summary>
        /// 優先度が最も低い演算子のうち、最も右側にある演算子のインデックスを返す。
        /// 演算子が存在しない場合、-1を返す。
        /// </summary>
        /// <param name="list">品詞のリスト</param>
        /// <returns>最も低い演算子のうち、最も右側にある演算子のインデックス。</returns>
        private static int leastPrioritizedRightOperatorIndex(List<Lexical> list)
        {
            int index = -1;
            int minPriority = Int32.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Operator op)
                {
                    int operatorPriority = op.getPriority();
                    if (operatorPriority <= minPriority)
                    {
                        index = i;
                        minPriority = operatorPriority;
                    }
                }
            }
            return index;
        }
        #endregion

        #region "4.データ型チェック"
        /// <summary>
        /// 数式ツリーがデータ型の違反をしていないか判定します。
        /// </summary>
        /// <param name="tree">数式ツリー。</param>
        /// <param name="variableDataTypeMap">変数のデータ型の連想配列。</param>
        /// <param name="functionDataTypeMap">関数の戻り値のデータ型の連想配列。</param>
        /// <returns>この数式ツリーが返す評価値のデータ型を返却します。
        /// 文法エラーの場合、Noneが返却されます。</returns>
        public static DataType checkDataType(MathTree tree, Dictionary<string, DataType> variableDataTypeMap = null,
            Dictionary<string, DataType> functionDataTypeMap = null)
        {
            if (variableDataTypeMap == null) variableDataTypeMap = new Dictionary<string, DataType>();
            if (functionDataTypeMap == null) functionDataTypeMap = new Dictionary<string, DataType>();
            return checkNodeDataType(tree.root, variableDataTypeMap, functionDataTypeMap);
        }
        /// <summary>
        /// 数式ツリーがデータ型の違反をしていないか判定します。
        /// </summary>
        /// <param name="tree">数式ツリー。</param>
        /// <param name="variableMap">変数の連想配列。キーは変数名。</param>
        /// <param name="functionMap">関数の連想配列。キーは関数名。</param>
        /// <returns>この数式ツリーが返す評価値のデータ型を返却します。
        /// 文法エラーの場合、Noneが返却されます。</returns>
        /// <returns></returns>
        public static DataType checkDataType(MathTree tree, Dictionary<string, Variable> variableMap,
            Dictionary<string, Function> functionMap)
        {
            Dictionary<string, DataType> variableDataTypeMap = variableMap.ToDictionary(x => x.Key, x => x.Value.type);
            Dictionary<string, DataType> functionDataTypeMap = functionMap.ToDictionary(x => x.Key, x => x.Value.returnDataType);
            return checkDataType(tree, variableDataTypeMap, functionDataTypeMap);
        }
        /// <summary>
        /// 数式ツリーの1ノードのデータ型を取得する。
        /// </summary>
        /// <param name="node">数式ツリー中のノード。</param>
        /// <param name="variableDataTypeMap">変数のデータ型の連想配列。</param>
        /// <param name="functionDataTypeMap">関数の戻り値のデータ型の連想配列。</param>
        /// <returns>この数式ツリーのノードが返す評価値のデータ型を返却します。
        /// 文法エラーの場合、Noneが返却されます。</returns>
        private static DataType checkNodeDataType(MathTreeNode node, Dictionary<string, DataType> variableDataTypeMap,
            Dictionary<string, DataType> functionDataTypeMap)
        {
            if (node.lex is Literal literal)
            {
                return literal.getDataType(variableDataTypeMap);
            }
            else if (node.lex is UnaryOperator unaryOperator)
            {
                DataType operandDataType = checkNodeDataType(node.right, variableDataTypeMap, functionDataTypeMap);
                return unaryOperator.getDataType(operandDataType, functionDataTypeMap);
            }
            else if (node.lex is BinaryOperator binaryOperator)
            {
                DataType leftOperandDataType = checkNodeDataType(node.left, variableDataTypeMap, functionDataTypeMap);
                DataType rightOperandDataType = checkNodeDataType(node.right, variableDataTypeMap, functionDataTypeMap);
                return binaryOperator.getDataType(leftOperandDataType, rightOperandDataType);
            }
            else
            {
                throw new ApplicationException("リテラル、単項演算子、2項演算子以外の品詞が指定されました。");
            }
        }
        #endregion

        #region "5.評価"
        public static MathTreeNodeValue eval(MathTree tree, Dictionary<string, Variable> variableMap = null, Dictionary<string, Function> functionMap = null)
        {
            if (variableMap == null) variableMap = new Dictionary<string, Variable>();
            if (functionMap == null) functionMap = new Dictionary<string, Function>();
            return evalNode(tree.root, variableMap, functionMap);
        }
        private static MathTreeNodeValue evalNode(MathTreeNode node, Dictionary<string, Variable> variableMap, Dictionary<string, Function> functionMap)
        {
            if (node.lex is Literal literal)
            {
                return literal.eval(variableMap);
            }
            else if (node.lex is UnaryOperator unaryOperator)
            {
                MathTreeNodeValue operand = evalNode(node.right, variableMap, functionMap);
                return unaryOperator.eval(operand, functionMap);
            }
            else if (node.lex is BinaryOperator binaryOperator)
            {
                MathTreeNodeValue leftOperand = evalNode(node.left, variableMap, functionMap);
                MathTreeNodeValue rightOperand = evalNode(node.right, variableMap, functionMap);
                return binaryOperator.eval(leftOperand, rightOperand);
            }
            else
            {
                throw new ApplicationException("リテラル、単項演算子、2項演算子以外の品詞が指定されました。");
            }
        }
        #endregion

        /// <summary>
        /// 文字列から数式ツリーを作成する。
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static MathTree getMathTreeFromString(String expr)
        {
            // 終端記号のリストに変換する。
            List<TerminalSymbol> terminalSymbolList = convertTerminalSymbolList(expr);
            // 品詞のリストに変換する。
            // ()はここで取り除かれ、operatorの優先度として割り当てる。
            List<Lexical> lexicalList = convertLexicalList(terminalSymbolList);
            // 数式構造を割り当てる。
            MathTree tree = makeMathTree(lexicalList);
            return tree;
        }

    }
}
