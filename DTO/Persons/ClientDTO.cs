using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAgency.BLL.DTO.Persons
{
    public class ClientDTO : PersonDTO
    {
        public int Id { get; set; }

        public string? OperationName { get; set; }
        public int operationId { get; set; }

        public string? EmployeeName { get; set; }
        public string? EmployeePhone { get; set; }
        public int employeeId { get; set; }

        public bool status { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
}
