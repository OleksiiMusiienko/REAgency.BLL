using AutoMapper;
using REAgency.BLL.DTO;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services
{
    public class CurrencyService: ICurrencyService
    {
        IUnitOfWork Database { get; set; }

        public CurrencyService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<CurrencyDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Currency, CurrencyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyDTO>>(await Database.Currencies.GetAll());
        }
        public async Task<CurrencyDTO> Get(int id)
        {
            var cur = await Database.Currencies.Get(id);
            if (cur == null)
                throw new ValidationException("Wrong currency!", "");
            return new CurrencyDTO
            {
                Id = cur.Id,
                Name = cur.Name
            };
        }
        public async Task<CurrencyDTO> GetByName(string name)
        {
            var cur = await Database.Currencies.GetByName(name);
            if (cur == null)
                throw new ValidationException("Wrong currency!", "");
            return new CurrencyDTO
            {
                Id = cur.Id,
                Name = cur.Name
            };
        }
    }
}
