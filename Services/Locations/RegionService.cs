using REAgency.BLL.DTO.Locations;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Locations;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;
using AutoMapper;

namespace REAgency.BLL.Services.Locations
{
    internal class RegionService : IRegionService
    {
        IUnitOfWork Database { get; set; }
        public RegionService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<RegionDTO>> GetRegions()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Region, RegionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(await Database.Regions.GetAll());
        }

        public async Task<RegionDTO> GetRegionById(int id)
        {
            var region = await Database.Regions.Get(id);
            if (region == null)
                throw new ValidationException("Wrong area!", "");
            return new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                CountryId = region.CountryId
            };

        }

        public async Task<RegionDTO> GetRegionByName(string name)
        {
            var region = await Database.Regions.GetByName(name);
            if (region == null)
                throw new ValidationException("Wrong area!", "");
            return new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                CountryId = region.CountryId
            };

        }

        public async Task CreateRegion(RegionDTO regionDTO)
        {
            var region = new Region
            {
                Id = regionDTO.Id,
                Name = regionDTO.Name,
                CountryId = regionDTO.CountryId
            };
            await Database.Regions.Create(region);
            await Database.Save();

        }
        public async Task UpdateRegion(RegionDTO regionDTO)
        {
            var region = new Region
            {
                Id = regionDTO.Id,
                Name = regionDTO.Name,
                CountryId = regionDTO.CountryId
            };
            Database.Regions.Update(region);
            await Database.Save();
        }
        public async Task DeleteRegion(int id)
        {
            await Database.Regions.Delete(id);
            await Database.Save();
        }
    }
}
