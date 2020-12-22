using System;

namespace CCM.Infrastructure.Calendar
{
    public class AddUpdateEventToCalendarRequestModel
    {
        public string userUniqueIdentifier { get; set; }
        public string location { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public String summary { get; set; }
        public String Description { get; set; }
        
    }
}