using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task3_WinForm_
{

    public partial class Form1 : Form
    {
        List<Circle> circles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void FeedButton_Click(object sender, EventArgs e)
        {
            int iter = 1;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == dataGridView1.RowCount - 1)
                {
                    break;
                }
                double dataRaduis, dataX, dataY;

                if (double.TryParse(row.Cells[0].Value.ToString(), out dataX) &&
                   double.TryParse(row.Cells[1].Value.ToString(), out dataY) &&
                   double.TryParse(row.Cells[2].Value.ToString(), out dataRaduis))
                {
                    circles.Add(new Circle(dataX, dataY, dataRaduis));
                }
                else
                {
                    MessageBox.Show("Неправильный формат на строке: " + iter);
                    return;
                }
                iter++;
            }
            
        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            CircleHandler circleHandler = new CircleHandler(circles, 1000, 1000);

            KeyValuePair<int, int> coord = circleHandler.FirstPointOrDefualt();

            ResultOutputLable.Text = coord.Key == -1 && coord.Value == -1 ? "Таких нет" : $"Point (X: {coord.Key}, Y: {coord.Value})";

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultOutputLable.Text = "...";
            circles.Clear();
        }
    }
}
