using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.Models
{
    public class SeatClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [MaxLength(1, ErrorMessage = "Максимальная длина наименования - 1 символ")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
