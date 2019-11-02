using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task3_WinForm
{
    class CirclesHandler
    {
        private List<Circle> circles;

        private readonly int HEIGHT;
        private readonly int WIDTH;
        public CirclesHandler(IEnumerable<Circle> circles, int fieldHeight, int fieldWidth)
        {
            HEIGHT = fieldHeight;
            WIDTH = fieldWidth;
            this.circles = new List<Circle>(circles);
        }

        public KeyValuePair<int, int> FirstPointOrDefualt()
        {

            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    foreach (var circle in circles)
                    {
                        int iter = 0;
                        if (intersentPoint(circle, i, j))
                        {
                            iter++;
                            if(iter == circles.Count)
                            {
                                return new KeyValuePair<int, int>(i, j);
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Null");
            return default(KeyValuePair<int, int>);
        }

        private bool intersentPoint(Circle correntCircle, double pointPosX, double pointPosY)
        {
            double distanceBetweenCenterAndPoint = Math.Sqrt(
                (correntCircle.CenterPointX - pointPosX) * (correntCircle.CenterPointX - pointPosX) +
                (correntCircle.CenterPointY - pointPosY) * (correntCircle.CenterPointY - pointPosY));
            return correntCircle.Raduis > distanceBetweenCenterAndPoint ? true : false;
        }

    }
}
