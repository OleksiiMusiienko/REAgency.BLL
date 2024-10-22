using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Persons
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле має бути встановлене.")]
        [Display(Name = "Імя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле має бути встановлене.")]
        [Display(Name = "Телефон")]
        public string Phone1 { get; set; }

        [Required(ErrorMessage = "Поле має бути встановлене.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Електрона пошта")]
        public string? Email { get; set; }

        public bool userStatus { get; set; }

        [Display(Name = "Дата народження")]
        public DateOnly? DateOfBirth { get; set; }
    }
}
