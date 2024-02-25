using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models.ViewModels
{
    public class FlightHomeVM
    {
        public Flight FlightHome { get; set; }

        //public int NumberFreeFSets { get; set; }
        //public int NumberFreeCSets { get; set; }
        //public int NumberFreeSSets { get; set; }
        public decimal PriceF { get; set; }
        public decimal PriceC { get; set; }
        public decimal PriceS { get; set; }
    }
}
