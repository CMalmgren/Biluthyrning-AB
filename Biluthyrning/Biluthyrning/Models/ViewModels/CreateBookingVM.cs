using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class CreateBookingVM
    {
        public string SSN { get; set; }

        public Car CarToRent { get; set; }
    }
}
