using System;
using System.Collections.Generic;

namespace BookingLibrary.Models
{
    public partial class Product
    {
        public Product()
        {
            Appservicerequests = new HashSet<Appservicerequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Cost { get; set; }
        public DateTime Createddate { get; set; }

        public virtual ICollection<Appservicerequest> Appservicerequests { get; set; }
    }
}
