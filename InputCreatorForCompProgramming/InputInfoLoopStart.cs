using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputCreatorForCompProgramming
{
    public class InputInfoLoopStart : InputInfoBase
    {
        int loopMin;
        int loopMax;
        public string divisorInter { get; }
        public string divisorLast { get; }

        public InputInfoLoopStart(int loopMin, int loopMax, string divisorInter, string divisorLast) : base(InputType.LoopStart)
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
        public int getLoopLength(Random rnd, Dictionary<string, string> arg)
        {
            double r = rnd.NextDouble();
            int result = loopMin + (int)Math.Floor(r * (loopMax - loopMin + 1));
            return result;
        }
    }
}
