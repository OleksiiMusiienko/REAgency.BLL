using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Persons
{
    public class PostDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлене.")]
        [Display(Name = "Посада працівника")]
        public string Name { get; set; }

    }
}
