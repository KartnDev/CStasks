using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task2
{
    public partial class Form1 : Form
    {
        private static double[] RowArray;



        public Form1()
        {
            InitializeComponent();
        }

        private void CheckArrayButton_Click(object sender, EventArgs e)
        {

            RowArray = new double[ArrayDataGrid.RowCount - 1];

            int iter = 0;
            foreach (DataGridViewRow row in ArrayDataGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {

                    if (!double.TryParse((string)row.Cells[0].Value, out RowArray[iter]))
                    {
                        MessageBox.Show($"БЫЛ ДАН НЕПРАВИЛЬНЫЙ ФОРМАТ СТРОКИ! Ошибка в ячейке = {row.Cells[0].Value} под номером {iter + 1}");
                        return;
                    }

                }
                iter++;
            }


            ArrayHandler arrayHandler = new ArrayHandler(RowArray);
            ResultLabel.Text = "" + arrayHandler.CheckSequence();

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            do
            {
                foreach (DataGridViewRow rowMember in ArrayDataGrid.Rows)
                {
                    try
                    {
                        ArrayDataGrid.Rows.Remove(rowMember);
                    }
                    catch (Exception) { }
                }
            } while (ArrayDataGrid.Rows.Count > 1);
        }
    }
}
