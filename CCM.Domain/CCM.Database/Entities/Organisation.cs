using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class Organisation
    {
        public Organisation()
        {
            Map = new HashSet<Map>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Map> Map { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
