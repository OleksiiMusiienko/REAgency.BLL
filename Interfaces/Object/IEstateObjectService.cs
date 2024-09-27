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
        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectByOperationId(int operationId);

        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectByLocalityId(int localityId);
        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectByEstateTypeId(int estateTypeId);

        Task<IEnumerable<EstateObjectDTO>> GetEstateObjectByOperationAndLocalityId(int operationId,int localityId);
        Task<IEnumerable<EstateObjectDTO>> GetFilteredEstateObjects(int? typeId, int? operationTypeId, int? localityId, int? minPrice,
            int? maxPrice, double? minArea, double? maxArea);
        Task<EstateObjectDTO> GetByDateTime(DateTime date);
        Task CreateEstateObject(EstateObjectDTO estateObjectsDTO);
        Task UpdateEstateObject(EstateObjectDTO estateObjectsDTO);
        Task DeleteEstateObject(int id);
        Task UpdateEstateObjectPath(EstateObjectDTO estateObjectsDTO);
    }
}
