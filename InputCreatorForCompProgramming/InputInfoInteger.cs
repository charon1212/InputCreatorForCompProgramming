using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputCreatorForCompProgramming;

namespace InputCreatorForCompProgramming
{
    public class InputInfoInteger : InputInfoBase
    {

        private long min;
        private long max;
        private string divisor;

        public InputInfoInteger(long min, long max, string divisor)
        {
            this.min = min;
            this.max = max;
            this.divisor = divisor;
        }

        public override string makeDisplayText()
        {
            string text = "整数[" + min.ToString() + "～" + max.ToString() + "]";
            return text;
        }

        public override string createInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            long inputData = makeInputData(rnd, ref arg);
            return inputData.ToString() + divisor;
        }

        private long makeInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            double r = rnd.NextDouble();
            long result = min + (long)Math.Floor(r * (max - min + 1));
            return result;
        }

    }
}
