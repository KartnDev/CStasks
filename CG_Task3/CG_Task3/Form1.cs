using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CG_Task3
{
    public partial class Form1 : Form
    {
        private int[] RowArray;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Column Diagram");
            comboBox1.Items.Add("Circle Diagram");
        }

        private Color RandColor(int delim)
        {
            int r = (new Random(delim)).Next(0, 255);
            int g = (new Random(171*delim)).Next(0, 255);
            int b = (new Random(314*delim)).Next(0, 255);
            return Color.FromArgb(r, g, b);
        }

        private void ClearCanvas(Graphics g)
        {
            g.Clear(pictureBox1.BackColor);
        }


        private void ResultButton_Click(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();

            ClearCanvas(graphics);
            if (comboBox1.SelectedItem == "Column Diagram")
            { 
                DrawColumnDiagram(graphics, RowArray, 30, 200, 60, 100);
            }
            else if(comboBox1.SelectedItem == "Circle Diagram")
            {
                DrawCircleDiagram(graphics, RowArray, 100, 15);
            }
        }

        private void DrawColumnDiagram(Graphics g, int[] array, int startPosXArg, int startPosYArg, int ColWidth, int ColHeight)
        {
            int CorrentX = startPosXArg;
            int CorrentY = startPosYArg;

            for(int i = 0; i < array.Length; i++)
            {

                g.FillRectangle
                    (new SolidBrush(RandColor(i)),
                    CorrentX,
                    CorrentY - ColHeight * (float)((double)array[i]/array.Sum()),
                    ColWidth,
                    CorrentY + ColHeight * (float)((double)array[i] / array.Sum())
                    );

                CorrentX += ColWidth;
            }
        }

        private void DrawCircleDiagram(Graphics g, int[] array, int x0, int y0)
        {
            int ArreySum = array.Sum();

            float correntPieDegree = 0;

            for (int i = 0; i < array.Length; i++)
            {
                g.FillPie(new SolidBrush(RandColor(i)), new Rectangle(x0, y0, 400, 400), correntPieDegree, (float)((double)array[i] / ArreySum) * 360);
                correntPieDegree += (float)((double)array[i] / ArreySum) * 360;
            }
        }


        private void GetArrayButton_Click(object sender, EventArgs e)
        {
            RowArray = new int[dataGridView1.RowCount - 1];

            int iter = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    RowArray[iter] = int.Parse((string)row.Cells[0].Value);
                    iter++;
                }
            }

        }
    }
}
