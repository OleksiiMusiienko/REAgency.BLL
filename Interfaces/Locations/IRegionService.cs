using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Locations;

namespace REAgency.BLL.Interfaces.Locations
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDTO>> GetRegions();

        Task<RegionDTO> GetRegionById(int id);

        Task<RegionDTO> GetRegionByName(string name);

        Task CreateRegion(RegionDTO regionDTO);
        Task UpdateRegion(RegionDTO regionDTO);
        Task DeleteRegion(int id);
    }
}
