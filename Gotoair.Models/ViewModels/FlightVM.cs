using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models.ViewModels
{
    public class FlightVM
    {
        public Flight Flight { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RouteList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AirplaneList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TypeOfTransportationList { get; set; }

        public decimal PriceF { get; set; }
        public decimal PriceC { get; set; }
        public decimal PriceS { get; set; }
    }
}
