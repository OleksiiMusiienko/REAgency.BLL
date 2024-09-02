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
        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectByEmployeeId(int employeeId);
       
        Task CreateEstateObject(EstateObjectDTO estateObjectsDTO);
        Task UpdateEstateObject(EstateObjectDTO estateObjectsDTO);
        Task DeleteEstateObject(int id);
    }
}
