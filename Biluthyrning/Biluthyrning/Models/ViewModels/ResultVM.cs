using Biluthyrning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models.ViewModels
{
    public class ResultVM
    {
        public Customer Customer { get; set; }
        public double FinalPrice { get; set; }
    }
}
