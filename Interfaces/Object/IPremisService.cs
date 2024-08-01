using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IPremisService
    {
        Task<IEnumerable<PremisDTO>> GetPremises();

        Task<PremisDTO> GetPremisById(int id);

        Task<PremisDTO> GetPremisByEmployee(int employeeId);

        Task CreatePremis(PremisDTO premisDTO);
        Task UpdatePremis(PremisDTO premisDTO);
        Task DeletePremis(int id);
    }
}
