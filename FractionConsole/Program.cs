using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FractionConsole
{
    internal class Program
    {
        static int IntCorrect()
        {
            int n;
            bool isCorrect = false;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out n);
                if (isCorrect == false)
                {
                    Console.WriteLine("Помилка введення значення! Будь ласка, повторіть введення ще раз!");
                }
            } while (!isCorrect);
            return n;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.Title = "Лабораторна робота N10";
            Console.Write("Введіть значення чисельника першого дробу: ");
            int n1 = IntCorrect();
            Console.Write("Введіть значення знаменника першого дробу: ");
            int d1 = IntCorrect();
            Fraction fraction1 = new Fraction(n1, d1);
            Console.Write("Введіть значення чисельника другого дробу: ");
            int n2 = IntCorrect();
            Console.Write("Введіть значення знаменника другого дробу: ");
            int d2 = IntCorrect();
            Console.WriteLine();
            Fraction fraction2 = new Fraction(n2, d2);
            Console.WriteLine("Перший дріб: " + fraction1.ToString());
            Console.WriteLine("Другий дріб: " + fraction2.ToString());
            Console.WriteLine();
            Console.WriteLine(fraction1.ToString() + " + " + fraction2.ToString() + " = " + (fraction1 + fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " - " + fraction2.ToString() + " = " + (fraction1 - fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " * " + fraction2.ToString() + " = " + (fraction1 * fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " / " + fraction2.ToString() + " = " + (fraction1 / fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " > " + fraction2.ToString() + " = " + (fraction1 > fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " < " + fraction2.ToString() + " = " + (fraction1 < fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " >= " + fraction2.ToString() + " = " + (fraction1 >= fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " <= " + fraction2.ToString() + " = " + (fraction1 <= fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " == " + fraction2.ToString() + " = " + (fraction1 == fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " != " + fraction2.ToString() + " = " + (fraction1 != fraction2).ToString());
            Console.WriteLine(fraction1.ToString() + " = " + ((double)fraction1).ToString("F2"));
            Console.WriteLine(fraction2.ToString() + " = " + ((double)fraction2).ToString("F2"));
            Console.WriteLine(fraction1.ToString() + " = " + Fraction.Reduction(fraction1));
            Console.WriteLine(fraction2.ToString() + " = " + Fraction.Reduction(fraction2));
        }
    }
}
