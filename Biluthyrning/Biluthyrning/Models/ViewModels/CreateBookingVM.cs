using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class CreateBookingVM
    {
        [Display(Name = "Personnummer")]
        [Required(ErrorMessage = "Ange personnummer")]
        [RegularExpression(@"^(((20)((0[0-9])|(1[0-1])))|(([1][^0-8])?\d{2}))((0[1-9])|1[0-2])((0[1-9])|(2[0-9])|(3[01]))[-]?\d{4}$", ErrorMessage = "Felaktigt ifyllt personnummer")]
        public string SSN { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Startdatum")]
        public DateTime StartOfRental { get; set; }

        public List<Car> AvailableCars { get; set; }
    }
}
