using REAgency.BLL.DTO;

namespace REAgency.BLL.Interfaces
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationDTO>> GetAll();
        Task<OperationDTO> Get(int id);
        Task<OperationDTO> GetByName(string name);
    }
}
