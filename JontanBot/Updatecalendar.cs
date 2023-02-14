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
using static JontanTeleBot.Program;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using File = System.IO.File;
using System.Xml.Linq;

namespace JonTanTeleBot { 
    internal class Updatecalendar
    {
      
        public static void Addnow()
            {

            string jsonFile = "get json file from cloud.google ";
            string calendarId = "get primary";
            //link tutorial https://stackoverflow.com/questions/54066564/google-calendar-api-with-asp-net 
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

               

                // Define parameters of request.
                EventsResource.ListRequest listRequest = service.Events.List(calendarId);
                listRequest.TimeMin = DateTime.Now;
                listRequest.ShowDeleted = false;
                listRequest.SingleEvents = true;
                listRequest.MaxResults = 10;
                listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = listRequest.Execute();
                Console.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (var eventItem in events.Items)
                    {
                        string when = eventItem.Start.DateTime.ToString();
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date;
                        }
                        Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    }      
                }
                else
                {
                    Console.WriteLine("No upcoming events found.");
         
                }
            

            var myevent = DB.Find(x => x.Id == "eventid" + 1);
         
            var InsertRequest = service.Events.Insert(myevent, calendarId);

            try
                {
                    InsertRequest.Execute();
                }
                catch (Exception)
                {
                    try
                    {
                        service.Events.Update(myevent, calendarId, myevent.Id).Execute();
                        Console.WriteLine("Insert/Update new Event ");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("can't Insert/Update new Event ");
                    }
            }
         
  
        }
        //format Event to add to list Calendar 
        static List<Event> DB = new List<Event>() { new Event()
            {
                    Id = "eventid" + 1,
                    Summary = InforCalender.Sm,
                    Location = "Hồ Chí Minh, Thành phố Hồ Chí Minh, Việt Nam",
                    Description = InforCalender.Dc,
                    Start = new EventDateTime()
                    {
                        Date = Convert.ToString(year+"-"+month+"-"+day),
                        TimeZone = "Asia/Ho_Chi_Minh",
                    },
                    End = new EventDateTime()
                    {
                        //if event have start - end time
                        //Datetime = new Date(year,month,day),
                        //if event all day
                        Date = Convert.ToString(year+"-"+month+"-"+day),
                        TimeZone ="Asia/Ho_Chi_Minh",
                    },


                }

                 };
    }
    }




    
