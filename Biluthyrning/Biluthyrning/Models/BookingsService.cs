using Biluthyrning.Models.Entities;
using Biluthyrning.Models.ViewModels;
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


        internal void BookCar(CreateBookingVM bookingToSave)
        {
            Customer customer = carRentalContext.Customer.SingleOrDefault(c => c.CustomerSsn == bookingToSave.SSN);
            Booking booking = new Booking
            {
                RentedCar = bookingToSave.CarToBook.Id,
                CustomerId = customer.Id
            };

            carRentalContext.Booking.Add(booking);

            carRentalContext.SaveChanges();
        }
    }
}
