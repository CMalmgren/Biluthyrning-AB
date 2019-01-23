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
            List<Car> cars = service.GetAllCars();
            BookingIndexVM vm = new BookingIndexVM
            {
                AvailableCars = cars.Where(c => c.BookingNumber == null).ToList(),
                BookedCars = cars.Where(c => c.BookingNumber != null).ToList()
            };
            return View(vm);
        }
    }
}