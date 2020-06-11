using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExpressionAnalysis;
using MathExpressionAnalysis.Object;

namespace InputCreatorForCompProgramming
{
    public class InputInfoLoopStart : InputInfoBase
    {
        MathTree loopMin;
        MathTree loopMax;
        public string divisorInter { get; }
        public string divisorLast { get; }

        public InputInfoLoopStart(MathTree loopMin, MathTree loopMax, string divisorInter, string divisorLast)
        {
            this.loopMin = loopMin;
            this.loopMax = loopMax;
            this.divisorInter = divisorInter;
            this.divisorLast = divisorLast;
        }
        public override string makeDisplayText()
        {
            string text = "ループ[" + loopMin.ToString() + "～" + loopMax.ToString() + "]";
            return text;
        }
        public long getLoopLength(Random rnd, ref Dictionary<string, string> arg)
        {
            long evalLoopMin = loopMin.eval().valueInteger;
            long evalLoopMax = loopMax.eval().valueInteger;

            double r = rnd.NextDouble();
            long result = evalLoopMin + (long)Math.Floor(r * (evalLoopMax - evalLoopMin + 1));
            return result;
        }

        public override string createInputData(Random rnd, ref Dictionary<string, string> arg)
        {
            return "";
        }
    }
}
