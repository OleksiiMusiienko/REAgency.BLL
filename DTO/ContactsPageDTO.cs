using System.ComponentModel.DataAnnotations;

namespace REAgency.Models
{
    public class ContactsPageDTO
    {
        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не може бути пустим")]
        public string Text { get; set; }        
    }
}
