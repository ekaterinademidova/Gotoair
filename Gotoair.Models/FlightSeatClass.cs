using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gotoair.Models
{
    public class FlightSeatClass
    {
        [Key]
        public int Id { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("FlightId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Рейс")]
        public Flight Flight { get; set; }

        public int SeatClassId { get; set; }

        [ForeignKey("SeatClassId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Класс места")]
        public SeatClass SeatClass { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Стоимость билета класса")]
        public decimal Price { get; set; }
    }
}
