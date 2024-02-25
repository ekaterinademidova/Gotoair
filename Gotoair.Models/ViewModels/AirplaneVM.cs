using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models.ViewModels
{
    public class AirplaneVM
    {
        public Airplane Airplane { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AirplaneModelList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AirplaneStateList { get; set; }
    }
}
