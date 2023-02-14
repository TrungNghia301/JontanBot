using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JontanTeleBot.Program;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
namespace JontanTeleBot
{
    internal class Titlevideo
    {
        private static string titlevideo = " ";
        public static string TitleVideo
        {
            get { return titlevideo; }
            set { titlevideo = value; }
        }
        public static async Task GetTitle()
        {
            var youtube = new YoutubeClient();
            var t = await youtube.Videos.GetAsync(Yturl);
            titlevideo = t.Title;
        }
    }
}
