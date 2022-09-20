using System;
using System.Collections.Generic;

namespace BookingLibrary.Models
{
    public partial class Appservicerequestreport
    {
        public int Id { get; set; }
        public int Servicereqid { get; set; }
        public DateTime Reportdate { get; set; }
        public string Servicetype { get; set; } = null!;
        public string Actiontaken { get; set; } = null!;
        public string Diagnosticdetails { get; set; } = null!;
        public string Ispaid { get; set; } = null!;
        public decimal Visitfees { get; set; }
        public string Repairdetails { get; set; } = null!;

        public virtual Appservicerequest Servicereq { get; set; } = null!;
    }
}
