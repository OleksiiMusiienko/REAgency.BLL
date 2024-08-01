using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();

        Task<RoomDTO> GetRoomById(int id);

        Task<RoomDTO> GetRoomsByEmployeeId(int employeeId);

        Task CreateRoom(RoomDTO officeDTO);
        Task UpdateRoom(RoomDTO officeDTO);
        Task DeleteRoom(int id);
    }
}
