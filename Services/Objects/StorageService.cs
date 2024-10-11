using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.Services.Objects
{
    public class StorageService: IStorageService
    {
        IUnitOfWork Database { get; set; }

        public StorageService(IUnitOfWork uow) 
        {
            Database = uow;
        }
        public async Task<IEnumerable<StorageDTO>> GetStorages()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Storage, StorageDTO>()
                .ForMember("Price", opt => opt.MapFrom(c => c.estateObject.Price))
                .ForMember("countViews", opt => opt.MapFrom(c => c.estateObject.countViews))
                .ForMember("clientId", opt => opt.MapFrom(c => c.estateObject.clientId))
                .ForMember("employeeId", opt => opt.MapFrom(c => c.estateObject.employeeId))
                .ForMember("operationId", opt => opt.MapFrom(c => c.estateObject.operationId))
                .ForMember("locationId", opt => opt.MapFrom(c => c.estateObject.locationId))
                .ForMember("Street", opt => opt.MapFrom(c => c.estateObject.Street))
                .ForMember("numberStreet", opt => opt.MapFrom(c => c.estateObject.numberStreet))
                .ForMember("currencyId", opt => opt.MapFrom(c => c.estateObject.currencyId))
                .ForMember("Area", opt => opt.MapFrom(c => c.estateObject.Area))
                .ForMember("unitAreaId", opt => opt.MapFrom(c => c.estateObject.unitAreaId))
                .ForMember("Description", opt => opt.MapFrom(c => c.estateObject.Description))
                .ForMember("Status", opt => opt.MapFrom(c => c.estateObject.Status))
                .ForMember("Date", opt => opt.MapFrom(c => c.estateObject.Date))
                .ForMember("pathPhoto", opt => opt.MapFrom(c => c.estateObject.pathPhoto))

                );
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Storage>, IEnumerable<StorageDTO>>(await Database.Storeges.GetAll());
        }
        public async Task<StorageDTO> GetStorageById(int id)
        {
            var storage = await Database.Storeges.Get(id);
            if (storage == null)
                throw new ValidationException("Wrong office!");
            return new StorageDTO
            {
                Id = storage.Id,
                estateObjectId = storage.estateObjectId
            };
        }
        public async Task CreateStorage(StorageDTO storageDTO)
        {
            var stor = new Storage
            {
                Id = storageDTO.Id,
                estateObjectId = storageDTO.estateObjectId
            };
            await Database.Storeges.Create(stor);
            await Database.Save();
        }
        public async Task UpdateStorage(StorageDTO storageDTO)
        {
            var stor = new Storage
            {
                Id = storageDTO.Id,
                estateObjectId = storageDTO.estateObjectId
            };
            Database.Storeges.Update(stor);
            await Database.Save();
        }
        public async Task DeleteStorage(int id)
        {
            await Database.Storeges.Delete(id);
            await Database.Save();
        }
    }
}
