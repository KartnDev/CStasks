using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task1
{
    class Program
    {
        private static double valueX, epsilon;
        private static int N;
        private const string LINE = "\n======================================================================"; 
        public static long factorial(int value)
        {
            if (value == 0)
            {
                return 1;
            }
            if(value != 1)
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

            int minus = 1;

            double rowMember = 0;


            for(int i = 1; i < n; i++)
            {
                rowMember = Math.Pow(value, 2 * i)/factorial(2 * i);
                minus *= -1;
                summ += minus * rowMember;
            }

            return summ;
        }

        public static int computeIterationsForAccuracy(double epsilon, double value)
        {
            double summ = 1;

            int minus = 1;

            double rowMember = 0;

            int iterator = 0;

            double delta = 100000;

            for (int i = 1; delta > epsilon ; i++)
            {
                rowMember = Math.Pow(value, 2 * i) / factorial(2 * i);
                minus *= -1;
                summ += minus * rowMember;

                delta = Math.Abs(Math.Cos(value) - summ);
                iterator++;
            }



            return iterator;
        }





        static void Main(string[] args)
        {
            

            // first part of the programm
            Console.WriteLine("Enter the X value...");
            valueX = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter the N for accuracy");
            N = int.Parse(Console.ReadLine());
            Console.WriteLine(LINE);

            Console.WriteLine("\nCustom cosinus:  cos({0}) = {1} \t N = {2}\n", valueX, MyCos(valueX, N), N);
            Console.WriteLine("C# cosinus: cos({0}) = {1}\n", valueX, Math.Cos(valueX));
            Console.WriteLine("The Epsilon equals: {0}\n", MyCos(valueX, N) - Math.Cos(valueX));
            Console.WriteLine(LINE);
            Console.ReadKey();
            Console.WriteLine("Secod part of programm...");
            Console.WriteLine(LINE);
            
            // the second part

            Console.WriteLine("Enter new value of X..");
            valueX = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter the epsion accuracy, whome should be intersected..");
            epsilon = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine(LINE);


            Console.WriteLine("I = {0} \titerations need to intersect corrent Epsilon = {1}", computeIterationsForAccuracy(epsilon, valueX), epsilon);




            Console.ReadKey();
        }
    }
}
