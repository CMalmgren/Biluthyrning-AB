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
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculateCostVM calc)
        {
            ResultVM resultVM = service.CalculateCost(calc);

            return View(resultVM);
        }


    }
}