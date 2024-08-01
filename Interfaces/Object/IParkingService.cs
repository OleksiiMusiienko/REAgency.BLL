using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Object;

namespace REAgency.BLL.Interfaces.Object
{
    public interface IParkingService
    {
        Task<IEnumerable<ParkingDTO>> GetParkings();

        Task<ParkingDTO> GetParkingById(int id);

        Task<ParkingDTO> GetParkingByEmployee(int employeeId);

        Task CreateParking(ParkingDTO parkingDTO);
        Task UpdateParking(ParkingDTO parkingDTO);
        Task DeleteParking(int id);
    }
}
