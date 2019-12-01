using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task4
{
    public class StringParser
    {
        private readonly string strValue;
        public StringParser(string str)
        {
            this.strValue = str;
        }

        public string WordsReverseBySep(char[] separator)
        {
            StringBuilder result = new StringBuilder(strValue.Length);

            var wt = (from w in strValue.Split(separator).Reverse() select w).ToList();

            result.Append(wt[0]);


            for (int i = 1; i < wt.Count(); i++)
            {

                result.Append(" ");

                result.Append(wt[i]);
            }
            return result.ToString();
        }


        public string WordsReverseBySepNoSpace(char separator)
        {
            StringBuilder result = new StringBuilder(strValue.Length);

            foreach (var word in strValue.Split(separator).ToList().Reverse<string>())
            {
                result.Append(word);
            }
            return result.ToString();
        }

    }
}
