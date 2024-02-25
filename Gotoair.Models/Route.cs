using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [MaxLength(120, ErrorMessage = "Максимальная длина наименования - 120 символов")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Адрес начального пункта")]
        public string AddressFrom { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [DisplayName("Адрес конечного пункта")]
        public string AddressTo { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
