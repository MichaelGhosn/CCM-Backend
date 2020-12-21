using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Seat
    {
        public Seat()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MapId { get; set; }
        public String Name { get; set; }

        public virtual Map Map { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
