using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    struct MyFrac
    {

        public long nom, denom;
        static long NSD(long n, long d)
        {
            while (n > 0 && d > 0)
            {
                if (n > d)
                    n %= d;
                else d %= n;
            }
            return n + d;
        }
        public MyFrac(long n, long d)
        {



            long res = NSD(n, d);
            n /= res;
            d /= res;

            nom = n;
            denom = d;
        }
        public void Output()
        {
            Console.WriteLine("{0} / {1}", nom, denom);
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            MyFrac output = new MyFrac(15, 40);
            output.Output();
            Console.ReadKey();
        }
    }
}
