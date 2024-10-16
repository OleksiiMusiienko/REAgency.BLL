using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IGarageService
    {
        Task<IEnumerable<GarageDTO>> GetGarages();
        Task<GarageDTO> GetGarageById(int id);      
        Task<GarageDTO> GetGarageByEstateObjectId(int id);      

        Task CreateGarage(GarageDTO garageDTO);
        Task UpdateGarage(GarageDTO garageDTO);
        Task DeleteGarage(int id);
    }
}
