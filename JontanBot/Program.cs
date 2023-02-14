using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using HtmlAgilityPack;
using System.Collections;
using System.Collections.Generic;
using static JonTanTeleBot.Updatecalendar;
using static JonTanTeleBot.NewsUpClass;
using static JonTanTeleBot.InforCalender;
using static JonTanTeleBot.GetListEvents;
using static JonTanTeleBot.SaveEventJson;
using static JontanTeleBot.DataUsersConTact;
using static JontanTeleBot.Titlevideo;
using System.Numerics;
using Google.Apis.Calendar.v3;
using File = System.IO.File;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.VisualBasic;


namespace JontanTeleBot
{

    public class Program
    {
        private static string yturl = " ";
        public static string Yturl
        {
            get { return yturl; }
            set { yturl = value; }

        }
        static ITelegramBotClient _telegramBotClient = new TelegramBotClient("YOUR_BOT_TOKEN");// get token bot from bot father on telegram
        public static async Task HandleUpdateAsync(ITelegramBotClient _telegramBotClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));//return information of new message to bot    

            //set data 
            string data = JsonConvert.SerializeObject(update.Message);
            //create json file to save information of new message
            File.WriteAllText("PATH_File json you created", data);
            SaveDataUsers();

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {

                //Accessing the added worksheet in the Excel file
                var message = update.Message;// get value of message from user
                string mes = message.Text;

                //text to save all task of bot
                string text = System.IO.File.ReadAllText(@"PATH_FILE .txt");
                switch (mes)
                {
                    case "/start":
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "JonTan có thể giúp gì cho bạn? Nhập lệnh /help nhé!", cancellationToken: cancellationToken);
                        return;
                    case "/thanks":
                        await _telegramBotClient.SendStickerAsync(message.Chat, sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp", cancellationToken: cancellationToken);
                        return;
                    case "/help":
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, text, cancellationToken: cancellationToken);
                        return;
                    case "/nevent":
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "Nhập tên sự kiện đi @+[tên sự kiện]", cancellationToken: cancellationToken);
                        return;
                    case "/scalendar":
                        Save();// call save json calendar file before read file if it was use add method
                        ShowlistEvents();// call show list Events 
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, Ev, cancellationToken: cancellationToken);
                        return;
                    case "/news":
                        Upnews();
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, RmdomNews, cancellationToken: cancellationToken);
                        return;
                    case "/allnews":
                        Upnews();
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, AllNews, cancellationToken: cancellationToken);
                        return;
                    case "/listen":
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "Để nghe nhạc bạn vui lòng nhập >p+[link]  \n ví dụ: >p youtube.com", cancellationToken: cancellationToken);
                        return;
                }
                if (mes[0] == '>')
                {
                    try
                    {
                        yturl = mes.Remove(0, 3);
                        await GetTitle();
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "Đã nhận bài hát: " + TitleVideo, cancellationToken: cancellationToken);
                        await PlayMusic();
                        using (var stream = System.IO.File.OpenRead(@"C:\Users\LEGION\Videos\New folder\.mp4"))
                        {
                            await _telegramBotClient.SendVoiceAsync(message.Chat, stream);
                        }
                        Console.WriteLine(yturl);
                    }
                    catch (Exception loi)
                    {
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "Bạn nhập sai rồi nhập lại nhé!", cancellationToken: cancellationToken);
                    }
                    return;

                }
            
                if (mes[0] == '@')
                {
                    string RemovefirstChar = mes.Remove(0, 1);
                    Sm = RemovefirstChar;
                    await _telegramBotClient.SendTextMessageAsync(message.Chat, "Nhập trình bày sự kiện !+[trình bày sự kiện]", cancellationToken: cancellationToken);
                    return;
                }
                if (mes[0] == '!')
                {
                    string RemovefirstChar = mes.Remove(0, 1);
                    Dc = RemovefirstChar;
                    await _telegramBotClient.SendTextMessageAsync(message.Chat, "Nhập #+[thời gian sự kiện] ví dụ: \n Ngày 30/11/2022 - #2022,11,30 \n Ngày 5/11/2022 - #2022,11,05", cancellationToken: cancellationToken);
                    return;
                }
                if (mes[0] == '#' && mes.Length == 11)
                {
                try
                {
                    string RemovefirstChar = mes.Remove(0, 1);
                    string GetYear = RemovefirstChar.Remove(4, 6);
                    string RemoveYearChar = RemovefirstChar.Remove(0, 5);
                    string GetMonth = RemoveYearChar.Remove(2, 3);
                    string RemoveMonthChar = RemovefirstChar.Remove(0, 8);
                    string GetDay = RemoveMonthChar.Remove(2, 0);
                    int y = 0; int m = 0; int d = 0;
                    Int32.TryParse(GetYear, out y);
                    Int32.TryParse(GetMonth, out m);
                    Int32.TryParse(GetDay, out d);
                    year = y; month = m; day = d;
                    Console.WriteLine(year + " " + month + " " + day);
                    await _telegramBotClient.SendTextMessageAsync(message.Chat, "Nhập /add để thêm lịch", cancellationToken: cancellationToken);
                }
                catch(Exception loi)
                {
                        await _telegramBotClient.SendTextMessageAsync(message.Chat, "Bạn nhập sai ngày rồi nhập lại nhé!", cancellationToken: cancellationToken);
                }
                    return;
                }

                if (message.Text.ToLower() == "/add")
                {
                    Addnow();
                    await _telegramBotClient.SendTextMessageAsync(message.Chat, "Thêm lịch thành công!", cancellationToken: cancellationToken);
                    return;
                }
                await _telegramBotClient.SendTextMessageAsync(message.Chat, "Mời nhập lệnh mới.", cancellationToken: cancellationToken);
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            //write error about sever
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        static void Main(string[] args)
        {
            var me = _telegramBotClient.GetMeAsync().Result;
            Console.WriteLine($"Hello! I am user {me.Id} and my name is {me.FirstName}.");
            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            _telegramBotClient.StartReceiving(
               HandleUpdateAsync,
               HandleErrorAsync,
               cancellationToken: cts.Token,
               receiverOptions: receiverOptions
             );
            Console.ReadLine();
        }
    }
}