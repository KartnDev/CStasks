using STP_Task6.Collections.Generics;
using STP_Task6.Collections.Utils;
using STP_Task6.Random.Texting;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace STP_Task5_Winform
{
    public partial class Form1 : Form
    {
        LinkedList<string> list = new LinkedList<string>();
        public Form1()
        {
            InitializeComponent();
        }


        private void FillDataGridViewFromArray()
        {
            int iter = 0;
            foreach (var item in list)
            {
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[iter].Cells[0].Value = item;
                iter++;
            }

        }

        private void ClearAll()
        {
            list.Clear();
            dataGridView.Rows.Clear();
            InputDataGridView.Rows.Clear();

        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            FillDataGridViewFromArray();
        }

        private async void FillRandom_Click(object sender, EventArgs e)
        {
            ClearAll();
            for (int rowNum = 0; rowNum < 10; rowNum++)
            {
                InputDataGridView.Rows.Add(new DataGridViewRow());
                for (int i = 0; i < 1; i++)
                {
                    InputDataGridView.Rows[rowNum].Cells[i].Value = rowNum + RandomText.NextText("" + DateTime.Now.Ticks + DateTime.Now.Millisecond);
                    await Task.Delay(1);
                }

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void FillFileButton_Click(object sender, EventArgs e)
        {
            ClearAll();
            LinkedList<string> dataNum = new LinkedList<string>();
            using (StreamReader fs = new StreamReader("Data.txt"))
            {
                string data = fs.ReadToEnd();

                string[] Line = data.Split('\n');

                foreach (var item in Line)
                {
                    dataNum.Add(item);
                }
                for (int rowNum = 0; rowNum < dataNum.Count - 1; rowNum++)
                {
                    InputDataGridView.Rows.Add(new DataGridViewRow());

                    InputDataGridView.Rows[rowNum].Cells[0].Value = dataNum[rowNum];

                }
            }

        }

        private void FillFromDataGridButton_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in InputDataGridView.Rows)
            {
                if (row.Index == InputDataGridView.RowCount - 1)
                {
                    break;
                }

                if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    list.Add(row.Cells[0].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Неправильный формат заполения");
                    return;
                }
            }
        }
    }
}