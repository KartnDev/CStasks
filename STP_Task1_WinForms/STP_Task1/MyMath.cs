using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task1
{
    public class MyMath
    {

        public static long factorial(int value)
        {
            if (value == 0)
            {
                return 1;
            }
            if (value != 1)
            {
                return value * factorial(value - 1);
            }
            else
            {
                return 1;
            }
        }


        public static double MyCos(double value, int n)
        {
            double summ = 1;

            double rowMember = 1;

            for (int i=1, f = 1; i < n; i++, f+=2)
            {

                rowMember *= -value * value / (2 * i - 1) /( 2 * i); //Math.Pow(value, 2*i) / fact;

                summ += rowMember;
            }

            return summ;
        }

        public static int computeIterationsForAccuracy(double epsilon, double value)
        {
            double summ = 1;
            int minus = 1;
            double rowMember = 0;
            int iterator = 0;

            double delta = 1;

            long fact = 2;

            for (int i = 1, f = 1; delta > epsilon; i++, f += 2)
            {
                rowMember = Math.Pow(value, 2*i) / fact;
                minus *= -1;
                fact *= (f + 2) * (f + 3);
                summ += minus * rowMember;

                Console.WriteLine(summ + " <> " + Math.Cos(value));

                delta = Math.Abs(Math.Cos(value) - summ);
                iterator++;
            }

            return iterator;
        }

    }
}
