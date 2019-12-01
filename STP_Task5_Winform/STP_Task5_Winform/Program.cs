using STP_Task5_Winform.MyCollections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_Task5_Winform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //HashTable<string, string> hash = new HashTable<string, string>(20);

            //hash.Add("1", "item 1");
            //hash.Add("2", "item 2");
            //hash.Add("dsfdsdsd", "sadsadsadsad");

            //string one = hash.Find("1");
            //string two = hash.Find("2");
            //string dsfdsdsd = hash.Find("dsfdsdsd");
            //hash.Remove("1");
            //Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
