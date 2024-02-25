using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gotoair.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Маршрут")]
        public Route Route { get; set; }

        public int AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Самолёт")]
        public Airplane Airplane { get; set; }

        public int TypeOfTransportationId { get; set; }

        [ForeignKey("TypeOfTransportationId")]
        [ValidateNever]
        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Вид перевозки")]
        public TypeOfTransportation TypeOfTransportation { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Дата и время отправки")]
        public DateTime DateAndTimeStart { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Дата и время посадки")]
        public DateTime DateAndTimeEnd { get; set; }

        [DisplayName("Список свободных мест первого класса")]
        public int[]? FreeFSeats { get; set; }

        [DisplayName("Список свободных мест бизнес-класса")]
        public int[]? FreeCSeats { get; set; }

        [DisplayName("Список свободных мест эконом-класса")]
        public int[]? FreeSSeats { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
