using System;
using System.Collections.Generic;

namespace Biluthyrning.Models.Entities
{
    public partial class Booking
    {
        public int BookingNumber { get; set; }
        public int CustomerId { get; set; }
        public int RentedCar { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car RentedCarNavigation { get; set; }
    }
}
