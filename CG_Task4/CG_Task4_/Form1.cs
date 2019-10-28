using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Task4_
{


    public partial class Form1 : Form
    {
        private static Point[] firstArrayOfPoints;
        private static Point[] secondArrayOfPoints;

        private static Graphics Graphics { get; set; }

        public Form1()
        {
            InitializeComponent();
            Graphics = canvas.CreateGraphics();
        }

        private void DrawSpireLine(Graphics graphics, Pen pen, Point[] arrayOfPoints)
        {
            if (arrayOfPoints.Length >= 2)
            {
                for (int i = 0; i < arrayOfPoints.Length - 1; i++)
                {
                    graphics.DrawLine(pen, arrayOfPoints[i].X,
                                           arrayOfPoints[i].Y,
                                           arrayOfPoints[i + 1].X,
                                           arrayOfPoints[i + 1].Y);
                }
            }
            else
            {
                MessageBox.Show("Ломанная линия содержит минимум 2 точки!");
            }
        }
        private void ReDrawSpireLine(Graphics graphics, Pen pen,
            Point[] arrayOfPoints, Point[] newArrayOfPoints)
        {
            List<Point> CrossLinePoints = new List<Point>(arrayOfPoints);
            if (arrayOfPoints.Length >= 2)
            {
                for (int iteratorOfCross = 0; iteratorOfCross < newArrayOfPoints.Length; iteratorOfCross++)
                {
                    System.Threading.Thread.Sleep(2000);
                    ClearCanvas(graphics);
                    CrossLinePoints[iteratorOfCross] = newArrayOfPoints[iteratorOfCross];
                    for (int i = 0; i < arrayOfPoints.Length - 1; i++)
                    {
                        graphics.DrawLine(pen, CrossLinePoints[i].X,
                                               CrossLinePoints[i].Y,
                                               CrossLinePoints[i + 1].X,
                                               CrossLinePoints[i + 1].Y);
                        System.Threading.Thread.Sleep(100);
                    }

                    
                }
            }
            else
            {
                MessageBox.Show("Ломанная линия содержит минимум 2 точки!");
            }
        }

        private void ClearCanvas(Graphics g)
        {
            g.Clear(canvas.BackColor);
        }



        private void DrawLineButton_Click(object sender, EventArgs e)
        {

            {
                firstArrayOfPoints = new Point[FirstTable.RowCount - 1];
                secondArrayOfPoints = new Point[FirstTable.RowCount - 1];


                int iter = 0;
                foreach (DataGridViewRow row in FirstTable.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        firstArrayOfPoints[iter] = new Point(int.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[1].Value.ToString()));
                        iter++;
                    }
                }
                iter = 0;
                foreach (DataGridViewRow row in FirstTable.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        secondArrayOfPoints[iter] = new Point(int.Parse(row.Cells[2].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()));
                        iter++;
                    }
                }
                DrawSpireLine(Graphics, new Pen(new SolidBrush(Color.Red)), firstArrayOfPoints);
            }
        }

        private void ReDrawButton_Click(object sender, EventArgs e)
        {
            ReDrawSpireLine(Graphics, new Pen(new SolidBrush(Color.Red)),
                firstArrayOfPoints, secondArrayOfPoints);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearCanvas(Graphics);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosXLabel.Text = e.X.ToString();
            mousePosYLabel.Text = e.Y.ToString();
        }
    }
}
