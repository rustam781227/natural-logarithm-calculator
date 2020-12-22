using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLogarithmMethod
{
    public class Method
    {
        public delegate void EndPeriodCycleIterationEvent();
        public static event EndPeriodCycleIterationEvent OnEndPeriodCycleIterationEvent;
        public static double ln;
        public static double Step(int a, int t)
        {
            double x = (double)(a - 1) / (1 + a);
            ln = 0;
            for (int i = 1; i <= t; i++)
            {
                ln += (2 * Math.Pow(x, 2 * i - 1)) / (2 * i - 1);
                OnEndPeriodCycleIterationEvent?.Invoke();
            }
            return ln;
        }
    }
}
