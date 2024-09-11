using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.Services.Objects
{
    public class OfficeService: IOfficeService
    {
        IUnitOfWork Database { get; set; }

        public OfficeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<OfficeDTO>> GetOffices()
        {
            List<OfficeDTO> offices = new List<OfficeDTO>();
            return offices;
        }

        public async Task<OfficeDTO> GetOfficeById(int id)
        {
            OfficeDTO office = new OfficeDTO();
            return office;
        }
        public async Task CreateOffice(OfficeDTO officeDTO)
        {

        }
        public async Task UpdateOffice(OfficeDTO officeDTO)
        {

        }
        public async Task DeleteOffice(int id)
        {

        }
    }
}
