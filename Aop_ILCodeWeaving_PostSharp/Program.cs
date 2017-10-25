using System;

namespace Aop_ILCodeWeaving_PostSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var singer = new Singer();
            singer.Sing(30);

            Console.ReadKey();
        }
    }
}
