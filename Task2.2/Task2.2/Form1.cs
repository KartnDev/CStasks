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
        private List<string> CorrentSymbols;
        

        public Form1()
        {
           
            CorrentSymbols = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                CorrentSymbols.Add(i.ToString());
            }
            for (int i = 65; i < 91; i++)
            {
                CorrentSymbols.Add(((char)i).ToString());
                CorrentSymbols.Add(((char)(i + 32)).ToString());
            }
            foreach(string item in CorrentSymbols)
            {
                Console.WriteLine(item);
            }
            InitializeComponent();

        }


        public string RandomCharAsString(Random random, ref List<string> DictOfAllowedChars)
        {
            int tempRand = random.Next(DictOfAllowedChars.Count);
            string toResult = DictOfAllowedChars.ElementAtOrDefault(tempRand);
            if(toResult != null)
            {
                DictOfAllowedChars.RemoveAt(tempRand);
                return toResult;
            }
            else
            {
               return DictOfAllowedChars.ElementAt(0);
            }

        }
    }
}
