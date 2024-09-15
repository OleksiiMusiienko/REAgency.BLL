﻿using REAgency.BLL.DTO.Object;
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
    public class HouseService : IHouseSevice
    {
        IUnitOfWork Database { get; set; }

        public HouseService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<HouseDTO>> GetAllHouses()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Flat, FlatDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Flat>, IEnumerable<FlatDTO>>(await Database.Flats.GetAll());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<House, HouseDTO>()
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
            return mapper.Map<IEnumerable<House>, IEnumerable<HouseDTO>>(await Database.Houses.GetAll());




        }

        public async Task<HouseDTO> GetHouseById(int id)
        {
            var house = await Database.Houses.Get(id);
            if (house == null)
                throw new ValidationException("Wrong house!");
            return new HouseDTO
            {
                Id = house.Id,
                Floors = house.Floors,
                Rooms = house.Rooms,
                steadArea = house.steadArea,
                kitchenArea = house.kitchenArea,
                livingArea = house.livingArea


            };
        }


        public async Task CreateHouse(HouseDTO houseDTO)
        {
            var house = new House
            {
                Id = houseDTO.Id,
                Floors = houseDTO.Floors,
                Rooms = houseDTO.Rooms,
                steadArea = houseDTO.steadArea,
                kitchenArea = houseDTO.kitchenArea,
                livingArea = houseDTO.livingArea
            };
            await Database.Houses.Create(house);
            await Database.Save();
        }

        public async Task UpdateHouse(HouseDTO houseDTO)
        {
            var house = new House
            {
                 Id = houseDTO.Id,
                Floors = houseDTO.Floors,
                Rooms = houseDTO.Rooms,
                steadArea = houseDTO.steadArea,
                kitchenArea = houseDTO.kitchenArea,
                livingArea = houseDTO.livingArea
            };
            Database.Houses.Update(house);
            await Database.Save();
        }
        public async Task UpdateHouse(HouseDTO officeDTO)
        {

        }
        public async Task DeleteHouse(int id)
        {
            await Database.Houses.Delete(id);
            await Database.Save();
        }

        }
    }
}
