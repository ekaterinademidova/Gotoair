using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gotoair.Models
{
    public class AirplaneModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [MaxLength(120, ErrorMessage = "Максимальная длина наименования - 120 символов")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company Company { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [Range(1, 860, ErrorMessage = "Допустимый диапазон значений 1-860")]
        [DisplayName("Первый класс")]
        public int NumberOfFClassSeats { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [Range(1, 860, ErrorMessage = "Допустимый диапазон значений 1-860")]
        [DisplayName("Бизнес-класс")]
        public int NumberOfCClassSeats { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [Range(1, 860, ErrorMessage = "Допустимый диапазон значений 1-860")]
        [DisplayName("Эконом-класс")]
        public int NumberOfSClassSeats { get; set; }

        public int TypeOfFlightRangeId { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [ForeignKey("TypeOfFlightRangeId")]
        [ValidateNever]
        public TypeOfFlightRange TypeOfFlightRange { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
