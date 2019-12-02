using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task5_Winform
{
    public static class RandomText
    {
        public static readonly string Lang =
            "16bnm,2347890-=qwertyuхъфывапiop[]asdfghjkl;'zxcv5./йцукенгшщзролджэячсмитьбю.";


        public static string NextText(this string str)
        {
            str = "";
            for (int i = 0; i < (new Random().Next(0, Lang.Length)); i++)
            {
                str += Lang.ElementAt(new Random(i + int.Parse(DateTime.Now.Millisecond.ToString())).Next(0, Lang.Length));
            }
            return str;
        }
        public static string NextText(int seed)
        {
            string result = "";
            for (int i = 0; i < (new Random().Next(0, Lang.Length)); i++)
            {
                result += Lang.ElementAt(new Random(i + seed).Next(0, Lang.Length));
            }
            return result;
        }
    }
}
