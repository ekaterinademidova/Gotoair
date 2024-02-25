using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models.ViewModels
{
    public class AirplaneModelVM
    {
        public AirplaneModel AirplaneModel { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TypeOfFlightRangeList { get; set; }
    }
}
