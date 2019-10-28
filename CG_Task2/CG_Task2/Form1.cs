using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_task2
{
    public partial class Form1 : Form
    {
        private const int accretion = 2;


        private static readonly int WIDTH = accretion;
        private static readonly int HEIGHT = accretion;

        public Form1()
        {
            InitializeComponent();

        }

        private static void DrawPixel(Graphics g, Color color, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, color)), x, y, WIDTH, HEIGHT);
        }


        public void DrawBrezinheimLine(Graphics graphics, Color color, int x0, int y0, int x1, int y1)
        {
            // Coordinte change speed
            // Can be changed to Abs
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);

            //accretion choose
            int signX = (x1 >= x0) ? (accretion) : (-accretion);
            int signY = (y1 >= y0) ? (accretion) : (-accretion);


            // Is Ox accration faster then Oy ? 
            if (dy < dx)
            {

                // D = 2dy - dx 
                int d = (dy << 1) - dx;
                int d1 = dy << 1;
                int d2 = (dy - dx) << 1;

                // drawing zeroed - pixel
                DrawPixel(graphics, color, x0, y0, 255);

                int x = x0 + signX;
                int y = y0;

                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += signY;
                    }
                    else
                    {
                        d += d1;
                    }

                    DrawPixel(graphics, color, x, y, 255);

                    x += signX;
                }
            }
            else
            {
                int d = (dx << 1) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;

                DrawPixel(graphics, color, x0, y0, 255);

                int x = x0;
                int y = y0 + signY;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += signX;
                    }
                    else
                        d += d1;

                    DrawPixel(graphics, color, x, y, 255);

                    y += signY;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Entry textboxes..");

            }
            else
            {
                DrawBrezinheimLine(g, Color.Black, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            }
        }
    }
}
