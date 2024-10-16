using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IStorageService
    {
        Task<IEnumerable<StorageDTO>> GetStorages();
        Task<StorageDTO> GetStorageById(int id);
        Task<StorageDTO> GetStorageByEstateObjectId(int id);
        Task CreateStorage(StorageDTO storageDTO);
        Task UpdateStorage(StorageDTO storageDTO);
        Task DeleteStorage(int id);
    }
}
