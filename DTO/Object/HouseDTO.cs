using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Object
{
    public class HouseDTO : EstateObjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Поверховість\" обов'язкове!")]
        [Display(Name = "Поверховість")]
        [Range(0, int.MaxValue)]
        public int Floors { get; set; }

        [Required(ErrorMessage = "Поле \"Кількість кімнат\" обов'язкове!")]
        [Display(Name = "Кількість кімнат")]
        [Range(1, 20)]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "Поле \"Площа ділянки\" обов'язкове!")]
        [Display(Name = "Площа ділянки")]
        [Range(3, double.MaxValue, ErrorMessage ="Площа ділянки не може бути менше 3 сот.")]
        public double steadArea { get; set; }

        [Required(ErrorMessage = "Поле \"Площа кухні\" обов'язкове!")]
        [Display(Name = "Площа кухні")]
        [Range(3, double.MaxValue)]
        public double kitchenArea { get; set; }

        [Required(ErrorMessage = "Поле \"Житлова площа\" обов'язкове!")]
        [Display(Name = "Житлова площа")]
        [Range(8, double.MaxValue)]
        public double livingArea { get; set; }

        public int estateObjectId { get; set; }
    }
}
