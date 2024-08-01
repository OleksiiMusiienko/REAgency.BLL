using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO;

namespace REAgency.BLL.Interfaces
{
    public interface IEstateTypeService
    {
        Task<IEnumerable<EstateTypeDTO>> GetAll();
        Task<EstateTypeDTO> Get(int id);
        Task<EstateTypeDTO> GetByName(string name);
    }
}
