using AutoMapper;
using REAgency.BLL.DTO.Locations;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Locations;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services.Locations
{
    public class LocationService: ILocationService
    {
        IUnitOfWork Database { get; set; }
        public LocationService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<LocationDTO>> GetLocations()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Location>, IEnumerable<LocationDTO>>(await Database.Locations.GetAll());
        }
        public async Task<LocationDTO> GetLocationsById(int id)
        {
            var location = await Database.Locations.Get(id);
            if (location == null)
                throw new ValidationException("Wrong location!", "");
            return new LocationDTO
            {
                Id = location.Id,
                CountryId = location.CountryId,
                RegionId = location.RegionId,
                LocalityId = (int)location.LocalityId
            };

        }
        public async Task CreateLocation(LocationDTO locationDTO)
        {
            var location = new Location
            {
                Id = locationDTO.Id,
                CountryId = locationDTO.CountryId,
                RegionId = locationDTO.RegionId,
                LocalityId = locationDTO.LocalityId,
                Date = locationDTO.Date
            };
            await Database.Locations.Create(location);
            await Database.Save();
        }
        public async Task UpdateLocation(LocationDTO locationDTO)
        {
            var location = new Location
            {
                Id = locationDTO.Id,
                RegionId = locationDTO.RegionId,
                DistrictId = locationDTO.DistrictId,
                LocalityId = locationDTO.LocalityId
            };
            Database.Locations.Update(location);
            await Database.Save();
        }
        public async Task DeleteLocation(int id)
        {
            await Database.Locations.Delete(id);
            await Database.Save();
        }
        public async Task<LocationDTO> GetByDateTime(DateTime date)
        {
            var locations = await Database.Locations.GetByDateTime(date);
            if (locations == null)
                throw new ValidationException("Wrong location!", "");
            return new LocationDTO
            {
                Id = locations.Id,
                CountryId = locations.CountryId,
                RegionId = locations.RegionId,
                LocalityId = locations.LocalityId,
                Date =locations.Date
            };
        }
    }
}
