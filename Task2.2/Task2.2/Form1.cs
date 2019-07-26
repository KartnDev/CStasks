using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Task2._2
{
   


    public partial class Form1 : Form
    {
        private enum UTFBinds
        {
            ONE = 31, TWO = 32, THREE = 33, FOUR = 34, FIVE = 35, 
            SIX = 36, SEVEN = 37, EIGHT = 38, NINE = 39, A = 41, B = 42, 
            C = 43, D = 44, E = 45, F = 46, G = 47, H = 48, I = 49, J =50,
            K = 51, L = 52, M = 53, N = 54, O = 55, P = 56,  Q = 57, R = 58, 
            S = 59, 

        }

        

        public Form1()
        {
            InitializeComponent();
        }


        public string RandomString(Random random, int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(30 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
