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

    public class Vector
    {
        private int x0, y0;
        public Vector(int x0, int y0)
        {
            this.x0 = x0;
            this.y0 = y0;
        }
        public static double GetSide(Vector LeftVector, Vector RightVector)
        {
            return Math.Sqrt((RightVector.x0 - LeftVector.x0) * (RightVector.x0 - LeftVector.x0) + (RightVector.y0 - LeftVector.y0) * (RightVector.x0 - LeftVector.y0));
        }

    }



    public abstract class Figure 
    {
        public static readonly double PI = 3.14159265359;

        public double SquareOfFigure; 
        public double PerimeterOfFigure;

        protected abstract double computeSquare(Vector FirstVector, Vector LastVector);
        protected abstract double computePerimeter(Vector FirstVector, Vector LastVector);

    }

    public class Circle : Figure
    {
        public Circle(Vector CircleCenter, Vector CircleLinepoint)
        {
            SquareOfFigure = computeSquare(CircleCenter, CircleLinepoint);
            PerimeterOfFigure = computePerimeter(CircleCenter, CircleLinepoint);
        }

        protected override double computePerimeter(Vector CircleCenter, Vector CircleLinepoint)
        {
            double Radius = Vector.GetSide(CircleCenter, CircleLinepoint);
            Console.WriteLine(Radius);
            return Figure.PI * Radius * Radius;
        }

        protected override double computeSquare(Vector CircleCenter, Vector CircleLinepoint)
        {
            double Radius = Vector.GetSide(CircleCenter, CircleLinepoint);
            return 2 * Figure.PI * Radius;
        }
    }

    public class Rectangle : Figure
    {
        protected override double computePerimeter(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }

        protected override double computeSquare(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }
    }

    public class Square : Figure
    {
        protected override double computePerimeter(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }

        protected override double computeSquare(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }
    }

    public class Triangle : Figure
    {
        protected override double computePerimeter(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }

        protected override double computeSquare(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }
    }

  


    public class Trapezium : Figure
    {

        protected override double computePerimeter(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }

        protected override double computeSquare(Vector FirstVector, Vector LastVector)
        {
            throw new NotImplementedException();
        }
    }



    class Program
    {

        void result(ICollection<Figure> Collection)
        {
           foreach(Figure item in Collection)
            {

            }
        }



        static void Main(string[] args)
        {
            LinkedList<Figure> Figures = new LinkedList<Figure>();
            Figures.AddFirst(new Circle(new Vector(0, 0), new Vector(42, 0)));




            Circle circle = new Circle(new Vector(0, 0), new Vector(42, 0));
            Console.WriteLine(circle.PerimeterOfFigure + "\n" + circle.SquareOfFigure);
            Console.Read();
            
        }
    }
}
