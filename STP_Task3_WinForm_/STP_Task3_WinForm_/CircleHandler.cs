using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task3_WinForm_
{
    public class CircleHandler
    {
        private List<Circle> circles;
        private readonly int HEIGHT;
        private readonly int WIDTH;
        public CircleHandler(IEnumerable<Circle> circles, int height, int width)
        {
            this.circles = circles.ToList();
            this.HEIGHT = height;
            this.WIDTH = width;
        }

        public KeyValuePair<int, int> FirstPointOrDefualt()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if(IsPointHaveInAllC(i, j))
                    {
                        return new KeyValuePair<int, int>(i, j);
                    }
                }
            }
            return new KeyValuePair<int, int>(-1, -1);
            //return defualt(KeyValuePair<int, int>;
        }

        private bool IsPointHaveInAllC(int x, int y)
        {
            int flag = 0;
            foreach (var circle in circles)
            {
                if(IntersentPoint(circle, x, y))
                {
                    flag++;
                }
            }
            return flag == circles.Count;
        }

        public static bool IntersentPoint(Circle correntCircle, double pointPosX, double pointPosY)
        {
            double distanceBetweenCenterAndPoint = Math.Sqrt(
                (correntCircle.X - pointPosX) * (correntCircle.X - pointPosX) +
                (correntCircle.Y - pointPosY) * (correntCircle.Y - pointPosY));
            return correntCircle.Radius > distanceBetweenCenterAndPoint ? true : false;
        }



    }
}
