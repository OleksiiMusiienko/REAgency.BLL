using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.Services.Objects
{
    public class ParkingService: IParkingService
    {
        IUnitOfWork Database { get; set; }

        public ParkingService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<ParkingDTO>> GetParkings()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Parking, ParkingDTO>()
              .ForMember("countViews", opt => opt.MapFrom(c => c.estateObject.countViews))
              .ForMember("clientId", opt => opt.MapFrom(c => c.estateObject.clientId))
              .ForMember("employeeId", opt => opt.MapFrom(c => c.estateObject.employeeId))
              .ForMember("operationId", opt => opt.MapFrom(c => c.estateObject.operationId))
              .ForMember("locationId", opt => opt.MapFrom(c => c.estateObject.locationId))
              .ForMember("Street", opt => opt.MapFrom(c => c.estateObject.Street))
              .ForMember("numberStreet", opt => opt.MapFrom(c => c.estateObject.numberStreet))
              .ForMember("Price", opt => opt.MapFrom(c => c.estateObject.Price))
              .ForMember("currencyId", opt => opt.MapFrom(c => c.estateObject.currencyId))
              .ForMember("Area", opt => opt.MapFrom(c => c.estateObject.Area))
              .ForMember("unitAreaId", opt => opt.MapFrom(c => c.estateObject.unitAreaId))
              .ForMember("Description", opt => opt.MapFrom(c => c.estateObject.Description))
              .ForMember("Status", opt => opt.MapFrom(c => c.estateObject.Status))
              .ForMember("Date", opt => opt.MapFrom(c => c.estateObject.Date))
              .ForMember("pathPhoto", opt => opt.MapFrom(c => c.estateObject.pathPhoto))
              .ForMember("estateType", opt => opt.MapFrom(c => c.estateObject.estateType))
              );
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Parking>, IEnumerable<ParkingDTO>>(await Database.Parkings.GetAll());
        }
        public async Task<ParkingDTO> GetParkingById(int id)
        {
            var office = await Database.Offices.Get(id);
            if (office == null)
                throw new ValidationException("Wrong office!");
            return new ParkingDTO
            {
                Id = office.Id,
                estateObjectId = office.estateObjectId

            };
        }
        public async Task<ParkingDTO> GetParkingByEstateObjectId(int id)
        {
            var parking = await Database.Parkings.GetByEstateObjectId(id);
            if (parking == null)
                throw new ValidationException("Wrong office!");
            return new ParkingDTO
            {
                Id = parking.Id,
                estateObjectId = (int)parking.estateObjectId,
                countViews = parking.estateObject.countViews,
                clientId = parking.estateObject.clientId,
                clientPhone = parking.estateObject.Client.Phone1,
                clientName = parking.estateObject.Client.Name,
                employeeId = parking.estateObject.employeeId,
                operationId = parking.estateObject.operationId,
                locationId = parking.estateObject.locationId,
                RegionId = (int)parking.estateObject.Location.RegionId,
                LocalityId = (int)parking.estateObject.Location.LocalityId,
                DistrictId = (int)parking.estateObject.Location.DistrictId,
                Street = parking.estateObject.Street,
                numberStreet = parking.estateObject.numberStreet,
                Price = parking.estateObject.Price,
                currencyId = parking.estateObject.currencyId,
                Area = parking.estateObject.Area,
                unitAreaId = parking.estateObject.unitAreaId,
                Description = parking.estateObject.Description,
                Status = parking.estateObject.Status,
                Date = parking.estateObject.Date,
                pathPhoto = parking.estateObject.pathPhoto,
                estateType = parking.estateObject.estateType,

            };
        }
        public async Task CreateParking(ParkingDTO parkingDTO)
        {
            var parking = new Parking
            {
                Id = parkingDTO.Id,
                estateObjectId = parkingDTO.estateObjectId,
            };
            await Database.Parkings.Create(parking);
            await Database.Save();
        }
        public async Task UpdateParking(ParkingDTO parkingDTO)
        {
            var parking = new Parking
            {
                Id = parkingDTO.Id,
                estateObjectId = parkingDTO.estateObjectId,
            };
            Database.Parkings.Update(parking);
            await Database.Save();
        }
        public async Task DeleteParking(int id)
        {
            await Database.Parkings.Delete(id);
            await Database.Save();
        }
    }
}
