using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IHouseSevice
    {
        Task<IEnumerable<HouseDTO>> GetAllHouses();
        Task<HouseDTO> GetHouseById(int id);
        Task CreateHouse(HouseDTO officeDTO);
        Task UpdateHouse(HouseDTO officeDTO);
        Task DeleteHouse(int id);
    }
}
