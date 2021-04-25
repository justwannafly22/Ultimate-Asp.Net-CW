using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(Guid serviceId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployee(Guid serviceId, Guid id, bool trackChanges);
        Task<Employee> GetEmployee(Guid id, bool trackChanges);
        void CreateEmployeeForService(Guid serviceId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
