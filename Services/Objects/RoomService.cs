using AutoMapper;
using REAgency.BLL.DTO.Object;
using REAgency.BLL.Interfaces.Object;
using REAgency.DAL.Entities.Object;
using REAgency.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace REAgency.BLL.Services.Objects
{
    public class RoomService: IRoomService
    {
        IUnitOfWork Database { get; set; }

        public RoomService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Flat, FlatDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Flat>, IEnumerable<FlatDTO>>(await Database.Flats.GetAll());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Room, RoomDTO>()
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
            return mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(await Database.Rooms.GetAll());
        }
        public async Task<RoomDTO> GetRoomById(int id)
        {
            var room = await Database.Rooms.Get(id);
            if (room == null)
                throw new ValidationException("Wrong flat!");
            return new RoomDTO
            {
                Id = room.Id,
                Floor = room.Floor,
                Floors = room.Floors,
                livingArea = room.livingArea,
                countViews = room.estateObject.countViews,
                //clientName = estateObject.Client.Name,
                //clientPhone = estateObject.Client.Phone1,
                employeeId = room.estateObject.employeeId,
                //employeeName = estateObject.Employee.Name,
                //employeePhone = estateObject.Employee.Phone1,
                operationId = room.estateObject.operationId,
                //operationName = estateObject.Operation.Name,
                locationId = room.estateObject.locationId,
                Street = room.estateObject.Street,
                numberStreet = room.estateObject.numberStreet,
                Price = room.estateObject.Price,
                currencyId = room.estateObject.currencyId,
                //currencyName = estateObject.Currency.Name,
                Area = room.estateObject.Area,
                unitAreaId = room.estateObject.unitAreaId,
                //areaName = estateObject.unitArea.Name,
                Description = room.estateObject.Description,
                Status = room.estateObject.Status,
                Date = room.estateObject.Date,
                pathPhoto = room.estateObject.pathPhoto,
                estateType = room.estateObject.estateType,
            };
        }
        public async Task<RoomDTO> GetRoomByEstateObjectId(int id)
        {
            var room = await Database.Rooms.GetByEstateObjectId(id);
            if (room == null)
                throw new ValidationException("Wrong room!");
            return new RoomDTO
            {
                Id = room.Id,
                Floor = room.Floor,
                Floors = room.Floors,
                livingArea = room.livingArea,
                countViews = room.estateObject.countViews,
                clientId = room.estateObject.clientId,
                clientPhone = room.estateObject.Client.Phone1,
                clientName = room.estateObject.Client.Name,
                employeeId = room.estateObject.employeeId,
                operationId = room.estateObject.operationId,
                locationId = room.estateObject.locationId,
                RegionId = (int)room.estateObject.Location.RegionId,
                LocalityId = (int)room.estateObject.Location.LocalityId,
                DistrictId = (int)room.estateObject.Location.DistrictId,
                Street = room.estateObject.Street,
                numberStreet = room.estateObject.numberStreet,
                Price = room.estateObject.Price,
                currencyId = room.estateObject.currencyId,
                Area = room.estateObject.Area,
                unitAreaId = room.estateObject.unitAreaId,
                Description = room.estateObject.Description,
                Status = room.estateObject.Status,
                Date = room.estateObject.Date,
                pathPhoto = room.estateObject.pathPhoto,
                estateType = room.estateObject.estateType,
                estateObjectId = (int)room.estateObjectId
            };

        }
        public async Task CreateRoom(RoomDTO roomDTO)
        {
            var room = new Room
            {
                Id = roomDTO.Id,
                Floor = roomDTO.Floor,
                Floors = roomDTO.Floors,
                livingArea = roomDTO.livingArea,
                estateObjectId = roomDTO.estateObjectId
            };
            await Database.Rooms.Create(room);
            await Database.Save();
        }
        public async Task UpdateRoom(RoomDTO roomDTO)
        {
            var room = new Room
            {
                Id = (int)roomDTO.Id,
                Floor = roomDTO.Floor,
                Floors = roomDTO.Floors,
                livingArea = roomDTO.livingArea,
                estateObjectId = roomDTO.estateObjectId
            };
            Database.Rooms.Update(room);
            await Database.Save();
        }
        public async Task DeleteRoom(int id)
        {
            await Database.Rooms.Delete(id);
            await Database.Save();
        }
    }
}
