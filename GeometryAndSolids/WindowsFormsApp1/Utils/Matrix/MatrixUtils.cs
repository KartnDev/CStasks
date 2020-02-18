using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Utils.Matrix
{
    public static class MatrixUtils
    {
        public static double[,] matrixMultiply(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
        public static double[,] matrixShift(double[,] matrix1, double[] vector)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i,j] = matrix1[i,j] + vector[j];
                }
            }
            return result;
        }
        public static double[][] matrixTranspose(double[][] matrix)
        {
            return null;
        }

        public static String matrixToString(double[][] matrix)
        {
            String result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i][j] + "  ";
                }
                result += '\n';
            }
            return result;
        }

    }
}
