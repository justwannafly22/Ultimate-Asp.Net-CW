using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.Employee;
using System.Linq;
using Contracts;
using Entities.RequestFeatures;

namespace BLL
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateEmployee(Guid serviceId, EmployeeForCreateDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);

            _repositoryManager.Employee.CreateEmployeeForService(serviceId, employeeEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteEmployee(EmployeeDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);

            _repositoryManager.Employee.DeleteEmployee(employeeEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<EmployeeDto> GetEmployee(Guid id, Guid serviceId)
        {
            var employeeEntity = await _repositoryManager.Employee.GetEmployee(serviceId, id, trackChanges: false);

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeDto;
        }

        public async Task<EmployeeDto> GetEmployee(Guid id)
        {
            var employeeEntity = await _repositoryManager.Employee.GetEmployee(id, trackChanges: false);

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesForService(Guid serviceId, EmployeeParameters employeeParameters)
        {
            var entityEmployees = await _repositoryManager.Employee.GetEmployees(serviceId, employeeParameters, trackChanges: false);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(entityEmployees);

            return employeesDto;
        }

        public async Task UpdateEmployee(Guid id, EmployeeForUpdateDto employee)
        {
            var employeeEntity = await _repositoryManager.Employee.GetEmployee(id, trackChanges: true);

            _mapper.Map(employee, employeeEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
