using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Persons;

namespace REAgency.BLL.Interfaces.Persons
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClients();

        Task<ClientDTO> GetClientById(int id);

        Task<ClientDTO> GetClientByName(string name);

        Task CreateClient(ClientDTO clientDTO);
        Task UpdateClient(ClientDTO clientDTO);
        Task DeleteClient(int id);
    }
}
