using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Locations;

namespace REAgency.BLL.Interfaces.Locations
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictDTO>> GetDistrict();

        Task<DistrictDTO> GetDistrictById(int id);

        Task<DistrictDTO> GetDistrictByName(string name);

        Task CreateDistrict(DistrictDTO districtDTO);
        Task UpdateDistrict(DistrictDTO districtDTO);
        Task DeleteDistrict(int id);
    }
}
