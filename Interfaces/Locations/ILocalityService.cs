using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Locations;

namespace REAgency.BLL.Interfaces.Locations
{
    public interface ILocalityService
    {
        Task<IEnumerable<LocalityDTO>> GetLocalities();

        Task<LocalityDTO> GetLocalityById(int id);

        Task<LocalityDTO> GetLocalityByName(string name);

        Task CreateLocality(LocalityDTO localityDTO);
        Task UpdateLocality(LocalityDTO localityDTO);
        Task DeleteLocality(int id);
    }
}
