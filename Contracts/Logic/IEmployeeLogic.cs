using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Employee;
using Entities.RequestFeatures;

namespace Contracts.Logic
{
    public interface IEmployeeLogic
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesForService(Guid serviceId, EmployeeParameters employeeParameters);
        Task<EmployeeDto> GetEmployee(Guid id, Guid serviceId);
        Task<EmployeeDto> GetEmployee(Guid id);
        Task CreateEmployee(Guid serviceId, EmployeeForCreateDto employee);
        Task DeleteEmployee(EmployeeDto employee);
        Task UpdateEmployee(Guid id, EmployeeForUpdateDto employee);
    }
}
