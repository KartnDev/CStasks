using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task3_WinForm
{
    public class Circle
    {
        public double CenterPointX { get; private set; }
        public double CenterPointY { get; private set; }
        public double Raduis { get; private set; }
        public Circle(int posXCenter, int posYCenter, double radius)
        {
            this.CenterPointY = posXCenter;
            this.CenterPointY = posYCenter;
            this.Raduis = radius;
        }
    }
}
