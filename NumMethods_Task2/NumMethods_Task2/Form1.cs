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


        private void button1_Click(object sender, EventArgs e)
        {
            var lower = double.Parse(lowerBorderBox.Text);
            var upper = double.Parse(upperBorderBox.Text);

            resultBox.Text = integralMethods.RectangularIntegral(lower, upper, 100000).ToString();
        }
    }
}
