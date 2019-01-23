using System;
using System.Collections.Generic;

namespace Biluthyrning.Models.Entities
{
    public partial class Car
    {
        public Car()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string CarType { get; set; }
        public string CarRegistrationNumber { get; set; }
        public int DistanceStart { get; set; }
        public int? DistanceEnd { get; set; }
        public DateTime? RentalStart { get; set; }
        public DateTime? RentalEnd { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
