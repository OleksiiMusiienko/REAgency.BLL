using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Persons
{
    public class EmployeeDTO : PersonDTO
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле має бути встановлене.")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Avatar { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлене.")]
        [Display(Name = "Додатковий номер телефону")]
        public string? Phone2 { get; set; }

        [Required(ErrorMessage = "Поле має бути встановлене.")]
        public DateTime dateReg { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлене.")]
        public bool adminStatus { get; set; }
        [Display(Name = "Посада працівника")]
        public string? Post { get; set; }
        public int postId { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }

    }
}
