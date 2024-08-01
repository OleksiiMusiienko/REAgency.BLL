using REAgency.BLL.DTO.Locations;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Locations;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;
using AutoMapper;

namespace REAgency.BLL.Services.Locations
{
    internal class LocalityService : ILocalityService
    {
        IUnitOfWork Database { get; set; }
        public LocalityService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<LocalityDTO>> GetLocalities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Locality, LocalityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Locality>, IEnumerable<LocalityDTO>>(await Database.Localities.GetAll());
        }

        public async Task<LocalityDTO> GetLocalityById(int id)
        {
            var localitie = await Database.Localities.Get(id);
            if (localitie == null)
                throw new ValidationException("Wrong area!", "");
            return new LocalityDTO
            {
                Id = localitie.Id,
                Name = localitie.Name,
                DistrictId = localitie.DistrictId
            };

        }

        public async Task<LocalityDTO> GetLocalityByName(string name)
        {
            var localitie = await Database.Localities.GetByName(name);
            if (localitie == null)
                throw new ValidationException("Wrong area!", "");
            return new LocalityDTO
            {
                Id = localitie.Id,
                Name = localitie.Name,
                DistrictId = localitie.DistrictId
            };

        }

        public async Task CreateLocality(LocalityDTO localityDTO)
        {
            var localitie = new Locality
            {
                Id = localityDTO.Id,
                Name = localityDTO.Name,
                DistrictId = localityDTO.DistrictId
            };
            await Database.Localities.Create(localitie);
            await Database.Save();

        }
        public async Task UpdateLocality(LocalityDTO localityDTO)
        {
            var localitie = new Locality
            {
                Id = localityDTO.Id,
                Name = localityDTO.Name,
                DistrictId = localityDTO.DistrictId
            };
            Database.Localities.Update(localitie);
            await Database.Save();
        }
        public async Task DeleteLocality(int id)
        {
            await Database.Localities.Delete(id);
            await Database.Save();
        }
    }
}
