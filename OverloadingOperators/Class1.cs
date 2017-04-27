using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingOperators
{
    public struct Fraction
    {
        private int denom;
        public int WholeNumber { get; set; }
        public int Denominator { get; set; } 
        public int Numerator { get; set; } 

        public Fraction(int whole = 0, int numerator = 0, int denominator = 1)
        {

        }

        public static int GCD(int m, int n)
        {
            if (m == 0)
                return n;
            if (n == 0)
                return m;

            if(m > n)
            {
                return GCD(m % n, n);
            }
            else
            {
                return GCD(m, n % m);
            }
        }

    }

    
    
}
