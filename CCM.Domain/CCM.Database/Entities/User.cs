using System;
using System.Collections.Generic;

namespace CCM.Domain
{
    public partial class User
    {
        public User()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
