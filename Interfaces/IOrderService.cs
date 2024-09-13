using REAgency.BLL.DTO;
using REAgency.DAL.Entities;

namespace REAgency.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAll();
        Task Create(OrderDTO clientOrder);
        Task Update(OrderDTO clientOrder);
        Task Delete(int id);
        Task<OrderDTO> Get(int id);        
    }
}
