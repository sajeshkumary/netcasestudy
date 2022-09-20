using System;
using System.Collections.Generic;

namespace ProductLibrary.Models
{
    public partial class Appservicerequest
    {
        public Appservicerequest()
        {
            Appservicerequestreports = new HashSet<Appservicerequestreport>();
        }

        public int Id { get; set; }
        public int Productid { get; set; }
        public int Userid { get; set; }
        public DateTime Reqdate { get; set; }
        public string Problem { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Appservicerequestreport> Appservicerequestreports { get; set; }
    }
}
