using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FractionConsole
{
    public class Fraction
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }
        public Fraction()
        {
            Numerator = 0;
            Denominator = int.MinValue;
        }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        public Fraction(int denominator)
        {
            Numerator = 0;
            Denominator = denominator;
        }
        public Fraction(Fraction duplicate)
        {
            Numerator = duplicate.Numerator;
            Denominator = duplicate.Denominator;
        }
        public double GetValue()
        {
            return Numerator / Denominator;
        }
        public void SetNumerator(int num)
        {
            Numerator = num;
        }
        public void SetDenominator(int den)
        {
            Denominator = den;
        }
        public int GetNumerator()
        { 
            return Numerator; 
        }
        public int GetDenominator()
        {
            return Denominator;
        }
        public static void MaxMinDenominator(Fraction fraction1, Fraction fraction2, out int min, out int max)
        {
            if (fraction1.Denominator > fraction2.Denominator)
            {
                max = fraction1.Denominator;
                min = fraction2.Denominator;
            }
            else
            {
                min = fraction1.Denominator;
                max = fraction2.Denominator;
            }
        }
        public static int CommonDenominator(Fraction fraction1, Fraction fraction2)
        {
            MaxMinDenominator(fraction1, fraction2, out int maxDen, out int minDen);
            int newDenominator;
            if (fraction1.Denominator == fraction2.Denominator)
            {
                return newDenominator = fraction1.Denominator;
            }
            else if (maxDen % minDen == 0)
            {
                int mult = maxDen / minDen;
                return newDenominator = minDen * mult;
            }
            else
            {
                int product = minDen * maxDen;
                int res;
                do
                {
                    res = maxDen % minDen;
                    maxDen = minDen;
                    minDen = res;
                } while (res != 0);
                return newDenominator = product / maxDen;
            }
        }
        public static void ToSameDenominator(Fraction fraction1, Fraction fraction2, out int newDen, out int newNum1, out int newNum2)
        {
            newDen = CommonDenominator(fraction1, fraction2);
            int mult1 = newDen / fraction1.Denominator;
            int mult2 = newDen / fraction2.Denominator;
            newNum1 = fraction1.Numerator * mult1;
            newNum2 = fraction2.Numerator * mult2;
        }
        public override bool Equals(object obj)
        {
            return obj is Fraction fraction &&
                   Numerator == fraction.Numerator &&
                   Denominator == fraction.Denominator;
        }
        public override int GetHashCode()
        {
            int hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + Denominator.GetHashCode();
            return hashCode;
        }

        public static Fraction operator +(Fraction fraction)
        {
            return new Fraction(fraction);
        }
        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return new Fraction(newN1 + newN2, newD);
        }
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return new Fraction(newN1 - newN2, newD);
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);
        }
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Denominator, fraction1.Denominator * fraction2.Numerator);
        }
        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 > newN2;
        }
        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 < newN2;
        }
        public static bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 >= newN2;
        }
        public static bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 <= newN2;
        }
        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 == newN2;
        }
        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            ToSameDenominator(fraction1, fraction2, out int newD, out int newN1, out int newN2);
            return newN1 != newN2;
        }
        public static explicit operator double(Fraction fraction) => (double)fraction.Numerator/(double)fraction.Denominator;
        public static string Reduction(Fraction fraction)
        {
            Fraction fraction2 = new Fraction(fraction);
            if (fraction.Numerator == fraction.Denominator)
            {
                fraction2.Numerator = 1;
                fraction2.Denominator = 1;
                return fraction2.ToString();
            }
            else
            {
                int res = 0, min, max;
                if (fraction2.Numerator > fraction2.Denominator)
                {
                    max = fraction2.GetNumerator();
                    min = fraction2.GetDenominator();
                }
                else
                {
                    min = fraction2.GetNumerator();
                    max = fraction2.GetDenominator();
                }
                for (int i = 2; i < min; i++)
                {
                    if (fraction2.Numerator % i == 0 && fraction2.Denominator % i == 0)
                    {
                        fraction2.Numerator /= i;
                        fraction2.Denominator /= i;
                    }
                }
                double dr = fraction2.Numerator / fraction2.Denominator;
                int intPart = (int)Math.Floor(dr);
                string reducted;
                if (fraction2.Numerator > fraction2.Denominator)
                {
                    fraction2.Numerator -= intPart * fraction2.Denominator ;
                    return reducted = intPart.ToString() + "(" + fraction2.ToString() + ")";
                }
                else return fraction2.ToString();   
            }
        }
        public override string ToString()
        {
            if (GetValue() < 0)
            {
                return $"{-Numerator}/{Denominator}";
            }
            else
            {
                return $"{+Numerator}/{Denominator}";
 
            }
        }
            
    }
}
