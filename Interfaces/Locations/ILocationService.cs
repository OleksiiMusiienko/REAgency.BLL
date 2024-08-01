using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Locations;


namespace REAgency.BLL.Interfaces.Locations
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetLocations();
        Task<LocationDTO> GetLocationsById(int id);
        Task CreateLocation(LocationDTO locationDTO);
        Task UpdateLocation(LocationDTO locationDTO);
        Task DeleteLocation(int id);
    }
}
