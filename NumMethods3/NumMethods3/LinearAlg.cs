using System;

namespace NumMethods3
{
    public static class LinealAlg
    {

        public static double MaxError = 0.00001;
        public static double MaxIteration = 100;
        public static double Lambda = 0.5;


        public static double[] GaussSeidel(double[][] leftSideCoefs, double[] rightSideConstants, double[] probVector)
        {
            int n = leftSideCoefs.Length;

            //Division by the diagonal element to reduce calculation
            for (int i = 0; i < n; i++)
            {
                double d = leftSideCoefs[i][i];
                for (int j = 0; j < n; j++)
                {
                    leftSideCoefs[i][j] = leftSideCoefs[i][j] / d;
                }
                rightSideConstants[i] = rightSideConstants[i] / d;
            }

            //Generation of initial values for roots
            for (int i = 0; i < n; i++)
            {
                double sum = rightSideConstants[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum -= (leftSideCoefs[i][j] * probVector[j]);
                    }
                }
                probVector[i] = sum;
            }

            //Iterations for converging to the real roots
            for (int itr = 1; itr < MaxIteration; itr++)
            {

                for (int i = 0; i < n; i++)
                {
                    double old = probVector[i];
                    double sum = rightSideConstants[i];

                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                            sum -= (leftSideCoefs[i][j] * probVector[j]);
                    }

                    probVector[i] = Lambda * sum + (1 - Lambda) * old;
                    if (probVector[i] != 0)
                    {
                        double ea = Math.Abs((probVector[i] - old) / probVector[i]) * 100;
                        if (ea < MaxError)
                            return probVector;
                    }
                }
            }

            return probVector;
        }
    }
}