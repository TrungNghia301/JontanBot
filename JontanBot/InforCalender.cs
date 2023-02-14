using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static JonTanTeleBot.Updatecalendar;
using static JontanTeleBot.Program;
namespace JonTanTeleBot
{
    internal class InforCalender
    {
        private static int Year;
        private static int Month;
        private static int Day;
        private static int Hour;
        private static int Minute;
        private static int Second;

        private static string sm = " ";
        public static string Sm
        {
            get { return sm; }
            set { sm = value; }

        }
        private static string dc = " ";
        public static string Dc
        {
            get { return dc; }
            set { dc = value; }

        }
        public static int year
        {
            get { return Year; }
            set { Year = value; }

        }
        public static int month
        {
            get { return Month; }
            set { Month = value; }
        }
        public static int day
        {
            get { return Day; }
                set { Day = value; }

        }

        public static int hour
        {
            get { return Hour; }
            set { Hour = value; }
        }
        public static int minute
        {
            get { return Minute; }
            set
            {
                Minute = value;
            }
        }
        public static int second
        {
             get { return Second; }
            set
            {
                Second = value;
            }
        }
        /*public static void Main2()
        {
            Console.WriteLine("Nhap ten su kien:");
            Sm = Console.ReadLine();
            Console.WriteLine("Nhap trinh bai su kien:");
            Dc = Console.ReadLine();
        }*/
    }
}

