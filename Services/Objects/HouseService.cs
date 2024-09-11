using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.Services.Objects
{
    public class HouseService: IHouseSevice
    {
        IUnitOfWork Database { get; set; }

        public HouseService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<HouseDTO>> GetAllHouses()
        {
            List<HouseDTO> houses = new List<HouseDTO>();
            return houses;
        }

        public async Task<HouseDTO> GetHouseById(int id)
        {
            return new HouseDTO();
        }

        public async Task CreateHouse(HouseDTO officeDTO)
        {

        }
        public async Task UpdateHouse(HouseDTO officeDTO)
        {

        }
        public async Task DeleteHouse(int id)
        {

        }
    }
}
