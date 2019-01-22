using System;
using System.Collections.Generic;

namespace Biluthyrning.Models.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            Car = new HashSet<Car>();
        }

        public int BookingNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime? RentalEnd { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Car> Car { get; set; }
    }
}
