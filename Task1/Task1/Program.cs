using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// квадрат. круг. прямоугольник. трапеция. треугольник
    /// </summary>




    //  class Vector to support the decart system coordinate
    public class Vector
    {
        private int x0;
        private int y0;
        public Vector(int x0, int y0)
        {
            this.X0 = x0;
            this.y0 = y0;
        }

        public int X0 { get => x0; set => x0 = value; }
        public int Y0 { get => y0; set => y0 = value; }

        public static double GetSide(Vector LeftVector, Vector RightVector)
        {
            return Math.Sqrt(Math.Abs((RightVector.X0 - LeftVector.X0) * (RightVector.X0 - LeftVector.X0) + (RightVector.y0 - LeftVector.y0) * (RightVector.X0 - LeftVector.y0)));
        }

    }



    public abstract class Figure
    {
        public static readonly double PI = 3.14159265359;

        public double SquareOfFigure;
        public double PerimeterOfFigure;

        protected abstract double ComputeSquare(Vector FirstVector, Vector LastVector);
        protected abstract double ComputePerimeter(Vector FirstVector, Vector LastVector);

    }

    public class Circle : Figure
    {
        public Circle(Vector CircleCenter, Vector CircleLinepoint)
        {
            SquareOfFigure = ComputeSquare(CircleCenter, CircleLinepoint);
            PerimeterOfFigure = ComputePerimeter(CircleCenter, CircleLinepoint);
        }

        protected override double ComputePerimeter(Vector CircleCenter, Vector CircleLinepoint)
        {
            double Radius = Vector.GetSide(CircleCenter, CircleLinepoint);
            return Figure.PI * Radius * Radius;
        }

        protected override double ComputeSquare(Vector CircleCenter, Vector CircleLinepoint)
        {
            double Radius = Vector.GetSide(CircleCenter, CircleLinepoint);
            return 2 * Figure.PI * Radius;
        }
    }

    public class Rectangle : Figure
    {

        public Rectangle(Vector LeftLowerPoint, Vector RightTopPoint)
        {
            SquareOfFigure = ComputeSquare(LeftLowerPoint, RightTopPoint);
            PerimeterOfFigure = ComputePerimeter(LeftLowerPoint, RightTopPoint);
        }

        protected override double ComputePerimeter(Vector LeftLowerPoint, Vector RightTopPoint)
        {
            return (RightTopPoint.X0 - LeftLowerPoint.X0) * (RightTopPoint.Y0 - LeftLowerPoint.Y0);
        }

        protected override double ComputeSquare(Vector LeftLowerPoint, Vector RightTopPoint)
        {
            return Vector.GetSide(LeftLowerPoint, RightTopPoint) * Vector.GetSide(LeftLowerPoint, RightTopPoint);
        }
    }

    public class Square : Figure
    {

        public Square(Vector FirstPoint, Vector NearestPointofFirst)
        {
            SquareOfFigure = ComputeSquare(FirstPoint, NearestPointofFirst);
            PerimeterOfFigure = ComputePerimeter(FirstPoint, NearestPointofFirst);
        }
        protected override double ComputePerimeter(Vector FirstPoint, Vector NearestPointofFirst)
        {
            return Vector.GetSide(FirstPoint, NearestPointofFirst) * Vector.GetSide(FirstPoint, NearestPointofFirst);
        }
        protected override double ComputeSquare(Vector FirstPoint, Vector NearestPointofFirst)
        {
            return 4 * Vector.GetSide(FirstPoint, NearestPointofFirst);
        }
    }

    public class Triangle : Figure
    {

        public Triangle(Vector First, Vector Second, Vector Third)
        {
            SquareOfFigure = ComputeSquare(First, Second, Third);
            PerimeterOfFigure = ComputePerimeter(First, Second, Third);
        }

        protected override double ComputePerimeter(Vector FirstVector, Vector LastVector) // NO_IMPLEMENTATION_HERE
        {
            // not enought points to compute the Perimeter of triangle
            // this function doesnt have any logics and implementation
            throw new NotImplementedException();
        }


        protected override double ComputeSquare(Vector FirstVector, Vector LastVector) // NO_IMPLEMENTATION_HERE
        {

            // not enought points to compute the Square of triangle
            // this function doesnt have any logics and implementation
            throw new NotImplementedException();
        }

        protected double ComputeSquare(Vector First, Vector Second, Vector Third)
        {
            // matrix determinant 2D square
            return 0.5 * Math.Abs(First.X0 * Second.Y0 + Third.X0 * First.Y0 + Second.X0 * Third.Y0 - Third.X0 * Second.Y0 - First.X0 * Third.Y0 - Second.X0 * First.Y0);
        }

        protected double ComputePerimeter(Vector First, Vector Second, Vector Third)
        {
            double FirstToSecondSide = Math.Sqrt((Second.X0 - First.X0) * (Second.X0 - First.X0) + (Second.Y0 - First.Y0) * (Second.Y0 - First.Y0));
            double SecondToThirdSide = Math.Sqrt((Third.X0 - Second.X0) * (Third.X0 - Second.X0) + (Third.Y0 - Second.Y0) * (Third.Y0 - Second.Y0));
            double ThirdToFirstSide = Math.Sqrt((First.X0 - Third.X0) * (First.X0 - Third.X0) + (First.Y0 - Third.Y0) * (First.Y0 - Third.Y0));
            return FirstToSecondSide + SecondToThirdSide + ThirdToFirstSide;

        }

    }


    public class Trapezium : Figure
    {

        public Trapezium(Vector LeftLowerPoint, Vector LeftTopPoint, Vector RightTopPoint, Vector RightLowerPoint)
        {
            SquareOfFigure = ComputeSquare(LeftLowerPoint, LeftTopPoint, RightTopPoint, RightLowerPoint);
            PerimeterOfFigure = ComputePerimeter(LeftLowerPoint, LeftTopPoint, RightTopPoint, RightLowerPoint);
        }

        protected override double ComputePerimeter(Vector FirstVector, Vector LastVector) // NO_IMPLEMENTATION_HERE
        {
            // not enought points to compute the Perimeter of triangle
            // this function doesnt have any logics and implementation
            throw new NotImplementedException();
        }

        protected override double ComputeSquare(Vector FirstVector, Vector LastVector) // NO_IMPLEMENTATION_HERE
        {
            // not enought points to compute the Square of triangle
            // this function doesnt have any logics and implementation
            throw new NotImplementedException();
        }


        protected double ComputePerimeter(Vector LeftLowerPoint, Vector LeftTopPoint, Vector RightTopPoint, Vector RightLowerPoint)
        {
            double SideLeft = Vector.GetSide(LeftLowerPoint, LeftTopPoint);
            double SideRight = Vector.GetSide(RightLowerPoint, RightTopPoint);
            double SideLower = Vector.GetSide(LeftLowerPoint, RightLowerPoint);
            double SideTop = Vector.GetSide(RightTopPoint, LeftTopPoint);
            return SideLeft + SideLower + SideRight + SideTop;

        }
        protected double ComputeSquare(Vector LeftLowerPoint, Vector LeftTopPoint, Vector RightTopPoint, Vector RightLowerPoint)
        {
            double HalfPerimeter = ComputePerimeter(LeftLowerPoint, LeftTopPoint, RightTopPoint, RightLowerPoint) / 2;
            double Height = LeftTopPoint.Y0 / LeftLowerPoint.Y0;
            return Height * HalfPerimeter;
        }
    }


    public class Program
    {

        public static void getResultDataOfFigures(ICollection<Figure> Collection)
        {
            double ResultSquare = 0;
            double ResultPerimeter = 0;

            foreach (Figure item in Collection)
            {
                ResultPerimeter += item.PerimeterOfFigure;
                ResultSquare += item.SquareOfFigure;
            }


            Console.WriteLine("Суммарная площадь фигур: " + ResultSquare + "\n\rСуммарный периметр фигур: " + ResultPerimeter); 

        }


        static void Main(string[] args)
        {
            LinkedList<Figure> Figures = new LinkedList<Figure>();
            Figures.AddFirst(new Circle(new Vector(1110, 1110), new Vector(1110, 1120)));
            Figures.AddFirst(new Rectangle(new Vector(20, 20), new Vector(24, 34)));
            Figures.AddFirst(new Square(new Vector(120, 124), new Vector(134, 154)));
            Figures.AddFirst(new Triangle(new Vector(1000, 1000), new Vector(1200, 1000), new Vector(1230, 1230)));
            Figures.AddFirst(new Trapezium(new Vector(1, 1), new Vector(2, 4), new Vector(10, 4), new Vector(1, 10)));
            getResultDataOfFigures(Figures);
            

        }
    }
}

