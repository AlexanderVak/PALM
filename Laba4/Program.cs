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
        public MyFrac(long nom_, long denom_)
        {
            nom_ = Math.Abs(nom_);
            denom_ = Math.Abs(denom_);
            nom = nom_;
            denom = denom_;
            while (nom_ > 0 && denom_ > 0)
            {
                if (nom_ > denom_)
                    nom_ %= denom_;
                else denom_ %= nom_;
            }
            long res = nom_ + denom_;
            nom /= res;
            denom /= res;

        }
        public override string ToString()
        {
            string outputString = nom + "/" + denom;
            return outputString;
        }
    }

    class Program
    {
        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }

        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        
        static double DoubleValue(MyFrac f)
        {
            return (double)f.nom / f.denom;
        }

        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }

        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }

        static MyFrac GetRGR113LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 1; i <= n ; i++)
            {
                res = Plus(res, Divide(new MyFrac(1, 1), new MyFrac((2 * i - 1) * (2 * i + 1), 1)));
            }
            return Minus(res, new MyFrac(1, 1));
        }

        static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                res = Multiply(res, Minus(new MyFrac(1, 1), new MyFrac(1, i * i)));
            }
            return res;
        }

        static void Main(string[] args)
        {
            long nom_ = Convert.ToInt32(Console.ReadLine());
            long denom_ = Convert.ToInt32(Console.ReadLine());
            MyFrac myFrac = new MyFrac(nom_, denom_);
            MyFrac myFrac1 = new MyFrac(15, 40);
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nAddition of fractions\nResult : " + Plus(myFrac, myFrac1));
            Console.WriteLine("\nSubtraction of fractions\nResult : " + Minus(myFrac, myFrac1));
            Console.WriteLine("\nDouble value of fraction 1 is: {0}\nDouble value of fraction 1 is: {1}", DoubleValue(myFrac), DoubleValue(myFrac1));
            Console.WriteLine("\nMultiplication of fractions\nResult : " + Multiply(myFrac, myFrac1));
            Console.WriteLine("\nDivision of fractions\nResult : " + Divide(myFrac, myFrac1));
            Console.WriteLine("\nGetRGR113LeftSum\nResult : " + GetRGR113LeftSum(n));
            Console.WriteLine("\nGetRGR115LeftSum\nResult : " + GetRGR115LeftSum(n));
            Console.ReadKey();
        }

    }
}
