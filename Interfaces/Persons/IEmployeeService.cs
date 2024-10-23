﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Persons;

namespace REAgency.BLL.Interfaces.Persons
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);

        Task<EmployeeDTO> GetEmployeeByName(string name);
        Task<EmployeeDTO> GetEmployeeByEmail(string email);

        Task CreateEmployee(EmployeeDTO еmployeeDTO);
        Task UpdateEmployeePassword(EmployeeDTO employeeDTO);
        Task UpdateEmployee(EmployeeDTO еmployeeDTO);
        Task UpdateEmployeeAvatar(byte[] data, int id);
        Task DeleteEmployee(int id);
    }
}
