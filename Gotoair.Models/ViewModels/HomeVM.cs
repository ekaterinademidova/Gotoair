using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models.ViewModels
{
    public class HomeVM
    {
        [ValidateNever]
        public IEnumerable<FlightHomeVM> FlightList { get; set; }

        [ValidateNever]
        public IEnumerable<Airplane> AirplaneList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RouteListFrom { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> RouteListTo { get; set; }

        public string? RouteAddressFrom { get; set; }
        public string? RouteAddressTo { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool FClassChecker { get; set; }
        public bool CClassChecker { get; set; }
        public bool SClassChecker { get; set; }

        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }

        public IdentityUser? User { get; set; }
    }
}
