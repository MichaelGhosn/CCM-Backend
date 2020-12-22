using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace CCM.Infrastructure.Calendar
{
    public class GoogleCalendar: ICalendar
    {
        static string[] Scopes = {CalendarService.Scope.Calendar};
        private static string ApplicationName = "Google Calendar Integration";
        private String calendarId = "primary";


        private CalendarService GetCalendarService(String userUniqueIdentifier)
        {
            UserCredential credential;
           
            using (var stream = new FileStream("../CCM.Infrastructure/credentials.json", FileMode.Open, FileAccess.Read))
            {
                
                string credPath = "../CCM.Infrastructure/Tokens/token_" + userUniqueIdentifier +".json"; // if this file doesn't exist, a new tab will open in his browser prompting him to accept the connection with the app

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true))
                    .Result;
            }
            
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
        public AddEventToCalendarResponseModel AddEventToCalendar(AddEventToCalendarRequestModel configuration)
        {

            try
            {

                var service = this.GetCalendarService(configuration.userUniqueIdentifier);

                Event newEvent = new Event();

                EventDateTime start = new EventDateTime();
                start.DateTime = new DateTime(configuration.startTime.Year, configuration.startTime.Month,
                    configuration.startTime.Day,
                    configuration.startTime.Hour, configuration.startTime.Minute, configuration.startTime.Second);

                EventDateTime end = new EventDateTime();
                end.DateTime = new DateTime(configuration.endTime.Year, configuration.endTime.Month,
                    configuration.endTime.Day,
                    configuration.endTime.Hour, configuration.endTime.Minute, configuration.endTime.Second);

                newEvent.Start = start;
                newEvent.End = end;


                newEvent.Summary = configuration.summary;
                newEvent.Description = configuration.Description;

                newEvent.Creator = new Event.CreatorData()
                {
                    DisplayName = "Michael Ghosn",
                    Email = "michaelghosn1999@hotmail.com",
                    Self = false
                };

                newEvent.Location = configuration.location;


                newEvent = service.Events.Insert(newEvent, calendarId).Execute();

                return new AddEventToCalendarResponseModel()
                {
                    Link = newEvent.HtmlLink,
                    EventId = newEvent.Id
                };
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public bool DeleteEventFromCalendar(String userUniqueIdentifier, string eventId)
        {
            try
            {
                var service = this.GetCalendarService(userUniqueIdentifier);
                service.Events.Delete(calendarId, eventId).Execute();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}