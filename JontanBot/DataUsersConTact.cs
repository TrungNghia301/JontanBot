using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JontanTeleBot
{
    internal class DataUsersConTact
    {
            private static dynamic array;
            private static DateTime localDate;
            public static void SaveDataUsers()
            {
                using (StreamReader r = new StreamReader("PATH_File you saved in Class Program in line"))
                {
                    string json = r.ReadToEnd();
                    array = JObject.Parse(json);
                    Console.WriteLine(array.text);
                    Console.WriteLine(array.from.id);
                    Console.WriteLine(array.from.first_name + array.from.last_name);
                    double a = array.date;
                    DateTime x = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(a);
                    localDate = x.ToLocalTime();
                    Console.WriteLine(localDate);
                }
                using (StreamWriter writetext = new StreamWriter("PATH_File text for save users data", true))
                {
                    writetext.WriteLine("Nội dung: " + array.text + "||" + "UsersName: " + array.from.first_name + " " + array.from.last_name + "||" + "Thời gian: " + " " + localDate);
                }
            }
        }
    }

