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

        internal (List<Car>, List<Car>) GetAllCars()
        {
            List<Car> cars = carRentalContext.Car.ToList();
            List<Car> availableCars = new List<Car>();
            List<Car> bookedCars = new List<Car>();

            foreach (Car car in cars)
            {
                if (carRentalContext.Booking.Any(b => b.RentedCar == car.Id))
                {
                    bookedCars.Add(car);
                }
                else
                {
                    availableCars.Add(car);
                }
            }


            return (availableCars, bookedCars);
        }

        internal void BookCar(Car carToBook)
        {
            Booking booking = new Booking();
            //booking.Car = carRentalContext.Car.SingleOrDefault(c => c.CarRegistrationNumber == carToBook.CarRegistrationNumber);


        }
    }
}
