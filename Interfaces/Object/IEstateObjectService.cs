using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IEstateObjectService 
    {
        Task<IEnumerable<EstateObjectDTO>> GetAllEstateObjects();
        Task<EstateObjectDTO> GetEstateObjectById(int id);
        Task<EstateObjectDTO> GetEstateObjectByEmployeeId(int employeeId);
        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectsByType(int typeId);
        Task CreateEstateObjects(EstateObjectDTO estateObjectsDTO);
        Task UpdateEstateObjects(EstateObjectDTO estateObjectsDTO);
        Task DeleteEstateObjects(int id);
    }
}
