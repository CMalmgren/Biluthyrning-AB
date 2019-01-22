using System;
using System.Collections.Generic;

namespace Biluthyrning.Models.Entities
{
    public partial class Car
    {
        public int Id { get; set; }
        public int? BookingNumber { get; set; }
        public string CarType { get; set; }
        public string CarRegistrationNumber { get; set; }
        public int DistanceStart { get; set; }
        public int? DistanceEnd { get; set; }

        public virtual Booking BookingNumberNavigation { get; set; }
    }
}
