using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IFlatService
    {
        Task<IEnumerable<FlatDTO>> GetAllFlats();
        Task<FlatDTO> GetFlatById(int id);
        Task<FlatDTO> GetFlatsByEmployeeId(int employeeId);
        Task<IEnumerable<FlatDTO>> GetFlatsByType(int typeId);
        Task CreateFlat(FlatDTO flatDTO);
        Task UpdateFlat(FlatDTO flatDTO);
        Task DeleteFlat(int id);

    }
}
