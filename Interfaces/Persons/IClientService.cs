using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Persons;
using REAgency.DAL.Entities.Person;

namespace REAgency.BLL.Interfaces.Persons
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();

        Task<ClientDTO> GetClientById(int id);

        Task<ClientDTO> GetClientByName(string name);
        Task<ClientDTO> GetClientByEmail(string email);
        Task<ClientDTO> GetByPhone(string phone);

        Task CreateClient(ClientDTO clientDTO);
        Task UpdateClient(ClientDTO clientDTO);
        Task UpdateClientPassword(ClientDTO clientDTO);

        Task UpdateClientNameAndPhone(int id, string name, string phone);
        Task DeleteClient(int id);
    }
}
