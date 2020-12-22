using System;

namespace CCM.Infrastructure.Calendar
{
    public interface ICalendar
    {
        public AddEventToCalendarResponseModel AddEventToCalendar(AddEventToCalendarRequestModel configuration);
        public bool DeleteEventFromCalendar(String userUniqueIdentifier, String eventId);
    }
}