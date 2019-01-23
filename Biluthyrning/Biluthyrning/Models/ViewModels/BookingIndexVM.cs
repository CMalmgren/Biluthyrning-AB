﻿using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class BookingIndexVM
    {
        public List<Car> AvailableCars { get; set; }
        public List<Car> BookedCars { get; set; }
    }
}
