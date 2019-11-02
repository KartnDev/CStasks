using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task3_WinForm
{
    public partial class Form1 : Form
    {
        private CirclesHandler circlesHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Index == dataGridView1.RowCount - 1)
                {
                    break;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                    {
                        MessageBox.Show($"Ошибка чтения в колонке #{i} строке #{row.Index}");
                        return;
                    }
                }
            }
            LinkedList<Circle> dataCircles = new LinkedList<Circle>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == dataGridView1.RowCount - 1)
                {
                    break;
                }
                double dataRaduis, dataX, dataY;
                if(double.TryParse(row.Cells[0].Value.ToString(), out dataX) &&
                   double.TryParse(row.Cells[1].Value.ToString(), out dataY) &&
                   double.TryParse(row.Cells[2].Value.ToString(), out dataRaduis))
                {
                    dataCircles.AddFirst(new Circle((int)dataX, (int)dataY, dataRaduis));
                }
                else
                {
                    return;
                }
            }
            circlesHandler = new CirclesHandler(dataCircles, 1000, 1000);
            KeyValuePair<int, int> point = circlesHandler.FirstPointOrDefualt();
            MessageBox.Show($"Первая точка, пересеченная всеми окружностями (X: {point.Key}, Y: {point.Value})");
        }
    }
}
