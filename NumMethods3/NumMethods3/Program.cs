using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumMethods3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] leftSideCoefs = new double[3][];

            // 4x+ y+ 2z= 4
            // 3x + 5y + 1z = 7
            // x + y + 3z = 3

            // Solve: {0.5, 1.0, 0.5}


            leftSideCoefs[0] = new double[3] { 4, 1, 2};
            leftSideCoefs[1] = new double[3] { 3, 5, 1 };
            leftSideCoefs[2] = new double[3] { 1, 1, 3 };

            double[] rightSideConstants =  new double[] {4, 7, 3};

            double[] probablyRoots = new double[] { 0, 0, 0 };


            var res = LinealAlg.GaussSeidel(leftSideCoefs, rightSideConstants, probablyRoots);

            Console.WriteLine("Solve: ");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.Read();

        }
    }
}
