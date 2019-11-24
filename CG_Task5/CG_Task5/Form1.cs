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
            //drawCube(250, 250, 70, 50, "OX");
            //RenderTetrahedron(Graphics3D, MyPen, 100, 100, 200, 300, Math.PI / 4);
            //RenderOctahedron(Graphics3D, MyPen, 300, 300, 70);
            DrawDodecahedron(Graphics3D, MyPen, 400, 400, 50);
        }


        private void RenderTetrahedron(Graphics g, Pen pen, int x, int y, int width, int height, double alpha)
        {
            g.DrawLine(MyPen, x, y, x + width, y);
            g.DrawLine(MyPen, x, y, (float)((x + width) / 1.5), (float)(width * Math.Cos(alpha)));
            g.DrawLine(MyPen, x + width, y, (float)((x + width) / 1.5), (float)(width * Math.Sin(alpha)));

            g.DrawLine(MyPen, x + width, y, (float)((x + width) / 1.5), y+height);
            g.DrawLine(MyPen, x, y, (float)((x + width) / 1.5), y + height);
            g.DrawLine(MyPen, (float)((x + width) / 1.5), (float)(width * Math.Sin(alpha)), (float)((x + width) / 1.5), y + height);
        }

        private void RenderOctahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            
            


            for (double i = 0; true; i += Math.PI / 10)
            {
                //draw AXIS
                Graphics3D.DrawLine(new Pen(MyBrush, 2), x, (y - radius), x, y + radius);
                Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);

                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {
                    
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 2) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + Math.PI / 2)));

                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)x, 
                                               (int)(y - radius));
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)x,
                                               (int)(y + radius));
                }

                ClearAndSleep(Graphics3D);
            }

        }


        private void DrawDodecahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {

                //draw AXIS
                Graphics3D.DrawLine(new Pen(MyBrush, 2), x, (y - 150), x, y);


                //Render Last small traingle
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2*Math.PI / 3)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + 2*Math.PI / 3) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                }


                //Render pre-last big traingle + No-offset
                for (double alpha = Math.PI / 3; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + 2 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 50 + 2 * radius * Math.Sin(i + alpha)),
                                               (int)(x + 2 * radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y - 50 + 2 * radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                }
                /*

                // Glue last and pre-last triangles
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + 2 * radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y - 50 + 2 * radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                }*/

                //Render pre-First big traingle + No-offset
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 3)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + 2*radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 2*radius * Math.Sin(i + alpha)),
                                               (int)(x + 2*radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y - 100 + 2*radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                }
                //Render First small traingle + offset
                for (double alpha = Math.PI / 3; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + +2 * Math.PI / 3) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha + +2 * Math.PI / 3)));
                }





                ClearAndSleep(Graphics3D);
            }
        }


        private void Render2DRotationZ(int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 10)
            {
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {
                    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                    Graphics3D.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 2) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + Math.PI / 2)));
                }

                ClearAndSleep(Graphics3D);
            }
        }


        private void drawCube(int x0, int y0, int radius, int height_z, string rotationAxis = "OY")
        {

            if (rotationAxis == "OZ")
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
            else if (rotationAxis == "OX")
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
            else if (rotationAxis == "OY")
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
