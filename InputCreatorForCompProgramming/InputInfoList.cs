using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public class InputInfoList : InputInfoBase
    {
        private List<string> list;
        private string divisor;

        public InputInfoList(List<string> list, string divisor)
        {
            if (list.Count == 0) throw new ArgumentException("リストが空です。");
            this.list = list;
            this.divisor = divisor;
        }

        public override string makeDisplayText()
        {
            string listStr = "";
            foreach(string item in list)
            {
                listStr += item + ",";
            }
            string text = "リスト[" + listStr + "]";
            return text;
        }

        public override string createInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            string inputData = makeInputData(rnd, ref arg);
            return inputData + divisor;
        }

        private string makeInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            double r = rnd.NextDouble();
            int count = list.Count;
            int index = (int)Math.Floor(r * count);
            string result = list[index];
            return result;
        }

    }
}
