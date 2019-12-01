using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task4
{
    public class RandomText
    {
        public static readonly string Lang =
            "qwer tyui opas dfgh jklz xcv bnm" +
            "qwer tyui opas dfgh jklz xcv bnm" +
            "qwer tyui opas dfgh jklz xcv bnm" +
            "qwer tyui opas dfgh jklz xcv bnm" +
            "qwer tyui opas dfgh jklz xcv bnm" +
            "qwer tyui opas dfgh jklz xcv bnm";

        static RandomText() {}

        public static string NextText()
        {
            string result = "";
            for(int i =0; i < (new Random().Next(0, Lang.Length)); i++)
            {
                result += Lang.ElementAt(new Random(i + int.Parse(DateTime.Now.Millisecond.ToString())).Next(0, Lang.Length));
            }
            return result;
        }
    }
}
