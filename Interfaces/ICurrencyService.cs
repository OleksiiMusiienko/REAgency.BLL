using REAgency.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDTO>> GetAll();
        Task<CurrencyDTO> Get(int id);
        Task<CurrencyDTO> GetByName(string name);
    }
}
