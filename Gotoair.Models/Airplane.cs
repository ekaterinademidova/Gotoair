using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Gotoair.Models.ViewModels;

namespace Gotoair.Models
{
    public class Airplane
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [MaxLength(7, ErrorMessage = "Максимальная длина наименования - 7 символов")]
        [DisplayName("Серийный номер")]
        public string SerialNumber { get; set; }

        public int AirplaneModelId { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [ForeignKey("AirplaneModelId")]
        [ValidateNever]
        public AirplaneModel AirplaneModel { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Дата производства")]
        public DateTime DateOfManufacture { get; set; }

        public int AirplaneStateId { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [ForeignKey("AirplaneStateId")]
        [ValidateNever]
        public AirplaneState AirplaneState { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
