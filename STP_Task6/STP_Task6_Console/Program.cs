using STP_Task6.Collections.Generics;
using STP_Task6.Collections.Utils;
using STP_Task6.Random.Texting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_Task6_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("1232");
            for(int i =0; i < 20; i++)
            {
                list.Add("ITEM" + i);

            }
            //ListUtils<string>.ForEach(list, (string item) => Console.WriteLine(item));

            ArrayList<string> arraylist = new ArrayList<string>(1);
            arraylist.Add("1232");
            for (int i = 0; i < 20; i++)
            {
                list.Add("ITEM" + i);

            }
            ListUtils<string>.ForEach(arraylist, (string item) => Console.WriteLine(item));




            Console.ReadLine();
        }
    }
}
