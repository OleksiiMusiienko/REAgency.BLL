using AutoMapper;
using REAgency.BLL.DTO.Persons;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Persons;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;


namespace REAgency.BLL.Services.Persons
{
    internal class ClientService: IClientService
    {
        IUnitOfWork Database { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()
            .ForMember("OperationName", opt => opt.MapFrom(c => c.Operation.Name))
            .ForMember("EmployeeName", opt => opt.MapFrom(c => c.Employee.Name))
            .ForMember("EmployeePhone1", opt => opt.MapFrom(c => c.Employee.Phone1))
            .ForMember("EmployeePhone2", opt => opt.MapFrom(c => c.Employee.Phone2)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(await Database.Clients.GetAll());
        }

        public async Task<ClientDTO> GetClientById(int id)
        {
            var client = await Database.Clients.Get(id);
            if (client == null)
                throw new ValidationException("Wrong client!", "");
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Phone1 = client.Phone1,
                Email = client.Email,
                userStatus = client.userStatus,
                operationId = client.operationId,
                OperationName = client.Operation?.Name,
                employeeId = client.employeeId,
                EmployeeName = client.Employee?.Name,
                EmployeePhone1 = client.Employee?.Phone1,
                EmployeePhone2 = client.Employee?.Phone2,
                status = client.status,
                Password = client.Password,
                Salt = client.Salt,
            };
        }

        public async Task<ClientDTO> GetClientByName(string name)
        {
            var client = await Database.Clients.GetByName(name);
            if (client == null)
                throw new ValidationException("Wrong client!", "");
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Phone1 = client.Phone1,
                Email = client.Email,
                userStatus = client.userStatus,
                operationId = client.operationId,
                OperationName = client.Operation?.Name,
                employeeId = client.employeeId,
                EmployeeName = client.Employee?.Name,
                EmployeePhone1 = client.Employee?.Phone1,
                EmployeePhone2 = client.Employee?.Phone2,
                status = client.status,
                Password = client.Password,
                Salt = client.Salt,
            };
        }

        public async Task CreateClient(ClientDTO clientDTO)
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            string salt = sb.ToString();
            byte[] password = Encoding.Unicode.GetBytes(salt + clientDTO.Password);
            byte[] byteHash = SHA256.HashData(password);
            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                Phone1 = clientDTO.Phone1,
                Email = clientDTO.Email,
                userStatus = clientDTO.userStatus,
                operationId = clientDTO.operationId,
                employeeId = clientDTO.employeeId,
                status = clientDTO.status,
                Password = hash.ToString(),
                Salt = salt
            };
            await Database.Clients.Create(client);
            await Database.Save();
        }
        public async Task UpdateClient(ClientDTO clientDTO)
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            string salt = sb.ToString();
            byte[] password = Encoding.Unicode.GetBytes(salt + clientDTO.Password);
            byte[] byteHash = SHA256.HashData(password);
            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            var client = new Client
            {
                Id = clientDTO.Id,
                Name = clientDTO.Name,
                Phone1 = clientDTO.Phone1,
                Email = clientDTO.Email,
                userStatus = clientDTO.userStatus,
                operationId = clientDTO.operationId,
                employeeId = clientDTO.employeeId,
                status = clientDTO.status,
                Password = hash.ToString(),
                Salt = salt
            };
            Database.Clients.Update(client);
            await Database.Save();
        }
        public async Task DeleteClient(int id)
        {
            await Database.Clients.Delete(id);
            await Database.Save();
        }
    }
}
