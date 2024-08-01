using REAgency.BLL.DTO.Locations;

namespace REAgency.BLL.Interfaces.Locations
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetCountries();

        Task<CountryDTO> GetCountryById(int id);

        Task<CountryDTO> GetCountryByName(string name);

        Task CreateCountry(CountryDTO countryDTO);
        Task UpdateCountry(CountryDTO countryDTO);
        Task DeleteCountry(int id);
    }
}
