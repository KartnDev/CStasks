using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task3_WinForm_
{
    public class Circle
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Radius { get; private set; }
        public Circle(double x, double y, double radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }
    }


}
