using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services.Objects
{
    public class GarageService : IGarageService
    {
        IUnitOfWork Database { get; set; }

        public GarageService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<GarageDTO>> GetGarages()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Garage, GarageDTO>()
                .ForMember("Price", opt => opt.MapFrom(c => c.estateObject.Price))
                .ForMember("countViews", opt => opt.MapFrom(c => c.estateObject.countViews))
                .ForMember("clientId", opt => opt.MapFrom(c => c.estateObject.clientId))
                .ForMember("employeeId", opt => opt.MapFrom(c => c.estateObject.employeeId))
                .ForMember("operationId", opt => opt.MapFrom(c => c.estateObject.operationId))
                .ForMember("locationId", opt => opt.MapFrom(c => c.estateObject.locationId))
                .ForMember("Street", opt => opt.MapFrom(c => c.estateObject.Street))
                .ForMember("numberStreet", opt => opt.MapFrom(c => c.estateObject.numberStreet))
                .ForMember("currencyId", opt => opt.MapFrom(c => c.estateObject.currencyId))
                .ForMember("Area", opt => opt.MapFrom(c => c.estateObject.Area))
                .ForMember("unitAreaId", opt => opt.MapFrom(c => c.estateObject.unitAreaId))
                .ForMember("Description", opt => opt.MapFrom(c => c.estateObject.Description))
                .ForMember("Status", opt => opt.MapFrom(c => c.estateObject.Status))
                .ForMember("Date", opt => opt.MapFrom(c => c.estateObject.Date))
                .ForMember("pathPhoto", opt => opt.MapFrom(c => c.estateObject.pathPhoto))

                );
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Garage>, IEnumerable<GarageDTO>>(await Database.Garages.GetAll());




        }

        public async Task<GarageDTO> GetGarageById(int id)
        {
            var garage = await Database.Garages.Get(id);
            if (garage == null)
                throw new ValidationException("Wrong office!");
            return new GarageDTO
            {
                Id = garage.Id,
                Floors = garage.Floors

            };
        }


        public async Task CreateGarage(GarageDTO garageDTO)
        {
            var garage = new Garage
            {
                Id = garageDTO.Id,
                Floors = garageDTO.Floors

            };
            await Database.Garages.Create(garage);
            await Database.Save();
        }

        public async Task UpdateGarage(GarageDTO garageDTO)
        {
            var garage = new Garage
            {
                Id = garageDTO.Id,
                Floors = garageDTO.Floors

            };
            Database.Garages.Update(garage);
            await Database.Save();
        }

        public async Task DeleteGarage(int id)
        {
            await Database.Garages.Delete(id);
            await Database.Save();
        }
    }
}
