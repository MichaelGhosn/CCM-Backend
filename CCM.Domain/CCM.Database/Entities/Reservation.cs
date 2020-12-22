using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        
        public string Link { get; set; }
        public int SeatId { get; set; }
        public int UserId { get; set; }
        public string EventId { get; set; }
        

        public virtual Seat Seat { get; set; }
        public virtual User User { get; set; }
    }
}
