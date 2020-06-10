using MathExpressionAnalysis.Factory;
using MathExpressionAnalysis.Object;
using MathExpressionAnalysis.Object.Lex;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathExpressionAnalysis
{
    public static class RPolishLogic
    {
        /// <summary>
        /// 逆ポーランド記法表現で品詞を区切るために利用する文字列。
        /// </summary>
        private static string DIVIDE_CHAR_R_POLISH = " ";
        /// <summary>
        /// 数式ツリーの逆ポーランド記法表現を取得する。
        /// </summary>
        /// <param name="tree">数式ツリー。</param>
        /// <returns>数式ツリーの逆ポーランド記法表現の文字列。</returns>
        public static string createRPolish(MathTree tree)
        {
            return createRPolishNode(tree.root);
        }
        /// <summary>
        /// 数式ツリーのノードの逆ポーランド記法表現を取得する。
        /// </summary>
        /// <param name="node">数式ツリーのノード。</param>
        /// <returns>数式ツリーのノードの逆ポーランド記法表現の文字列。</returns>
        private static string createRPolishNode(MathTreeNode node)
        {
            string rPolish = "";
            if (node.left != null)
            {
                rPolish += createRPolishNode(node.left);
            }
            else if (node.right != null)
            {
                rPolish += createRPolishNode(node.right);
            }
            rPolish += node.lex.getRPolish() + DIVIDE_CHAR_R_POLISH;
            return rPolish;
        }
        /// <summary>
        /// 逆ポーランド記法表現の文字列から、数式ツリーを復元する。
        /// ただし、演算子品詞のparenthesisDepthは正しく設定されないので注意。
        /// (逆ポーランド記法表現では再現不能。)
        /// </summary>
        /// <param name="rPolish">逆ポーランド記法表現</param>
        /// <returns>復元した数式ツリー。</returns>
        public static MathTree analyzeRPolish(string rPolish)
        {
            string[] separatingStrings = { DIVIDE_CHAR_R_POLISH };
            string[] lexicalStrList = rPolish.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
            var tree = new MathTree();
            var queue = new Queue<MathTreeNode>();
            foreach (string lexicalStr in lexicalStrList)
            {
                Lexical lexical = LexicalFactory.createFromRPolish(lexicalStr);
                if (lexical is Literal)
                {
                    var node = new MathTreeNode();
                    node.lex = lexical;
                    node.master = tree;
                    queue.Enqueue(node);
                }
                else if (lexical is UnaryOperator)
                {
                    MathTreeNode operand = queue.Dequeue();
                    var node = new MathTreeNode();
                    node.lex = lexical;
                    node.master = tree;
                    node.right = operand;
                    queue.Enqueue(node);
                } else if(lexical is BinaryOperator)
                {
                    if(queue.Count < 2)
                    {
                        throw new ArgumentException("2つのリテラルを接続していない2項演算子があります。");
                    }
                    MathTreeNode rightOperand = queue.Dequeue();
                    MathTreeNode leftOperand = queue.Dequeue();
                    var node = new MathTreeNode();
                    node.lex = lexical;
                    node.master = tree;
                    node.left = leftOperand;
                    node.right = rightOperand;
                    queue.Enqueue(node);
                } else
                {
                    throw new ArgumentException("評価できない品詞が存在します。対象文字列：" + lexicalStr);
                }
            }
            if (queue.Count != 1)
            {
                throw new ArgumentException("最終評価が複数のリテラルとなります。");
            }
            tree.root = queue.Dequeue();
            return tree;
        }
    }
}
