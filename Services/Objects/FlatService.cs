using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using REAgency.BLL.DTO;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.DTO.Persons;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services.Objects
{
    public class FlatService : IFlatService
    {
        IUnitOfWork Database { get; set; }

        public FlatService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<FlatDTO>> GetAllFlats()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Flat, FlatDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Flat>, IEnumerable<FlatDTO>>(await Database.Flats.GetAll());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Flat, FlatDTO>()
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
            return mapper.Map<IEnumerable<Flat>, IEnumerable<FlatDTO>>(await Database.Flats.GetAll());


          

        }
        public async Task<FlatDTO> GetFlatById(int id)
        {
            var flat = await Database.Flats.Get(id);
            if (flat == null)
                throw new ValidationException("Wrong flat!");
            return new FlatDTO
            {
                Id = flat.Id,
                Floor = flat.Floor,
                Floors = flat.Floors,
                Rooms = flat.Rooms,
                kitchenArea = flat.kitchenArea,
                livingArea = flat.livingArea,
                countViews = flat.estateObject.countViews,
                //clientName = estateObject.Client.Name,
                //clientPhone = estateObject.Client.Phone1,
                employeeId = flat.estateObject.employeeId,
                //employeeName = estateObject.Employee.Name,
                //employeePhone = estateObject.Employee.Phone1,
                operationId = flat.estateObject.operationId,
                //operationName = estateObject.Operation.Name,
                locationId = flat.estateObject.locationId,
                Street = flat.estateObject.Street,
                numberStreet = flat.estateObject.numberStreet,
                Price = flat.estateObject.Price,
                currencyId = flat.estateObject.currencyId,
                //currencyName = estateObject.Currency.Name,
                Area = flat.estateObject.Area,
                unitAreaId = flat.estateObject.unitAreaId,
                //areaName = estateObject.unitArea.Name,
                Description = flat.estateObject.Description,
                Status = flat.estateObject.Status,
                Date = flat.estateObject.Date,
                pathPhoto = flat.estateObject.pathPhoto,
                estateType = flat.estateObject.estateType,
               

            };
        }
     
        public async Task<FlatDTO> GetFlatByEstateObjectId(int id)
        {
            var flat = await Database.Flats.GetByEstateObjectId(id);
            if (flat == null)
                throw new ValidationException("Wrong flat!");
            return new FlatDTO
            {
                Id = flat.Id,
                Floor = flat.Floor,
                Floors = flat.Floors,
                Rooms = flat.Rooms,
                kitchenArea = flat.kitchenArea,
                livingArea = flat.livingArea,
                countViews = flat.estateObject.countViews,
                clientId = flat.estateObject.clientId,
                //clientPhone = estateObject.Client.Phone1,
                employeeId = flat.estateObject.employeeId,
                //employeeName = estateObject.Employee.Name,
                //employeePhone = estateObject.Employee.Phone1,
                operationId = flat.estateObject.operationId,
                //operationName = estateObject.Operation.Name,
                locationId = flat.estateObject.locationId,
                RegionId = (int)flat.estateObject.Location.RegionId, 
                LocalityId = (int)flat.estateObject.Location.LocalityId,
                DistrictId = (int)flat.estateObject.Location.DistrictId,
                Street = flat.estateObject.Street,
                numberStreet = flat.estateObject.numberStreet,
                Price = flat.estateObject.Price,
                currencyId = flat.estateObject.currencyId,
                //currencyName = estateObject.Currency.Name,
                Area = flat.estateObject.Area,
                unitAreaId = flat.estateObject.unitAreaId,
                //areaName = estateObject.unitArea.Name,
                Description = flat.estateObject.Description,
                Status = flat.estateObject.Status,
                Date = flat.estateObject.Date,
                pathPhoto = flat.estateObject.pathPhoto,
                estateType = flat.estateObject.estateType,
                estateObjectId = (int)flat.estateObjectId


            };
        }
        public async Task CreateFlat(FlatDTO flatDTO)
        {
            var flat = new Flat
            {
                Id = flatDTO.Id,
                Floor = flatDTO.Floor,
                Floors = flatDTO.Floors,
                Rooms = flatDTO.Rooms,
                kitchenArea = flatDTO.kitchenArea,
                livingArea = flatDTO.livingArea,
                estateObjectId = flatDTO.estateObjectId
            };
            await Database.Flats.Create(flat);
            await Database.Save();
        }

        public async Task UpdateFlat(FlatDTO flatDTO)
        {
            var flat = new Flat
            {
                Id = (int)flatDTO.Id,
                Floor = flatDTO.Floor,
                Floors = flatDTO.Floors,
                Rooms = flatDTO.Rooms,
                kitchenArea = flatDTO.kitchenArea,
                livingArea = flatDTO.livingArea,
                estateObjectId = flatDTO.estateObjectId
            };
            Database.Flats.Update(flat);
            await Database.Save();
        }

        public async Task DeleteFlat(int id)
        {
            await Database.Flats.Delete(id);
            await Database.Save();
        }

    }
}
