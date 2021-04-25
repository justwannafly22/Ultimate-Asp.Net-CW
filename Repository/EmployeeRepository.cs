using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Entities.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository // MUST TEST ALL REPOSITORY METHODS!!!
    {
        public EmployeeRepository(RepositoryContext repositoryContext) :
            base(repositoryContext) { }

        public async Task<Employee> GetEmployee(Guid serviceId, Guid id, bool trackChanges) =>
            await FindByCondition(t => t.ServiceId.Equals(serviceId) && t.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Employee> GetEmployee(Guid id, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Employee>> GetEmployees(Guid serviceId, EmployeeParameters employeeParameters, bool trackChanges) =>
            await FindByCondition(t => t.ServiceId.Equals(serviceId), trackChanges)
                .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
                .Search(employeeParameters.SearchTerm)
                .Sort(employeeParameters.OrderBy)
                .ToListAsync();
        
        public void CreateEmployeeForService(Guid serviceId, Employee employee)
        {
            employee.ServiceId = serviceId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) =>
            Delete(employee);

    }
}
