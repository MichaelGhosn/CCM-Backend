using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Day
    {
        public Day()
        {
            Openingtime = new HashSet<Openingtime>();
        }

        public int Id { get; set; }
        public string Day1 { get; set; }

        public virtual ICollection<Openingtime> Openingtime { get; set; }
    }
}
