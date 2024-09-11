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
    public class GarageService: IGarageService
    {
        IUnitOfWork Database { get; set; }

        public GarageService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<GarageDTO>> GetGarages()
        {
            List<GarageDTO> garages = new List<GarageDTO>();
            return garages;
        }

        public async Task<GarageDTO> GetGarageById(int id)
        {
            GarageDTO garage = new GarageDTO();
            return garage;
        }

        public async Task CreateGarage(GarageDTO garageDTO)
        {

        }
        public async Task UpdateGarage(GarageDTO garageDTO)
        {

        }
        public async Task DeleteGarage(int id)
        {

        }
    }
}
