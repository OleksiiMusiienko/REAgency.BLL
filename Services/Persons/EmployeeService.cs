using AutoMapper;
using REAgency.BLL.DTO.Persons;
using REAgency.BLL.Interfaces.Persons;
using REAgency.DAL.Entities.Person;
using REAgency.DAL.Interfaces;
using REAgency.BLL.Infrastructure;
using System.Security.Cryptography;
using System.Text;

namespace REAgency.BLL.Services.Persons
{
    public class EmployeeService: IEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()
           .ForMember("Post", opt => opt.MapFrom(c => c.Post.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(await Database.Employees.GetAll());
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await Database.Employees.Get(id);
            if(employee == null)
                throw new ValidationException("Wrong employee!", "");
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Phone1 = employee.Phone1,
                Email = employee.Email,
                userStatus = employee.userStatus,
                Avatar = employee.Avatar,
                Phone2 = employee.Phone2,
                dateReg = employee.dateReg,
                adminStatus = employee.adminStatus,
                postId = employee.postId,
                Post = employee.Post?.Name,
                Password = employee.Password,
                Salt = employee.Salt,
                Description = employee.Description
            };
        }

        public async Task<EmployeeDTO> GetEmployeeByName(string name)
        {
            var employee = await Database.Employees.GetByName(name);
            if (employee == null)
                throw new ValidationException("Wrong employee!", "");
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Phone1 = employee.Phone1,
                Email = employee.Email,
                userStatus = employee.userStatus,
                Avatar = employee.Avatar,
                Phone2 = employee.Phone2,
                dateReg = employee.dateReg,
                adminStatus = employee.adminStatus,
                postId = employee.postId,
                Post = employee.Post?.Name,
                Password = employee.Password,
                Salt = employee.Salt,
                Description = employee.Description
            };
        }

        public async Task<EmployeeDTO> GetEmployeeByEmail(string email)
        {
            var employee = await Database.Employees.GetByEmail(email);
            if (employee == null)
            {
                //EmployeeDTO Employee = new EmployeeDTO();
                return null;
            }
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Phone1 = employee.Phone1,
                Email = employee.Email,
                userStatus = employee.userStatus,
                Avatar = employee.Avatar,
                Phone2 = employee.Phone2,
                dateReg = employee.dateReg,
                adminStatus = employee.adminStatus,
                postId = employee.postId,
                Post = employee.Post?.Name,
                Password = employee.Password,
                Salt = employee.Salt,
                Description = employee.Description
            };
        }

        public async Task CreateEmployee(EmployeeDTO еmployeeDTO)
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            string salt = sb.ToString();
            byte[] password = Encoding.Unicode.GetBytes(salt + еmployeeDTO.Password);
            byte[] byteHash = SHA256.HashData(password);
            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            var еmployee = new Employee
            {
                Id = еmployeeDTO.Id,
                Name = еmployeeDTO.Name,
                Phone1 = еmployeeDTO.Phone1,
                Email = еmployeeDTO.Email,
                userStatus = еmployeeDTO.userStatus,
                Avatar = еmployeeDTO.Avatar,
                Phone2 = еmployeeDTO.Phone2,
                dateReg = еmployeeDTO.dateReg,                   //??????????? заполнение даты регистрации 
                adminStatus = еmployeeDTO.adminStatus,
                postId = еmployeeDTO.postId,
                Description = еmployeeDTO.Description,
                Password = hash.ToString(),
                Salt = salt
            };
            await Database.Employees.Create(еmployee);
            await Database.Save();
        }
        public async Task UpdateEmployee(EmployeeDTO еmployeeDTO)
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            string salt = sb.ToString();
            byte[] password = Encoding.Unicode.GetBytes(salt + еmployeeDTO.Password);
            byte[] byteHash = SHA256.HashData(password);
            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            var еmployee = new Employee
            {
                Id = еmployeeDTO.Id,
                Name = еmployeeDTO.Name,
                Phone1 = еmployeeDTO.Phone1,
                Email = еmployeeDTO.Email,
                userStatus = еmployeeDTO.userStatus,
                Avatar = еmployeeDTO.Avatar,
                Phone2 = еmployeeDTO.Phone2,
                dateReg = еmployeeDTO.dateReg,                   //??????????? заполнение даты регистрации 
                adminStatus = еmployeeDTO.adminStatus,
                postId = еmployeeDTO.postId,
                Description = еmployeeDTO.Description,
                Password = hash.ToString(),
                Salt = salt
            };
            Database.Employees.Update(еmployee);
            await Database.Save();
        }
        public async Task UpdateEmployeePassword(EmployeeDTO еmployeeDTO)
        {
            byte[] saltbuf = new byte[16];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltbuf);
            StringBuilder sb = new StringBuilder(16);
            for (int i = 0; i < 16; i++)
                sb.Append(string.Format("{0:X2}", saltbuf[i]));
            string salt = sb.ToString();
            byte[] password = Encoding.Unicode.GetBytes(salt + еmployeeDTO.Password);
            byte[] byteHash = SHA256.HashData(password);
            StringBuilder hash = new StringBuilder(byteHash.Length);
            for (int i = 0; i < byteHash.Length; i++)
                hash.Append(string.Format("{0:X2}", byteHash[i]));
            var еmployee = new Employee
            {
                Id = еmployeeDTO.Id,
                Password = hash.ToString(),
                Salt = salt
            };
            Database.Employees.UpdatePassword( еmployee);
            await Database.Save();
        }
        public async Task DeleteEmployee(int id)
        {
            await Database.Employees.Delete(id);
            await Database.Save();
        }
    }
}
