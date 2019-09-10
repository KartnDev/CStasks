using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task2
{
    public partial class Form1 : Form
    {

        private Point firstPointOfLIne;
        private Point lastPointOfLine;
        private Rectangle pseudoPixel;

        public Form1()
        {
            InitializeComponent();

            firstPointOfLIne = new Point(Width - 200, 150);
            lastPointOfLine = new Point(200, 10);
            pseudoPixel = new Rectangle(20, 20, 20, 20);
        }

        private class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X { get; }
            public int Y { get; }
        }

        
        private void 



        void BresenhamLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0); // Проверяем рост отрезка по оси икс и по оси игрек
                                                               // Отражаем линию по диагонали, если угол наклона слишком большой
            if (steep)
            {
                Swap(ref x0, ref y0); // Перетасовка координат вынесена в отдельную функцию для красоты
                Swap(ref x1, ref y1);
            }
            // Если линия растёт не слева направо, то меняем начало и конец отрезка местами
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2; // Здесь используется оптимизация с умножением на dx, чтобы избавиться от лишних дробей
            int ystep = (y0 < y1) ? 1 : -1; // Выбираем направление роста координаты y
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                DrawPoint(steep ? y : x, steep ? x : y); // Не забываем вернуть координаты на место
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            double angularCoef = (lastPointOfLine.Y - firstPointOfLIne.Y) / (lastPointOfLine.X - firstPointOfLIne.X);

        }
    }
}
