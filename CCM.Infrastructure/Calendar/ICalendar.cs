using System;
using System.Collections.Generic;

namespace CCM.Infrastructure.Calendar
{
    public interface ICalendar
    {
        public AddEventToCalendarResponseModel AddEventToCalendar(AddUpdateEventToCalendarRequestModel configuration);
        public bool DeleteEventFromCalendar(String userUniqueIdentifier, String eventId);
        public bool UpdateEventFromCalendar(AddUpdateEventToCalendarRequestModel configuration, String eventId);
    }
}