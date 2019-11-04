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

        public string WordsReverseBySep(char separator)
        {
            StringBuilder result = new StringBuilder(strValue.Length);

            var words = strValue.Split(separator).ToList().Reverse<string>();

            for (int i =0; i < words.Count(); i++)
            {
                if(i != 0)
                {
                    result.Append(" ");
                }
                result.Append(words.ElementAt(i));
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
