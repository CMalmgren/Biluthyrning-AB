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
        [Required, MaxLength(13, ErrorMessage ="Ange personnumret i formatet ÅÅÅÅMMDD-NNNN")]
        [RegularExpression("^ (19 | 20)?[0 - 9]{6}[- ]?[0 - 9]{4}$")]
        public string CustomerSSN { get; set; }

        public Car RentedCar { get; set; }
        public DateTime DateRented { get; set; }

        [Display(Name ="Återlämningsdatum")]
        [DataType(DataType.Date)]
        public DateTime DateReturned { get; set; }

        [Display(Name ="Mätarställning vid återlämning")]
        public int DistanceEnd { get; set; }
    }
}
