using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gotoair.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательное")]
        [MaxLength(120, ErrorMessage = "Максимальная длина наименования - 120 символов")]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string? Description { get; set; }
    }
}
