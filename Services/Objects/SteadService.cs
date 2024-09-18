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
    public class SteadService : ISteadService
    {
        IUnitOfWork Database { get; set; }

        public SteadService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<SteadDTO>> GetSteads()
        {
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Stead, SteadDTO>()
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
            return mapper.Map<IEnumerable<Stead>, IEnumerable<SteadDTO>>(await Database.Steads.GetAll());




        }
        public async Task<SteadDTO> GetSteadById(int id)
        {
            var stead = await Database.Steads.Get(id);
            if (stead == null)
                throw new ValidationException("Wrong stead!");
            return new SteadDTO
            {
               Id = stead.Id,
               Cadastr = stead.Cadastr,
               Use = stead.Use

            };
        }


        public async Task CreateStead(SteadDTO steadDTO)
        {
            var stead = new Stead
            {
                Id = steadDTO.Id,
                Cadastr = steadDTO.Cadastr,
                Use = steadDTO.Use
            };
            await Database.Steads.Create(stead);
            await Database.Save();
        }

        public async Task UpdateStead(SteadDTO steadDTO)
        {
            var stead = new Stead
            {
                Id = steadDTO.Id,
                Cadastr = steadDTO.Cadastr,
                Use = steadDTO.Use
            };
            Database.Steads.Update(stead);
            await Database.Save();
        }

        public async Task DeleteStead(int id)
        {
            await Database.Steads.Delete(id);
            await Database.Save();
        }

    }
}
