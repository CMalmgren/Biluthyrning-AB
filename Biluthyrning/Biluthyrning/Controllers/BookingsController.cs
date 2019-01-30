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
            if (ModelState.IsValid)
            {
                service.BookCar(booking);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
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
            if (ModelState.IsValid)
            {
                return View(service.CalculateCost(calc));
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult ReturnCar(int carId, string ssn, int distanceEnd)
        {
                try
                {
                    service.ReturnCar(carId, ssn, distanceEnd);
                }
                catch (Exception)
                {
                    throw;  //TODO: fånga upp om bokning/bil/nånting inte finns
                }
                return RedirectToAction(nameof(Index));
           
        }
    }
}