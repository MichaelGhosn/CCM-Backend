using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Openingtime
    {
        public int Id { get; set; }
        public TimeSpan OpeningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
        public int? MapId { get; set; }
        public int? DayId { get; set; }

        public virtual Day Day { get; set; }
        public virtual Map Map { get; set; }
    }
}
