using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputCreatorForCompProgramming;
using MathExpressionAnalysis.Object;

namespace InputCreatorForCompProgramming
{
    public class InputInfoInteger : InputInfoBase
    {

        private MathTree min;
        private MathTree max;
        private String minStr;
        private String maxStr;
        private string divisor;

        public InputInfoInteger(MathTree min, MathTree max, String minStr, String maxStr, string divisor)
        {
            this.min = min;
            this.max = max;
            this.minStr = minStr;
            this.maxStr = maxStr;
            this.divisor = divisor;
        }

        public override string makeDisplayText()
        {
            string text = "整数[" + minStr + "～" + maxStr + "]";
            return text;
        }

        public override string createInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            long inputData = makeInputData(rnd, ref arg);
            return inputData.ToString() + divisor;
        }

        private long makeInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            long evalMin = min.eval().valueInteger;
            long evalMax = max.eval().valueInteger;

            double r = rnd.NextDouble();
            long result = evalMin + (long)Math.Floor(r * (evalMax - evalMin + 1));
            return result;
        }

    }
}
