using System;
using System.Collections.Generic;

namespace Biluthyrning.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string CustomerSsn { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
