using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using REAgency.BLL.DTO;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.DTO.Persons;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Flat, FlatDTO>()).CreateMapper();
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
                livingArea = flat.livingArea


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
                livingArea = flatDTO.livingArea
            };
            await Database.Flats.Create(flat);
            await Database.Save();
        }

        public async Task UpdateFlat(FlatDTO flatDTO)
        {
            var flat = new Flat
            {
                Id = flatDTO.Id,
                Floor = flatDTO.Floor,
                Floors = flatDTO.Floors,
                Rooms = flatDTO.Rooms,
                kitchenArea = flatDTO.kitchenArea,
                livingArea = flatDTO.livingArea
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
