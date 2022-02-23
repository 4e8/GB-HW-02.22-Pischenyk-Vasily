using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLSfraction
{
    internal class Fraction
    {
        double n;
        double d;

        public Fraction()
        {
            n = 1;
            d = 1;
        }
        public Fraction(int a, int b)   //надеюсь сойдет за "свойства типа int для доступа к числителю и знаменателю"
                                        //в любой момент можно обьявить эту же переменную с любыми значениями
        {
            n = a;
            if (b != 0) d = b;
            else throw new DivideByZeroException();
        }
        public string ToString() {return $"{n}/{d}";}
        public double ToDouble() { return n / d;}

        public Fraction Simplify()
        {
            double a = n;
            double b = d;
            Fraction res = new Fraction();
            while (b != 0)
            {
                var z = b;
                b = a % b;
                a = z;
            }
            double gcd = a;
            if (gcd > 1)
            {
                n /= gcd;
                d /= gcd;
            }
       
            return this;
        }
        public Fraction Plus(Fraction y)
        {
            Fraction res = new Fraction();
            res.n = n * y.d + y.n * d;
            res.d = d * y.d;
            return res;
        }
        public Fraction Minus(Fraction y)
        {
            Fraction res = new Fraction();
            res.n = n * y.d - y.n * d;
            res.d = d * y.d;
            return res;
        }
        public Fraction Multi(Fraction y)
        {
            Fraction res = new Fraction();
            res.n = n * y.n;
            res.d = d * y.d;
            return res;
        }
        public Fraction Divide(Fraction y)
        {
            Fraction res = new Fraction();
            res.n = n * y.d;
            res.d = d * y.n;
            return res;
        }

    }
}
