using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Map
    {
        public Map()
        {
            Openingtime = new HashSet<Openingtime>();
            Seat = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int? Capacity { get; set; }
        public int? AuthorizedCapacity { get; set; }
        public int? OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Openingtime> Openingtime { get; set; }
        public virtual ICollection<Seat> Seat { get; set; }
    }
}
