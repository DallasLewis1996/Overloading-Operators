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
            this.WholeNumber = whole;
            this.Numerator = numerator;

            if(denominator == 0)
            {
                throw new System.ArgumentException("Denominator cannot be zero");
            }
            else
            {
                denom = denominator;
                this.Denominator = denom;
            }
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

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction tempFract = new Fraction();
            int lcd;
            if (a.Denominator != b.Denominator)
            {
                lcd = a.Denominator * b.Denominator;
                tempFract.Denominator = lcd;
                tempFract.Numerator = (a.Numerator * (lcd / a.Denominator) + b.Numerator * (lcd / b.Denominator));
                tempFract.Reduce();
            }
            else
            {
                tempFract.Numerator = a.Numerator + b.Numerator;
                tempFract.Denominator = a.Denominator;
            }
                tempFract.WholeNumber = a.WholeNumber + b.WholeNumber;
            return tempFract;
        }

        public static Fraction operator -(Fraction a,Fraction b)
        {
            Fraction tempFract = new Fraction();
            int lcd;
            if (a.Denominator != b.Denominator)
            {
                lcd = a.Denominator * b.Denominator;
                tempFract.Denominator = lcd;
                tempFract.Numerator = (a.Numerator * (lcd / a.Denominator) - b.Numerator * (lcd / b.Denominator));
                tempFract.Reduce();
            }
            else
            {
                tempFract.Numerator = a.Numerator - b.Numerator;
                tempFract.Denominator = a.Denominator;
            }
            tempFract.WholeNumber = a.WholeNumber - b.WholeNumber;
            return tempFract;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction tempFract = new Fraction() { WholeNumber = a.WholeNumber * b.WholeNumber, Numerator = a.Numerator * b.Numerator, Denominator = a.Denominator * b.Denominator };

            return tempFract;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            a.MakeImproper();
            b.MakeImproper();

            int tempNum = a.Numerator * b.Denominator;
            int tempDen = a.Denominator * b.Numerator;


            Fraction tempFract = new Fraction() {Numerator = tempNum, Denominator = tempDen };
            tempFract.MakeProper();

            return tempFract;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            Fraction tempA = new Fraction(a.WholeNumber, a.Numerator, a.Denominator);
            Fraction tempB = new Fraction(b.WholeNumber, b.Numerator, b.Denominator);

            tempA.MakeImproper();
            tempB.MakeImproper();
            tempA.Reduce();
            tempB.Reduce();

            bool isEqual = (tempA.Numerator == tempB.Numerator) && (tempA.Denominator == tempB.Denominator);
            return isEqual;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            Fraction tempA = new Fraction(a.WholeNumber, a.Numerator, a.Denominator);
            Fraction tempB = new Fraction(b.WholeNumber, b.Numerator, b.Denominator);

            tempA.MakeImproper();
            tempB.MakeImproper();
            tempA.Reduce();
            tempB.Reduce();

            bool isEqual = !(tempA.Numerator == tempB.Numerator) && !(tempA.Denominator == tempB.Denominator);
            return isEqual;
        }

        public void Reduce()
        {
            int gcd = GCD(Numerator, Denominator);

            if (gcd != 0)
            {
                Numerator = Numerator / gcd;
                Denominator = Denominator / gcd;
            }
            else
            {
                Console.WriteLine("The fraction is already in it's smallest form.");
            }
        }

        public void MakeProper()
        {
            bool keepGoing = true;
            do
            {
                if ((Numerator == Denominator))
                {
                    WholeNumber = WholeNumber + 1;
                    Numerator = 0;
                }
                else if (Numerator > Denominator)
                {
                    WholeNumber = WholeNumber + 1;
                    Numerator = Numerator - Denominator;
                }
                else
                {
                    keepGoing = false;
                }
            } while (keepGoing);
        }

        public void MakeImproper()
        {
            if(WholeNumber != 0)
            {
                WholeNumber = 0;
                Numerator = Numerator + Denominator;
            }
            else
            {
                Console.WriteLine("The fraction cannot be made improper.");
            }
        }

        public void Simplify()
        {
            MakeProper();
            Reduce();
        }


        public override string ToString()
        {
            if (WholeNumber == 0)
                return Numerator + "/" + Denominator;
            else if (Numerator == 0)
                return WholeNumber + "";
            else
                return WholeNumber + " " + Numerator + "/" + Denominator;
        }

    }

    
    
}
