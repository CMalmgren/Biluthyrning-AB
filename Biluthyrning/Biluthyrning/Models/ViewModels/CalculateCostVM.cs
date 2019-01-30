using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class CalculateCostVM
    {
        [Display(Name ="Personnummer")]
        [Required (ErrorMessage = "Ange personnummer")]
        [RegularExpression(@"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$", ErrorMessage = "Felaktigt ifyllt personnummer")]
        public string CustomerSSN { get; set; }

        public Car RentedCar { get; set; }

        [Display(Name ="Återlämningsdatum")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateReturned { get; set; }

        [Required]
        [Display(Name ="Mätarställning vid återlämning")]
        public int DistanceEnd { get; set; }

        public double FinalPrice { get; set; }

        [Display(Name ="Registreringsnummer")]
        public string CarRegistration { get; set; }
    }
}
