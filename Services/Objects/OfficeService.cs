using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.Services.Objects
{
    public class OfficeService : IOfficeService
    {
        IUnitOfWork Database { get; set; }

        public OfficeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<OfficeDTO>> GetOffices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Office, OfficeDTO>()
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
            return mapper.Map<IEnumerable<Office>, IEnumerable<OfficeDTO>>(await Database.Offices.GetAll());
        }
        public async Task<OfficeDTO> GetOfficeById(int id)
        {
            var office = await Database.Offices.Get(id);
            if (office == null)
                throw new ValidationException("Wrong office!");
            return new OfficeDTO
            {
                Id = office.Id,
                estateObjectId = office.estateObjectId
             
            };
        }
        public async Task<OfficeDTO> GetOfficeByEstateObjectId(int id)
        {
            var office = await Database.Offices.GetByEstateObjectId(id);
            if (office == null)
                throw new ValidationException("Wrong office!");
            return new OfficeDTO
            {
                Id = office.Id,
                estateObjectId = office.estateObjectId,
                countViews = office.estateObject.countViews,
                clientId = office.estateObject.clientId,
                clientPhone = office.estateObject.Client.Phone1,
                clientName = office.estateObject.Client.Name,
                employeeId = office.estateObject.employeeId,
                operationId = office.estateObject.operationId,
                locationId = office.estateObject.locationId,
                RegionId = (int)office.estateObject.Location.RegionId,
                LocalityId = (int)office.estateObject.Location.LocalityId,
                DistrictId = (int)office.estateObject.Location.DistrictId,
                Street = office.estateObject.Street,
                numberStreet = office.estateObject.numberStreet,
                Price = office.estateObject.Price,
                currencyId = office.estateObject.currencyId,
                Area = office.estateObject.Area,
                unitAreaId = office.estateObject.unitAreaId,
                Description = office.estateObject.Description,
                Status = office.estateObject.Status,
                Date = office.estateObject.Date,
                pathPhoto = office.estateObject.pathPhoto,
                estateType = office.estateObject.estateType,

            };
        }
        public async Task CreateOffice(OfficeDTO officeDTO)
        {
            var office = new Office
            {
                Id = officeDTO.Id,
                estateObjectId =officeDTO.estateObjectId,
            };
            await Database.Offices.Create(office);
            await Database.Save();
        }
        public async Task Update(OfficeDTO officeDTO)
        {
            var office = new Office
            {
                Id = officeDTO.Id,
               estateObjectId = officeDTO.estateObjectId
            };
            Database.Offices.Update(office);
            await Database.Save();
        }
        public async Task DeleteOffice(int id)
        {
            await Database.Offices.Delete(id);
            await Database.Save();
        }
        
    }
}
