using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using static JonTanTeleBot.InforCalender;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using File = System.IO.File;
using System.Xml.Linq;

namespace JonTanTeleBot
{
    internal class SaveEventJson
    {

        public static void Save()
        {

            string jsonFile = "get json file from cloud.google link tutorial https://stackoverflow.com/questions/54066564/google-calendar-api-with-asp-net ";
            string calendarId = "primary";

            string[] Scopes = { CalendarService.Scope.Calendar };

            ServiceAccountCredential credential;

            using (var stream =
                new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(confg.ClientEmail)
                   {
                       Scopes = Scopes
                   }.FromPrivateKey(confg.PrivateKey));
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });
            var calendar = service.Events.List(calendarId).Execute();
            //save string to json file
            //create a new json file for write item of list event
            string json = JsonConvert.SerializeObject(calendar.Items);
            File.WriteAllText("PATH_File Json for write list event", json);

        }
    }
}





