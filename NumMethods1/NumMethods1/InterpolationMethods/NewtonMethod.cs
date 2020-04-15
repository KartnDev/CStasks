using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods1.InterpolationMethods
{
    public class NewtonMethod
    {
        public static double Newton(double value, double[] argArrayX, double[] argArrayY, double step)
        {
            double[,] matriix = new double[argArrayY.Length + 1, argArrayY.Length];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < argArrayY.Length; j++)
                {
                    if (i == 0)
                    {
                        matriix[i, j] = argArrayX[j];
                    }
                    else if (i == 1)
                    {
                        matriix[i, j] = argArrayY[j];
                    }
                }
            }
            int temp = argArrayY.Length -1;
            for (int i = 2; i < argArrayY.Length + 1; i++)
            {
                for (int j = 0; j < temp; j++)
                {
                    matriix[i, j] = matriix[i - 1, j + 1] - matriix[i - 1, j];
                }
                temp--;
            }

            double[] dy0 = new double[argArrayY.Length];

            for (int i = 0; i < argArrayY.Length; i++)
            {
                dy0[i] = matriix[i + 1, 0];
            }

            double result = dy0[0];
            double[] newMatrix = new double[argArrayY.Length];
            newMatrix[0] = value - matriix[0, 0];

            for (int i = 1; i < argArrayY.Length; i++)
            {
                double ans = newMatrix[i - 1] * (value - matriix[0, i]);
                newMatrix[i] = ans;
                ans = 0;
            }

            int m1 = argArrayY.Length;
            int fact = 1;
            for (int i = 1; i < m1; i++)
            {
                fact = fact * i;
                result = result + (dy0[i] * newMatrix[i - 1]) / (fact * Math.Pow(step, i));
            }

            return result;
        }
    }
}
