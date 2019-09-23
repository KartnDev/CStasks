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

        private long factorial(int value)
        {
            if (value == 0)
            {
                return 1;
            }
            if (value != 1)
            {
                return value * factorial(value - 1);
            }
            else
            {
                return 1;
            }
        }


        private double MyCos(double value, int n)
        {
            double summ = 1;

            int minus = 1;

            double rowMember = 0;


            for (int i = 1; i < n; i++)
            {
                rowMember = Math.Pow(value, 2 * i) / factorial(2 * i);
                minus *= -1;
                summ += minus * rowMember;
            }

            return summ;
        }

        private int computeIterationsForAccuracy(double epsilon, double value)
        {
            double summ = 1;

            int minus = 1;

            double rowMember = 0;

            int iterator = 0;

            double delta = 100000;

            for (int i = 1; delta > epsilon; i++)
            {
                rowMember = Math.Pow(value, 2 * i) / factorial(2 * i);
                minus *= -1;
                summ += minus * rowMember;

                delta = Math.Abs(Math.Cos(value) - summ);
                iterator++;
            }



            return iterator;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = $"MyCos({textBox2.Text}) = " + 
                MyCos(double.Parse(textBox2.Text, CultureInfo.InvariantCulture), 
                int.Parse(textBox6.Text));
            textBox5.Text = $"Envirement Cos({textBox2.Text}) = " + 
                Math.Cos(double.Parse(textBox2.Text,
                CultureInfo.InvariantCulture));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int iters = computeIterationsForAccuracy(
                double.Parse(textBox1.Text, CultureInfo.InvariantCulture), 
                double.Parse(textBox7.Text, CultureInfo.InvariantCulture));

            textBox3.Text = $"{iters} iterations";
        }

    }
}
