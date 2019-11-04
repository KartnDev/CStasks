using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TransformButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                MessageBox.Show("enter the text..");
            }
            else
            {
                StringParser stringParser = new StringParser(InputTextBox.Text);
                ResultBox.Text = stringParser.WordsReverseBySep(' ');
            }
        }
    }
}
