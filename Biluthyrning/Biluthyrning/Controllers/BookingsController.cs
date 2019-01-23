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
            return View();
        }

        [HttpPost]
        public IActionResult Book(CreateBookingVM booking)
        {
            service.BookCar(booking.CarToBook);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculateCostVM calc)
        {
            return View();
        }


    }
}