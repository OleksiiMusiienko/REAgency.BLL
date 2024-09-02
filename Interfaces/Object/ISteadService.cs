using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface ISteadService
    {
        Task<IEnumerable<SteadDTO>> GetSteads();

        Task<SteadDTO> GetSteadById(int id);
        Task CreateStead(SteadDTO steadDTO);
        Task UpdateStead(SteadDTO steadDTO);
        Task DeleteStead(int id);
    }
}
