using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class CalculateCostVM
    {
        public Car RentedCar { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
    }
}
