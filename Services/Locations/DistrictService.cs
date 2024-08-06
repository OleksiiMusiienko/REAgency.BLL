using REAgency.BLL.DTO.Locations;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Locations;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;
using AutoMapper;

namespace REAgency.BLL.Services.Locations
{
    internal class DistrictService : IDistrictService
    {
        IUnitOfWork Database { get; set; }
        public DistrictService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<DistrictDTO>> GetDistrict()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<District, DistrictDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<District>, IEnumerable<DistrictDTO>>(await Database.Districts.GetAll());
        }

        public async Task<DistrictDTO> GetDistrictById(int id)
        {
            var district = await Database.Districts.Get(id);
            if (district == null)
                throw new ValidationException("Wrong district!", "");
            return new DistrictDTO
            {
                Id = district.Id,
                Name = district.Name,
                RegionId = district.RegionId
            };

        }

        public async Task<DistrictDTO> GetDistrictByName(string name)
        {
            var district = await Database.Districts.GetByName(name);
            if (district == null)
                throw new ValidationException("Wrong district!", "");
            return new DistrictDTO
            {
                Id = district.Id,
                Name = district.Name,
                RegionId = district.RegionId
            };

        }

        public async Task CreateDistrict(DistrictDTO districtDTO)
        {
            var district = new District
            {
                Id = districtDTO.Id,
                Name = districtDTO.Name,
                RegionId = districtDTO.RegionId
            };
            await Database.Districts.Create(district);
            await Database.Save();

        }
        public async Task UpdateDistrict(DistrictDTO districtDTO)
        {
            var district = new District
            {
                Id = districtDTO.Id,
                Name = districtDTO.Name,
                RegionId = districtDTO.RegionId
            };
            Database.Districts.Update(district);
            await Database.Save();
        }
        public async Task DeleteDistrict(int id)
        {
            await Database.Districts.Delete(id);
            await Database.Save();
        }
    }
}
