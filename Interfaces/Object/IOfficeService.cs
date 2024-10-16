﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IOfficeService
    {
        Task<IEnumerable<OfficeDTO>> GetOffices();
        Task<OfficeDTO> GetOfficeById(int id);
        Task<OfficeDTO> GetOfficeByEstateObjectId(int estateObjectId);
        Task CreateOffice(OfficeDTO officeDTO);
        Task Update(OfficeDTO officeDTO);
        Task DeleteOffice(int id);
    }
}
