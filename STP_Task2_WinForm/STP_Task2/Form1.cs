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
        private static int[] RowArray;



        public Form1()
        {
            InitializeComponent();
        }

        private void CheckArrayButton_Click(object sender, EventArgs e)
        {
            ArrayHandler arrayHandler = new ArrayHandler(RowArray);
            textBox2.Text = "" + arrayHandler.CheckSequence();
            //textBox2.Text = "" + (arrayHandler.CheckSequence() ? 1 : 0);
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

            // мы имеет n+1 column 
            // и в н+1 лежит разерервированный null
        }
    }
}
