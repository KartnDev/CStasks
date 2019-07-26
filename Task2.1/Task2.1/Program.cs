using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1
{
    class Program
    { 
        private static string GetHTMLNamesAndRefs(IDictionary<string, string> map)
        {
            StringBuilder result =
            new StringBuilder("<!DOCTYPE html>\n" +
                                "<html>\n" +
                                "<head>\n" +
                                    "<title>Main</title>\n" +
                                    "<meta charset=\"utf-8\">\n" +
                                "</head>\n" +
                                "<body>\n");
            //Append names
            short i = 0;
            foreach(string name in map.Keys)
            {
                
                string ValueByName = null;
                map.TryGetValue(name, out ValueByName);
                string temp = "<p>" + i + ") <a href=\"mailto:"+ValueByName+"\">" + name + "</a></p>";
                temp += "\n";
                i++;
                result.Append(temp);
            }
            result.Append("</body>\n" + "</html>\n");
            return result.ToString();
        }


        private static void CommitToHTMLformat(string filePath, string htmlStr)
        {
            try
            {
                using (System.IO.StreamWriter fileWrite = new System.IO.StreamWriter(filePath))
                {
                    fileWrite.WriteLine(htmlStr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while program was writing html file..\n" +
                    "Error message: " + e.Message);
                Console.WriteLine("\n\n\n Printed StackTrace: " + e.StackTrace);
            }
        }


        static void Main(string[] args)
        {

            Dictionary<string, string> dictNames = new Dictionary<string, string>();
            dictNames.Add("Дмитрий", "mailto:dmitry@hotmail.com");
            dictNames.Add("Олег", "mailto:Oleg@hotmail.com");
            dictNames.Add("Иван", "mailto:Ivan@hotmail.com");
            CommitToHTMLformat("index.html", GetHTMLNamesAndRefs(dictNames));
            
        }
    }
}
