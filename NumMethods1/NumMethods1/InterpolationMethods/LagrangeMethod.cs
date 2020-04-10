using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods1.InterpolationMethods
{
    public class LagrangeMethod
    {
        public static double Langrange(double value, double[] argArrayX, double[] atgArrayY, float step)
        {

            int size = atgArrayY.Length;

            double result = 0;

            for (int i = 0; i < size; i++)
            {
                double basicsPol = step;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (value - argArrayX[j]) / (argArrayX[i] - argArrayX[j]);
                    }
                }
                result += basicsPol * atgArrayY[i];
            }

            return result;
        }
    }

}
