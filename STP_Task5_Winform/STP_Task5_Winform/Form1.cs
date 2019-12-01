using STP_Task5_Winform.MyCollections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task5_Winform
{
    public partial class Form1 : Form
    {
        HashTable<string, string> hash = new HashTable<string, string>(20);
        public Form1()
        {
            InitializeComponent();
        }

        private void AppendKeyValueButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputKeyBox.Text) && string.IsNullOrEmpty(InputKeyBox.Text))
            {
                MessageBox.Show("Все текстбоксы должы быть заполнены!");
                return;
            }
            else
            {
                hash.Add(InputKeyBox.Text, InputValueBox.Text);
            }
        }


        private void FillDataGridViewFromHash()
        {
            ClearAll();
            int iter = 0;
            foreach (var item in hash)
            {
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[iter].Cells[0].Value = item.Key;
                dataGridView.Rows[iter].Cells[1].Value = item.Value;
                iter++;   
            }

        }

        private void ClearAll()
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

            do
            {
                foreach (DataGridViewRow rowMember in InputDataGridView.Rows)
                {
                    try
                    {
                        InputDataGridView.Rows.Remove(rowMember);
                    }
                    catch (Exception) { }
                }
            } while (InputDataGridView.Rows.Count > 1);

        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            FillDataGridViewFromHash();
        }

        private void FillRandom_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
