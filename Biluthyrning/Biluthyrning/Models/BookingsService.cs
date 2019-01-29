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

        internal List<Car> GetAvailableCars()
        {
            List<Car> cars = carRentalContext.Car.ToList();
            List<Car> availableCars = new List<Car>();
            foreach (Car car in cars)
            {
                if (!carRentalContext.Booking.Any(b => b.RentedCar == car.Id))
                {
                    availableCars.Add(car);
                }
               
            }

            return availableCars;
        }

        internal void BookCar(CreateBookingVM createBooking)
        {
            Customer customer = new Customer();

            if (carRentalContext.Customer.Any(c => c.CustomerSsn == createBooking.SSN))
            {
                Customer existingCustomer = carRentalContext.Customer.SingleOrDefault(c => c.CustomerSsn == createBooking.SSN);
                customer = existingCustomer;
            }
            else
            {
                Customer newCustomer = new Customer
                {
                    CustomerSsn = createBooking.SSN
                };
                carRentalContext.Customer.Add(newCustomer);
                carRentalContext.SaveChanges();
                customer = newCustomer;
            }

            Booking booking = new Booking
            {
                RentedCar = carRentalContext.Car.SingleOrDefault(c => c.CarRegistrationNumber == createBooking.RegistrationNumber).Id,
                CustomerId = customer.Id,
            };

            carRentalContext.Booking.Add(booking);
            carRentalContext.SaveChanges();
        }

        internal CreateBookingVM GetCarVM(string reg)
        {
            CreateBookingVM vm = new CreateBookingVM
            {
                //CarToBook = carRentalContext.Car.SingleOrDefault(c => c.CarRegistrationNumber == reg),
            };

            return vm;
        }

        internal CalculateCostVM CalculateCost(CalculateCostVM calcVM)
        {
            Booking booking = carRentalContext.Booking.SingleOrDefault(c => c.RentedCar == calcVM.RentedCar.Id);

            double price = -1;
            double kmPrice = 1;
            int numberOfKm = (int)calcVM.RentedCar.DistanceEnd - calcVM.RentedCar.DistanceStart;

            int baseDayRental = 200;

            double numberOfDays = calcVM.DateReturned.Subtract(calcVM.DateRented).TotalDays + 1;  //Just nu räknas både start- och slutdag som dagar man betalar för.

            if (calcVM.RentedCar.CarType == "Liten bil")
            {
                price = baseDayRental * numberOfDays;
            }
            else if (calcVM.RentedCar.CarType == "Van")
            {
                price = baseDayRental * numberOfDays * 1.2 + (kmPrice * numberOfKm);
            }
            else if (calcVM.RentedCar.CarType == "Minibuss")
            {
                price = baseDayRental * numberOfDays * 1.7 + (kmPrice * numberOfKm * 1.5);
            }
            else
            {
                throw new Exception("Type of car not supported");
            }

            calcVM.FinalPrice = price;

            return calcVM;
        }
    }
}
