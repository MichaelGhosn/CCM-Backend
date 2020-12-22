using System;

namespace CCM.Infrastructure.Calendar
{
    public interface ICalendar
    {
        public AddEventToCalendarResponseModel AddEventToCalendar(AddEventToCalendarRequestModel configuration);
    }
}