using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Identity;

namespace Gotoair.Models
{
    public class FlightSeatClassUser
    {
        [Key]
        public int Id { get; set; }

        public int FlightSeatClassId { get; set; }

        [ForeignKey("FlightSeatClassId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Стоимость класса рейса")]
        public FlightSeatClass FlightSeatClass { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Пользователь")]
        public IdentityUser User { get; set; }

        public int SeatNumber { get; set; }
    }
}
