using System;
using System.Collections.Generic;
using System.Text;

namespace Aop_ILCodeWeaving_PostSharp
{
    public class Singer : ISinger
    {
        [MyLoggingAspect]
        public void Sing(int songCount)
        {
            Console.WriteLine("Enter Sandman");
        }
    }
}
