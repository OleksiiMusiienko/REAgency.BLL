using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Object
{
    public class SteadDTO : EstateObjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле \"Кадастр\" обов'язкове!")]
        public string Cadastr { get; set; }
        [Required(ErrorMessage = "Поле \"Землекористування\" обов'язкове!")]
        public LandUse Use { get; set; }
    }
    public enum LandUse
    {
        // here would be a allowed items for field "use"
    }
}
