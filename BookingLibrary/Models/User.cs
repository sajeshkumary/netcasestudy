using System;
using System.Collections.Generic;

namespace BookingLibrary.Models
{
    public partial class User
    {
        public User()
        {
            Appservicerequests = new HashSet<Appservicerequest>();
        }

        public int Uid { get; set; }
        public string Usename { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime Createddate { get; set; }

        public virtual ICollection<Appservicerequest> Appservicerequests { get; set; }
    }
}
