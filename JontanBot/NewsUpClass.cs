using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Xml;
using HtmlAgilityPack;

namespace JonTanTeleBot { 
    internal class NewsUpClass
    {
        private static string ramdomnews = " ";
        public static string RmdomNews
        {
            get { return ramdomnews; }
            set { ramdomnews = value; }
        }
        private static string allnews = " ";
        public static string AllNews
        {
            get { return allnews; }
            set { allnews = value; }
        }
        public static void Upnews()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://vnexpress.net/");//get infor from vnexpress.net
            List<string> list = new List<string>();//list single node news
            List<string> list2 = new List<string>();// list name and url all news
            var headerNames = doc.DocumentNode.SelectNodes("//h3/a").ToList();
            foreach (var item in headerNames)
            {
                HtmlAttribute att = item.Attributes["href"];
                list.AddRange(new string[] { att.Value });
                list2.AddRange(new string[] { item.InnerText, att.Value });
            }
            Random rnd = new Random();
            ramdomnews = list[rnd.Next(list.Count)];
            allnews = string.Join("\n",list2);

        }
    }
}

  


