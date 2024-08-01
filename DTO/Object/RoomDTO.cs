using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Object
{
    public class RoomDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Поверх\" обов'язкове!")]
        [Display(Name = "Поверх")]
        [Range(0, int.MaxValue)]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Поле \"Поверховість\" обов'язкове!")]
        [Display(Name = "Поверховість")]
        [Range(0, int.MaxValue)]
        public int Floors { get; set; }

        [Required(ErrorMessage = "Поле \"Житлова площа\" обов'язкове!")]
        [Display(Name = "Житлова площа")]
        [Range(5, double.MaxValue)]
        public double livingArea { get; set; }
    }
}
