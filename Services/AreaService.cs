using AutoMapper;
using REAgency.BLL.DTO;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces;
using REAgency.DAL.Entities;
using REAgency.DAL.Interfaces;

namespace REAgency.BLL.Services
{
    public class AreaService: IAreaService
    {
        IUnitOfWork Database { get; set; }

        public AreaService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<AreaDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Area>, IEnumerable<AreaDTO>>(await Database.Areas.GetAll());
        }
        public async Task <AreaDTO> Get(int id)
        {
            var area = await Database.Areas.Get(id);
            if (area == null)
                throw new ValidationException("Wrong area!", "");
            return new AreaDTO
            {
                Id = area.Id,
                Name = area.Name
            };
        }
        public async Task<AreaDTO> GetByName(string name)
        {
            var area = await Database.Areas.GetByName(name);
            if (area == null)
                throw new ValidationException("Wrong area!", "");
            return new AreaDTO
            {
                Id = area.Id,
                Name = area.Name
            };
        }
    }
}
