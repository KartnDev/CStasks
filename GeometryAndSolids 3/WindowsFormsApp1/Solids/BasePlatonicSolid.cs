using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Utils.Matrix;

namespace WindowsFormsApp1.Solids
{
    public abstract class BasePlatonicSolid : ISolid
    {
        protected double[,] matrix;

        protected int centerPlateX; // central point of base(footage) tetrahedron
        protected int centerPlateY;
        protected int centerPlateZ;

        protected int imaginaryRadius;

        public BasePlatonicSolid(int centerPlateOfX, int centerPlateOfY, int centerPlateOfZ, int imaginaryRadius)
        {
            this.centerPlateX = centerPlateOfX;
            this.centerPlateY = centerPlateOfY;
            this.centerPlateZ = centerPlateOfZ;
            this.imaginaryRadius = imaginaryRadius;
        }

        public abstract void DrawSolid(Graphics g, double coef, double alpha);

        public double[,] GetMatrix()
        {
            if (matrix != null)
            {
                return matrix;
            }
            else
            {
                throw new NullReferenceException("Does not contain reference to this matrix array! ");
            }
        }



        public void RotateByX(double angle)
        {
            matrix = MatrixUtils.matrixMultiply(matrix, new double[,] {{1,      0              ,    0},
                                                                      {0,       Math.Cos(angle),    Math.Sin(angle)},
                                                                      {0,       -Math.Sin(angle),    Math.Cos(angle)}});
        }


        public void RotateByY(double angle)
        {
            matrix = MatrixUtils.matrixMultiply(matrix, new double[,] {{Math.Cos(angle),      0              ,    Math.Sin(angle)},
                                                                      {0,                     1              ,    0},
                                                                      {-Math.Sin(angle),      0              ,    Math.Cos(angle)}});
        }

        public void RotateByZ(double angle)
        {
            matrix = MatrixUtils.matrixMultiply(matrix, new double[,] {{Math.Cos(angle),    Math.Sin(angle) ,    0},
                                                                      {-Math.Sin(angle),    Math.Cos(angle) ,    0},
                                                                      {0,                   0               ,    1}});

        }


        public void RotateByUnitVector(double angle, double unitX, double unitY, double unitZ)
        {
            matrix = MatrixUtils.matrixMultiply(matrix, new double[,]


            {{Math.Cos(angle) + (1 - Math.Cos(angle))* unitX*unitX,               (1 - Math.Cos(angle))* unitX * unitY - Math.Sin(angle)* unitZ ,     (1 - Math.Cos(angle))* unitX * unitZ + Math.Sin(angle) * unitY},
            {(1 - Math.Cos(angle))* unitX * unitY + Math.Sin(angle) * unitZ,      Math.Cos(angle) + (1 - Math.Cos(angle))* unitY * unitY,             (1 - Math.Cos(angle))* unitZ * unitY - Math.Sin(angle)* unitX},
            {(1 - Math.Cos(angle))* unitX * unitZ - Math.Sin(angle)* unitY,       (1 - Math.Cos(angle))* unitZ * unitY + Math.Sin(angle)* unitX,      Math.Cos(angle) + (1 - Math.Cos(angle))* unitZ * unitZ}});

        }




        public void Scale(double scaleX, double scaleY, double scaleZ)
        {
            matrix = MatrixUtils.matrixMultiply(matrix, new double[,] {{scaleX,   0,         0},
                                                                      {0,         scaleY,    0},
                                                                      {0,         0,         scaleZ}});
        }

        public void Scew(double scale)
        {
            throw new NotImplementedException();
        }

        public void Shift(double dx, double dy, double dz)
        {
            matrix = MatrixUtils.matrixShift(matrix, new double[] { dx, dy, dz });
        }


        public Point[] ToPointArray(double coef, double alpha)
        {
            Point[] points = new Point[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                points[i] = new Point((int)(matrix[i, 0] + coef * Math.Cos(alpha) * matrix[i, 2]),
                                      (int)(matrix[i, 1] + coef * Math.Sin(alpha) * matrix[i, 2]));
            }
            return points;
        }


        public override String ToString()
        {
            var result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += "X" + i + "=" + matrix[i, 0] + ", Y" + i + "=" + matrix[i, 1] + "Z" + i + "=" + matrix[i, 2];
            }
            return result;
        }


    }
}
