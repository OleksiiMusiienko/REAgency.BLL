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

using REAgency.DAL.Entities.Object;

namespace REAgency.BLL.Services.Objects
{
    public class OfficeService : IOfficeService
    {
        IUnitOfWork Database { get; set; }

        public OfficeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<OfficeDTO>> GetOffices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Office, OfficeDTO>()
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
            return mapper.Map<IEnumerable<Office>, IEnumerable<OfficeDTO>>(await Database.Offices.GetAll());




        }

        public async Task<OfficeDTO> GetOfficeById(int id)
        {
            var office = await Database.Offices.Get(id);
            if (office == null)
                throw new ValidationException("Wrong office!");
            return new OfficeDTO
            {
                Id = office.Id
             
            };
        }


        public async Task CreateOffice(OfficeDTO officeDTO)
        {
            var office = new Office
            {
                Id = officeDTO.Id

            };
            await Database.Offices.Create(office);
            await Database.Save();
        }

        //public async Task Update(FlatDTO flatDTO)
        //{
        //    var flat = new Flat
        //    {
        //        Id = flatDTO.Id,
        //        Floor = flatDTO.Floor,
        //        Floors = flatDTO.Floors,
        //        Rooms = flatDTO.Rooms,
        //        kitchenArea = flatDTO.kitchenArea,
        //        livingArea = flatDTO.livingArea
        //    };
        //    Database.Flats.Update(flat);
        //    await Database.Save();
        //}

        
        public async Task DeleteOffice(int id)
        {
            await Database.Offices.Delete(id);
            await Database.Save();
        }

        
    }
}
