using AutoMapper;
using REAgency.BLL.DTO;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services
{
    public class OperationService : IOperationService
    {
        IUnitOfWork Database { get; set; }

        public OperationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<OperationDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Operation, OperationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Operation>, IEnumerable<OperationDTO>>(await Database.Operations.GetAll());
        }
        public async Task<OperationDTO> Get(int id)
        {
            var oper = await Database.Operations.Get(id);
            if (oper == null)
                throw new ValidationException("Wrong operation!", "");
            return new OperationDTO
            {
                Id = oper.Id,
                Name = oper.Name
            };
        }
        public async Task<OperationDTO> GetByName(string name)
        {
            var oper = await Database.Operations.GetByName(name);
            if (oper == null)
                throw new ValidationException("Wrong operation!", "");
            return new OperationDTO
            {
                Id = oper.Id,
                Name = oper.Name
            };
        }
    }
}
