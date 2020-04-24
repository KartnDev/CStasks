using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NumMethods_Task2
{
    public partial class Form1 : Form
    {

        private IntegralMethods integralMethods;
        public Form1()
        {
            InitializeComponent();

            integralMethods = new IntegralMethods((x) => 5 * Math.Pow(x, 3));
        }


        private async void ComputeClick(object sender, EventArgs e)
        {
            var lower = double.Parse(lowerBorderBox.Text);
            var upper = double.Parse(upperBorderBox.Text);
            if(comboBox1.SelectedItem.Equals("Rectangular"))
            {
                resultBox.Text = integralMethods.RectangularIntegral(lower, upper, trackBar1.Value * 1000).ToString();
            }
            else if(comboBox1.SelectedItem.Equals("Trapezoid"))
            {
                resultBox.Text = integralMethods.TrapezoidIntegral(lower, upper, trackBar1.Value * 1000).ToString();
            }
            else if(comboBox1.SelectedItem.Equals("Simpson"))
            {
                resultBox.Text = integralMethods.SimpsonIntegral(lower, upper, trackBar1.Value * 1000).ToString();
            }
            else
            {
                MessageBox.Show("Select something");
            }
            
        }

        private async void OnScrolling(object sender, EventArgs e)
        {
            ComputeClick(sender, e);
        }
    }
}
