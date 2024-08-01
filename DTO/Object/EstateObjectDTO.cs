using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.DTO.Object
{
    public class EstateObjectDTO
    {
        public int countViews { get; set; }  //количество просмотров обьекта считает средний слой
        public int estateTypeId { get; set; }
        public string estateType { get; set; }
        
        //ез нижнего слоя придет обьект Client, нам нужно отобразить на вьюшке
        //(для сотрудника или админа) имя и телефон клиента
        public string clientName { get; set; } 
        public string clientPhone { get; set; }
        //приходит сотрудник, отображаем имя и телефон для всех
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeePhone { get; set; }

        public int operationId { get; set; }
        public string operationName { get; set; }

       //по локациям отображаем страну, область, район, населенный пункт
        public int locationId { get; set; }
        public string countryName { get; set; }
        public string regionName { get; set; }
        public string districtName { get; set; }
        public string localityName { get; set; }
        public string? Street { get; set; }
        public int? numberStreet { get; set; }

        [Required(ErrorMessage = "Поле \"Ціна\" обов'язкове!")]
        [Display(Name = "Ціна")]
        [Range(30, int.MaxValue)]
        public int Price { get; set; }
        public int currencyId { get; set; }
        public string currencyName { get; set; }

        [Required(ErrorMessage = "Поле \"Загальга площа\" обов'язкове!")]
        [Display(Name = "Загальна площа")]
        [Range(0.1, double.MaxValue)]
        public double Area { get; set; }
        public int areaId { get; set; }
        public string areaName { get; set; }

        [Required(ErrorMessage = "Поле \"Опис\" обов'язкове!")]
        [Display(Name = "Опис")]
        [StringLength(1500), MinLength(150)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string? pathPhoto { get; set; }
    }
}
