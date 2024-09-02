//using AutoMapper;
//using REAgency.BLL.DTO;
//using REAgency.BLL.Infrastructure;
//using REAgency.BLL.Interfaces;
//using REAgency.DAL.Entities;
//using REAgency.DAL.Interfaces;

//namespace REAgency.BLL.Services
//{
//    public class EstateTypeService : IEstateTypeService
//    {
//        IUnitOfWork Database { get; set; }

//        public EstateTypeService(IUnitOfWork uow)
//        {
//            Database = uow;
//        }

//        public async Task<IEnumerable<EstateTypeDTO>> GetAll()
//        {
//            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EstateType, EstateTypeDTO>()).CreateMapper();
//            return mapper.Map<IEnumerable<EstateType>, IEnumerable<EstateTypeDTO>>(await Database.EstateTypes.GetAll());
//        }
//        public async Task<EstateTypeDTO> Get(int id)
//        {
//            var eType = await Database.EstateTypes.Get(id);
//            if (eType == null)
//                throw new ValidationException("Wrong estate type!", "");
//            return new EstateTypeDTO
//            {
//                Id = eType.Id,
//                Name = eType.Name
//            };
//        }
//        public async Task<EstateTypeDTO> GetByName(string name)
//        {
//            var eType = await Database.EstateTypes.GetByName(name);
//            if (eType == null)
//                throw new ValidationException("Wrong estate type!", "");
//            return new EstateTypeDTO
//            {
//                Id = eType.Id,
//                Name = eType.Name
//            };
//        }
//    }
//}
