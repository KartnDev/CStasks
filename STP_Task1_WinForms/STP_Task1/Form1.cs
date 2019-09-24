using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = $"MyCos({textBox2.Text}) = " +
                MyMath.MyCos(double.Parse(textBox2.Text, CultureInfo.InvariantCulture), 
                int.Parse(textBox6.Text));
            textBox5.Text = $"Envirement Cos({textBox2.Text}) = " + 
                Math.Cos(double.Parse(textBox2.Text,
                CultureInfo.InvariantCulture));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int iters = MyMath.computeIterationsForAccuracy(
                double.Parse(textBox1.Text, CultureInfo.InvariantCulture), 
                double.Parse(textBox7.Text, CultureInfo.InvariantCulture));

            textBox3.Text = $"{iters} iterations";
        }

    }
}
