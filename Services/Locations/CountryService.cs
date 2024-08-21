using REAgency.BLL.DTO.Locations;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Locations;
using REAgency.DAL.Entities.Locations;
using REAgency.DAL.Interfaces;
using AutoMapper;

namespace REAgency.BLL.Services.Locations
{
    public class CountryService : ICountryService
    {
        IUnitOfWork Database { get; set; }
        public CountryService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(await Database.Countries.GetAll());
        }

        public async Task<CountryDTO> GetCountryById(int id)
        {
            var country = await Database.Countries.Get(id);
            if (country == null)
                throw new ValidationException("Wrong country!", "");
            return new CountryDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }

        public async Task<CountryDTO> GetCountryByName(string name)
        {
            var country = await Database.Countries.GetByName(name);
            if (country == null)
                throw new ValidationException("Wrong country!", "");
            return new CountryDTO
            {
                Id = country.Id,
                Name = country.Name
            };
        }

        public async Task CreateCountry(CountryDTO countryDTO)
        {
            var country = new Country
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name
            };
            await Database.Countries.Create(country);
            await Database.Save();
        }
        public async Task UpdateCountry(CountryDTO countryDTO)
        {
            var country = new Country
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name
            };
            Database.Countries.Update(country);
            await Database.Save();

        }
        public async Task DeleteCountry(int id)
        {
            await Database.Countries.Delete(id);
            await Database.Save();
        }
    }
}
