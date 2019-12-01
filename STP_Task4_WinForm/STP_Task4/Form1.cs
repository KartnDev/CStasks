using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                MessageBox.Show("Enter the text..");
            }
            else
            {

                if (string.IsNullOrEmpty(SeparatorTextBox.Text))
                {
                    StringParser stringParser = new StringParser(InputTextBox.Text);
                    ResultBox.Text = stringParser.WordsReverseBySep(" ".ToCharArray());
                }
                else
                {
                    StringParser stringParser = new StringParser(InputTextBox.Text);
                    ResultBox.Text = stringParser.WordsReverseBySep(SeparatorTextBox.Text.ToCharArray());
                }
            }
        }

        private void FillRandomButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = RandomText.NextText();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            using (StreamReader fs = new StreamReader("Text.txt"))
            {
                InputTextBox.Text = fs.ReadToEnd();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultBox.Text = InputTextBox.Text = "";
        }
    }
}
