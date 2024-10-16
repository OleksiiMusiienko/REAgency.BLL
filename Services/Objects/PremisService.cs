using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.Services.Objects
{
    public class PremisService: IPremisService
    {
        IUnitOfWork Database { get; set; }

        public PremisService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<PremisDTO>> GetPremises()
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
            return mapper.Map<IEnumerable<Premis>, IEnumerable<PremisDTO>>(await Database.Premises.GetAll());
        }
        public async Task<PremisDTO> GetPremisById(int id)
        {
            var prem = await Database.Premises.Get(id);
            if (prem == null)
                throw new ValidationException("Wrong office!");
            return new PremisDTO
            {
                Id = prem.Id,
                estateObjectId = (int)prem.estateObjectId
            };
        }
        public async Task<PremisDTO> GetPremisByEstateObjectId(int id)
        {
            var prem = await Database.Premises.GetByEstateObjectId(id);
            if (prem == null)
                throw new ValidationException("Wrong office!");
            return new PremisDTO
            {
                Id = prem.Id,
                estateObjectId = prem.estateObjectId,
                countViews = prem.estateObject.countViews,
                clientId = prem.estateObject.clientId,
                clientPhone = prem.estateObject.Client.Phone1,
                clientName = prem.estateObject.Client.Name,
                employeeId = prem.estateObject.employeeId,
                operationId = prem.estateObject.operationId,
                locationId = prem.estateObject.locationId,
                RegionId = (int)prem.estateObject.Location.RegionId,
                LocalityId = (int)prem.estateObject.Location.LocalityId,
                DistrictId = (int)prem.estateObject.Location.DistrictId,
                Street = prem.estateObject.Street,
                numberStreet = prem.estateObject.numberStreet,
                Price = prem.estateObject.Price,
                currencyId = prem.estateObject.currencyId,
                Area = prem.estateObject.Area,
                unitAreaId = prem.estateObject.unitAreaId,
                Description = prem.estateObject.Description,
                Status = prem.estateObject.Status,
                Date = prem.estateObject.Date,
                pathPhoto = prem.estateObject.pathPhoto,
                estateType = prem.estateObject.estateType,
            };
        }
        public async Task Create(PremisDTO officeDTO)
        {
            var prem = new Premis
            {
                Id = officeDTO.Id,
                estateObjectId = officeDTO.estateObjectId,
            };
            await Database.Premises.Create(prem);
            await Database.Save();
        }
        public async Task Update(PremisDTO officeDTO)
        {
            var prem = new Premis
            {
                Id = officeDTO.Id,
                estateObjectId = officeDTO.estateObjectId
            };
            Database.Premises.Update(prem);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.Offices.Delete(id);
            await Database.Save();
        }

    }
}

