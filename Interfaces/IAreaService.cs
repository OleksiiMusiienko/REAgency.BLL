using REAgency.BLL.DTO;

namespace REAgency.BLL.Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<AreaDTO>> GetAll();
        Task<AreaDTO> Get(int id);
        Task<AreaDTO> GetByName(string name);
    }
}
