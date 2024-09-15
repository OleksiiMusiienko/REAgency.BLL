using REAgency.DAL.Entities;
using REAgencyEnum;

namespace REAgency.BLL.DTO
{
    public class OrderDTO
    {

        public int Id { get; set; }
        public OrderName orderClient { get; set; }
        public List<ObjectsForOrders>? objectsForOrders { get; set; } = new(); //id отобранных обьектов
        public int? idClient { get; set; }//если клиент авторизован
        public string? Name { get; set; }//имя с формы
        public string? Phone { get; set; }//телефон с формы
    }
}
