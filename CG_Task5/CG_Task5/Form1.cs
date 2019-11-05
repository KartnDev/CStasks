using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task5
{
    public partial class Form1 : Form
    {
        private Graphics Graphics3D { get; set; }
        private Brush MyBrush { get; set; }
        private Pen MyPen { get; set; }


        //private int height_z = 200;
        //private int width_y = 200;
        //private int len_x = 200;
        //private int x0 = 120;
        //private int y0 = 120;
        public Form1()
        {
            InitializeComponent();
            Graphics3D = GraphicsBox.CreateGraphics();
            MyBrush = new SolidBrush(Color.Red);
            MyPen = new Pen(MyBrush);
        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            //Render2DRotationZ(250, 250, 70);
            drawCube(250, 250, 70, 50, "OX");
        }



        private void Render2DRotationZ(int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 10)
            {
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha)),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                               (int)(y + radius * Math.Sin(i + alpha + Math.PI / 2)));
                }

                ClearAndSleep(Graphics3D);
            }
        }


        private void drawCube(int x0, int y0, int radius, int height_z, string rotationDim = "OY")
        {

            if (rotationDim == "OZ")
            {
                for (double i = 0; true; i += Math.PI / 10)
                {

                    for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                    {

                        Graphics3D.DrawLine(new Pen(MyBrush, 2), x0, y0, x0 + height_z, y0 + height_z);

                        // drawing normal plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha + Math.PI / 2)));
                        // drawing back plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + height_z + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha + Math.PI / 2)));
                        // drawing middle plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha)));

                    }
                    ClearAndSleep(Graphics3D);
                }

            }
            else if (rotationDim == "OX")
            {
                for (double i = 0; true; i += Math.PI / 10)
                {

                    for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                    {

                        Graphics3D.DrawLine(new Pen(MyBrush, 2), x0, y0, x0 + height_z, y0 + height_z);

                        // drawing normal plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha + Math.PI / 2)));
                        // drawing back plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + height_z + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha + Math.PI / 2)));
                        // drawing middle plane 
                        Graphics3D.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + radius * Math.Sin(i + alpha)),
                                                   (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                                   (int)(y0 + height_z + radius * Math.Sin(i + alpha)));

                    }
                    ClearAndSleep(Graphics3D);
                }
            }
            else if (rotationDim == "OY")
            {

            }
        }


        private void ClearCanvas(Graphics g)
        {
            g.Clear(GraphicsBox.BackColor);
        }

        private void ClearAndSleep(Graphics g)
        {
            System.Threading.Thread.Sleep(150);
            g.Clear(GraphicsBox.BackColor);
        }
    }
}
