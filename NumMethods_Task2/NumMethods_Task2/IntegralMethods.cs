using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods_Task2
{
    public class IntegralMethods
    {
        public delegate double Function(double x);


        private Function func;
        public IntegralMethods(Function func)
        {
            this.func = func;
        }

        public double RectangularIntegral(double lowerBorder, double upperBorder, int steps)
        {
            double value;
            double sum = 0;

            double width = (upperBorder - lowerBorder) / steps;
            for (int i = 1; i <= steps; i++)
            {
                value = lowerBorder + (i - 0.5) * width;
                sum += func(value);
            }

            return width * sum;
        }


        public double TrapezoidIntegral(double lowerBorder, double upperBorder, int steps)
        {
            double value;
            int i;

            double sum = func(lowerBorder);
            double width = (upperBorder - lowerBorder) / steps;

            for (i = 1; i < steps; i++)
            {
                value = lowerBorder + i * width;
                sum += 2 * func(value);
            }

            value = lowerBorder + steps * width;
            sum += func(value);

            return 0.5 * width * sum;
        }

        public double SimpsonIntegral(double lowerBorder, double upperBorder, int steps)
        {
            double value;
            int temp;

            double sum = func(lowerBorder);
            double width = (upperBorder - lowerBorder) / steps;

            for (int i = 1; i < steps; i++)
            {
                value = lowerBorder + i * width;
                if (i % 2 == 0)
                {
                    temp = 2;
                }
                else
                {
                    temp = 4;
                }
                sum += temp * func(value);
            }

            value = lowerBorder + steps * width;
            sum += func(value);

            return 0.33333 * width * sum;
        }

        public delegate double Integral(double lowerBorder, double upperBorder, int steps);



        public double ComputeWithAcc(double valueX, double lowerA, double upperB, double eps, Integral integral)
        {
            int currentStep = 10;

            double result = 0;

            double minAccIntegralVaue = integral(lowerA, upperB, 10); // //Computing value of intercal with rough accuracy

            while (Math.Abs(result - minAccIntegralVaue) > eps)
            {
                result = integral(lowerA, upperB, currentStep);
                currentStep += 1; // Can be 10 or 1000 for accuracy or speed
            }
            return result;
        }

    }
}
