using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class BookingsService
    {
        CarRentalContext carRentalContext;

        public BookingsService(CarRentalContext carRentalContext)
        {
            this.carRentalContext = carRentalContext;            
        }

        internal List<Car> GetAllCars()
        {
            List<Car> cars = carRentalContext.Car.ToList();

            return cars;
        }
    }
}
