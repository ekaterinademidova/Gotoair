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
    public class OrderVM
    {

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public IdentityUser? User { get; set; }

        public int? NumberOfFreeFSeats { get; set; }
        public int? NumberOfFreeCSeats { get; set; }
        public int? NumberOfFreeSSeats { get; set; }

        //public bool FClassChecked { get; set; }
        //public bool CClassChecked { get; set; }
        //public bool SClassChecked { get; set; }
    }
}
