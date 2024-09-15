using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Object
{
    public class GarageDTO : EstateObjectDTO
    {
        public int Id { get; set; }
        [Display(Name = "Поверховість")]
        [Range(0, int.MaxValue)]
        public int Floors { get; set; }

        public int estateObjectId { get; set; }
    }
}
