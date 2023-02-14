using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JonTanTeleBot
{
    internal class GetListEvents
    {

        private static string ev = " ";
        public static string Ev
        {
            get { return ev; }
            set { ev = value; }

        }
        public static void ShowlistEvents()
        {
            using (StreamReader r = new StreamReader("PATH_File json you created and wrote in method Save in SaveEventJsonClass"))
            {
                List<string> list = new List<string>();
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    /*Console.WriteLine("{0} {1} {2} {3} ", item.start.date,item.end.dateTime,  item.summary, item.description);*/
                    list.AddRange(new string[] { item.start.date, item.summary, item.description, item.end.dateTime });
            
                }
                ev = string.Join("\n", list);
                /*Console.WriteLine(ev);*/
            }
        }
    }
}
