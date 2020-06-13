using System;

namespace NumMethods4
{
    public class DiffMethods
    {

        private static double func(double x, double y) 
        {
            return  100*Math.Sin(x/10) / y;
        }


        public static double Adams(double x0, double y0, double xat, double hSteps)
        {
            double h = hSteps; //шаг
            int n = (int)((xat - x0) / h); //кол во точек

            double[] x = new double[n];
            double[] y = new double[n];
            double[] f = new double[n];
            x[0] = x0;
            y[0] = y0; // начальная задача коши
            f[0] = func(x[0], y[0]);


            x[1] = x[0] + h;
            y[1] = y[0] + h * f[0];
            f[1] = func(x[1], y[1]);

            x[2] = x[1] + h;
            y[2] = y[1] + h * (3 / 2 * f[1] - 1 / 2 * f[0]);
            f[2] = func(x[2], y[2]);

            x[3] = x[2] + h;
            y[3] = y[2] + h / 12 * (23 * f[2] - 16 * f[1] + 5 * f[0]);
            f[3] = func(x[3], y[3]);

            for (int i = 3; i < n - 1; i++)
            {
                y[i + 1] = y[i] + h / 24 * (55 * f[i] - 59 * f[i - 1] + 37 * f[i - 2] - 9 * f[i - 3]);
                x[i + 1] = x[i] + h;
                f[i + 1] = func(x[i + 1], y[i + 1]);
            }
            return y[n-1];
        }

        public static double EulerCounting(double x0, double y0, double xat, double hSteps)
        {
            double h = hSteps; // шаг
            int n = (int)((xat - x0) / h); //кол во точек

            double[] x = new double[n];
            double[] y = new double[n];

            x[0] = x0;
            y[0] = y0; // начальная задача коши

            double yii;

            for (int i = 0; i < n - 1; i++)
            {
                yii = y[i] + h * func(x[i], y[i]);
                y[i + 1] = y[i] + h / 2 * (func(x[i], y[i]) + func(x[i] + h, yii));
                x[i + 1] = x[i] + h;
            }

            return y[n-1];
        }


        public static double RungeKutta(double x0, double y0, double xat, double hSteps)
        {
            double а = 0, b = 1; //отрезок, на  котором ищется у(х)
            double h = hSteps; // шаг
            int n = (int)((xat - x0) / h); //кол во точек

            double[] x = new double[n];
            double[] y = new double[n];

            x[0] = x0;
            y[0] = y0; // начальная задача коши

            double k0, k1, k2, k3;

            for (int i = 0; i < n - 1; i++)
            {
                k0 = func(x[i], y[i]);
                k1 = func(x[i] + h / 2, y[i] + h * k0 / 2);
                k2 = func(x[i] + h / 2, y[i] + h * k1 / 2);
                k3 = func(x[i] + h, y[i] + h * k2);

                y[i + 1] = y[i] + h / 6 * (k0 + 2 * k1 + 2 * k2 + k3);
                x[i + 1] = x[i] + h;
            }

            return y[n - 1];
        }

        public static double ModifiedEuler(double x0, double y0, double xat, double hSteps)
        {
            double а = 0, b = 1; //отрезок, на  котором ищется у(х)
            double h = hSteps; // шаг
            int n = (int)((xat - x0) / h); //кол во точек

            double[] x = new double[n];
            double[] y = new double[n];

            x[0] = x0;
            y[0] = y0; // начальная задача коши

            double y12;
            for (int i = 0; i < n - 1; i++)
            {
                y12 = y[i] + h / 2 * func(x[i], y[i]);
                y[i + 1] = y[i] + h * func(x[i] + h / 2, y12);
                x[i + 1] = x[i] + h;
            }
            return y[n - 1];
        }
    }
}