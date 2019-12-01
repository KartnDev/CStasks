using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STP_Task3_WinForm_
{

    public partial class Form1 : Form
    {
        List<Circle> circles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();
        }


        private void ComputeButton_Click(object sender, EventArgs e)
        {
            circles.Clear();

            int iter = 1;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Index == dataGridView.RowCount - 1)
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

            CircleHandler circleHandler = new CircleHandler(circles, 1000, 1000);

            KeyValuePair<int, int> coord = circleHandler.FirstPointOrDefualt();

            ResultOutputLable.Text = coord.Key == -1 && coord.Value == -1 ? "Таких нет" : $"Point (X: {coord.Key}, Y: {coord.Value})";

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultOutputLable.Text = "...";
            circles.Clear();
            clear();
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            clear();
            for (int rowNum = 0; rowNum < 10; rowNum++)
            {
                dataGridView.Rows.Add(new DataGridViewRow());
                for (int i = 0; i < 3; i++)     
                {
                    dataGridView.Rows[rowNum].Cells[i].Value = (new Random(rowNum + i+ (int)DateTime.Now.Millisecond)).Next(0, 1000);
                }

            }
        }

        private void clear()
        {
            do
            {
                foreach (DataGridViewRow rowMember in dataGridView.Rows)
                {
                    try
                    {
                        dataGridView.Rows.Remove(rowMember);
                    }
                    catch (Exception) { }
                }
            } while (dataGridView.Rows.Count > 1);

        }


        private void FillFromFileButton_Click(object sender, EventArgs e)
        {
            clear();
            List<List<String>> dataNum = new List<List<string>>();
            using (StreamReader fs = new StreamReader("Data.txt"))
            {
                string data = fs.ReadToEnd();

                string[] Line = data.Split('\n');

                foreach (var item in Line)
                {
                    dataNum.Add(new List<string>(item.Split(',')));
                }
                for (int rowNum = 0; rowNum < dataNum.Count; rowNum++)
                {
                    dataGridView.Rows.Add(new DataGridViewRow());
                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView.Rows[rowNum].Cells[i].Value = dataNum[rowNum][i];
                    }
                }
            }

        }
    }
}
