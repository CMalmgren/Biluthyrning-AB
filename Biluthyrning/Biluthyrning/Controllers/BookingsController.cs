using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biluthyrning.Models;
using Biluthyrning.Models.Entities;
using Biluthyrning.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Biluthyrning.Controllers
{
    public class BookingsController : Controller
    {
        BookingsService service;

        public BookingsController(BookingsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            (List<Car> availableCars, List<Car> bookedCars) = service.GetAllCars();

            BookingIndexVM vm = new BookingIndexVM
            {
                AvailableCars = availableCars,
                BookedCars = bookedCars
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Book()
        {
            CreateBookingVM bookingVM = new CreateBookingVM
            {
                AvailableCars = service.GetAvailableCars()
            };
            return View(bookingVM);
        }

        [Route("/Bookings/Book/{reg}")]
        [HttpGet]
        public IActionResult Book(string reg)
        {
            CreateBookingVM vm = service.GetCarVM(reg);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Book(CreateBookingVM booking)
        {
            service.BookCar(booking);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            CalculateCostVM calc = new CalculateCostVM()
            {
                FinalPrice = 0,
            };
            return View(calc);
        }

        [HttpPost]
        public IActionResult Calculate(CalculateCostVM calc)
        {
            CalculateCostVM resultVM = service.CalculateCost(calc);
            return View(resultVM);
        }

        [HttpPost]
        public IActionResult ReturnCar(int carId, string ssn, int distanceEnd)
        {
            service.ReturnCar(carId, ssn, distanceEnd);
            return RedirectToAction(nameof(Index));
        }
    }
}