using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task5
{
    public partial class Form1 : Form
    {
        private Graphics Graphics3D { get; set; }
        private Brush MyBrush { get; set; }
        private Pen MyPen { get; set; }

        private Pen AxisPen { get; set; } = new Pen(new SolidBrush(Color.Red), 2);

        private bool DisruptTask { get; set; } = false;


        public Form1()
        {
            InitializeComponent();
            Graphics3D = GraphicsBox.CreateGraphics();
            MyBrush = new SolidBrush(Color.Black);
            MyPen = new Pen(MyBrush);
        }

        private void RenderButton_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == "Cube")
            {
                RenderCube(Graphics3D, 300, 300, 100, 100);
            }
            else if (comboBox.SelectedItem == "Tetrahedron")
            {
                RenderTetrahedron(Graphics3D, MyPen, 300, 300, 70);
            }
            else if (comboBox.SelectedItem == "Octahedron")
            {
                RenderOctahedron(Graphics3D, MyPen, 300, 300, 70);
            }
            else if (comboBox.SelectedItem == "Icosahedron")
            {
                DrawIcosahedron(Graphics3D, MyPen, 400, 400, 65);
            }
            else if (comboBox.SelectedItem == "Dodecahedron")
            {
                RenderDodecahedron(Graphics3D, MyPen, 400, 400, 45);
            }
            else
            {
                MessageBox.Show("Invalid token..");
            }
        }


        private async void RenderDodecahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {

                //draw AXIS
                g.DrawLine(AxisPen, x, (y - 150), x, y);


                //Render Last small octagon
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + 2 * Math.PI / 5) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + 2 * Math.PI / 5)));
                }

                // Glue 4 - 3 
                for (double alpha = Math.PI / 5; alpha < 2 * Math.PI + Math.PI / 5; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha)));
                }

                // Glue 2 - 3 
                for (double alpha = Math.PI / 5; alpha < 2 * Math.PI + Math.PI / 5; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + Math.PI / 5) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + Math.PI / 5)));
                }
                // Glue 2 - 3 
                for (double alpha = Math.PI / 5; alpha < 2 * Math.PI + Math.PI / 5; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha - Math.PI / 5) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha - Math.PI / 5)));
                }

                // Glue 1 - 2 
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)));
                }


                ////Render pre-last big octagon
                //for (double alpha = Math.PI / 5; alpha < 2 * Math.PI + Math.PI / 5; alpha += 2 * Math.PI / 5)
                //{
                //    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                //    Graphics3D.DrawLine(MyPen, (int)(x + 1.5*radius * Math.Cos(i + alpha) * 2),
                //                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                //                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + 2 * Math.PI / 5) * 2),
                //                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha + 2 * Math.PI / 5)));
                //}

                //Render pre-first big octagon
                //for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 5)
                //{
                //    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                //    Graphics3D.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                //                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha)),
                //                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + 2 * Math.PI / 5) * 2),
                //                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + 2 * Math.PI / 5)));
                //}

                //Render first small octagon
                for (double alpha = Math.PI / 5; alpha < 2 * Math.PI + Math.PI / 5; alpha += 2 * Math.PI / 5)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + 2 * Math.PI / 5) * 2),
                                               (int)(y -150 + radius * Math.Sin(i + alpha + 2 * Math.PI / 5)));
                }

                await Task.Delay(300);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }
            }
        }

        private async void RenderTetrahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {

                //draw AXIS
                g.DrawLine(AxisPen, x, (y - 150), x, y);


                //Render Last small traingle
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                      (int)(y + radius * Math.Sin(i + alpha)),
                                      (int)(x + radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                      (int)(y + radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));

                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                      (int)(y + radius * Math.Sin(i + alpha)),
                                      (int)x, 
                                      (int)(y - 150));
                }


                await Task.Delay(100);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }

            }
        }

        private async void RenderOctahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {
                //draw AXIS
                g.DrawLine(AxisPen, x, (y - radius), x, y + radius);

                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {

                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 2) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + Math.PI / 2)));

                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)x,
                                               (int)(y - radius));
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)x,
                                               (int)(y + radius));
                }
                await Task.Delay(100);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }
            }

        }


        private async void DrawIcosahedron(Graphics g, Pen pen, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 15)
            {

                //draw AXIS
                g.DrawLine(AxisPen, x, (y - 150), x, y);


                //Render Last small traingle
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                }


                ////Render pre-last big traingle + No-offset
                //for (double alpha = Math.PI / 3; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                //{
                //    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                //    Graphics3D.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                //                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha)),
                //                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                //                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                //}


                // Glue last and pre-last triangles 3-4
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + Math.PI / 3) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + Math.PI / 3)));
                }
                // Glue last and pre-last triangles 3-4
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + 2 * Math.PI / 3)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + Math.PI / 3) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + Math.PI / 3)));
                }

                ////Render pre-First big traingle + No-offset
                //for (double alpha = 0; alpha < 2 * Math.PI; alpha += 2 * Math.PI / 3)
                //{
                //    Graphics3D.DrawRectangle(MyPen, x, y, 2, 2);
                //    Graphics3D.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                //                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                //                               (int)(x + 1.5 * radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                //                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha + 2 * Math.PI / 3)));
                //}



                // Glue pre-last and pre-first triangles 2-4
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)));
                }

                for (double alpha = Math.PI / 3; alpha < 2 * Math.PI + Math.PI / 3 + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha)));
                }


                // Glue pre-last and pre-first triangles 1-2
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 3) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha + Math.PI / 3)));
                }
                // Glue pre-last and pre-first triangles 1-2
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha + 2 * Math.PI / 3) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha + 2 * Math.PI / 3)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 3) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha + Math.PI / 3)));
                }

                // Glue pre-last and pre-first triangles 2-3
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha + Math.PI / 3) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha + Math.PI / 3)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)));
                }

                // Glue pre-last and pre-first triangles 2-3
                for (double alpha = 0; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + 1.5 * radius * Math.Cos(i + alpha - Math.PI / 3) * 2),
                                               (int)(y - 50 + 1.5 * radius * Math.Sin(i + alpha - Math.PI / 3)),
                                               (int)(x + 1.5 * radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 100 + 1.5 * radius * Math.Sin(i + alpha)));
                }



                //Render First small traingle + offset
                for (double alpha = Math.PI / 3; alpha < 2 * Math.PI + Math.PI / 3; alpha += 2 * Math.PI / 3)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + +2 * Math.PI / 3) * 2),
                                               (int)(y - 150 + radius * Math.Sin(i + alpha + +2 * Math.PI / 3)));
                }
                await Task.Delay(300);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }

            }
        }


        private async void Render2DRotationZ(Graphics g, int x, int y, int radius)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {
                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {
                    g.DrawLine(MyPen, (int)(x + radius * Math.Cos(i + alpha) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha)),
                                               (int)(x + radius * Math.Cos(i + alpha + Math.PI / 2) * 2),
                                               (int)(y + radius * Math.Sin(i + alpha + Math.PI / 2)));
                }
                await Task.Delay(100);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }
            }
        }


        private async void RenderCube(Graphics g, int x0, int y0, int radius, int height_z)
        {
            for (double i = 0; true; i += Math.PI / 30)
            {

                for (double alpha = 0; alpha < 2 * Math.PI; alpha += Math.PI / 2)
                {
                    
                    g.DrawLine(AxisPen, x0, y0, x0 + height_z, y0 + height_z);

                    // drawing normal plane 
                    g.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                      (int)(y0 + radius * Math.Sin(i + alpha)),
                                      (int)(x0 + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                      (int)(y0 + radius * Math.Sin(i + alpha + Math.PI / 2)));
                    // drawing back plane 
                    g.DrawLine(MyPen, (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                      (int)(y0 + height_z + radius * Math.Sin(i + alpha)),
                                      (int)(x0 + height_z + radius * Math.Cos(i + alpha + Math.PI / 2)),
                                      (int)(y0 + height_z + radius * Math.Sin(i + alpha + Math.PI / 2)));
                    // drawing middle plane 
                    g.DrawLine(MyPen, (int)(x0 + radius * Math.Cos(i + alpha)),
                                      (int)(y0 + radius * Math.Sin(i + alpha)),
                                      (int)(x0 + height_z + radius * Math.Cos(i + alpha)),
                                      (int)(y0 + height_z + radius * Math.Sin(i + alpha)));

                }
                await Task.Delay(100);
                g.Clear(GraphicsBox.BackColor);
                if (DisruptTask)
                {
                    DisruptTask = false;
                    return;
                }
            }

            

        }


        private void ClearCanvas(Graphics g)
        {
            g.Clear(GraphicsBox.BackColor);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisruptTask = true;
            Graphics3D.Clear(GraphicsBox.BackColor);
        }
    }
}
