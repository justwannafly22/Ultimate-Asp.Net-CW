using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ultimate_ASP.Net_Core.ActionFilters;
using Entities.RequestFeatures;
using Contracts.Logic;
using Entities.DTO.Service;
using Entities.DTO.Employee;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/services/{serviceId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ILoggerManager _logger;

        public EmployeesController(IEmployeeLogic employeeLogic, ILoggerManager logger)
        {
            _employeeLogic = employeeLogic;
            _logger = logger;
        }
        
        [HttpGet, Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidateServiceExistAttribute))]
        public async Task<IActionResult> GetEmployeesForCompany(Guid serviceId, [FromQuery] EmployeeParameters employeeParameters)
        {
            if (!employeeParameters.ValidAgeRange)
                return BadRequest("Max age can`t be less than min age.");

            var employees = await _employeeLogic.GetEmployeesForService(serviceId, employeeParameters);

            return Ok(employees);
        }
        
        [HttpGet("{employeeId}", Name = "GetEmployeeForService"), Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidateServiceExistAttribute))]
        public async Task<IActionResult> GetEmployeeForCompany(Guid serviceId, Guid employeeId)
        {
            var service = HttpContext.Items["service"] as ServiceDto;
            var employee = await _employeeLogic.GetEmployee(employeeId, service.Id);

            if(employee == null)
            {
                _logger.LogInfo($"Employee with id: {employeeId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateServiceExistAttribute))]
        public async Task<IActionResult> CreateEmployeeForService(Guid serviceId, [FromBody] EmployeeForCreateDto employee)
        {
            await _employeeLogic.CreateEmployee(serviceId, employee);

            return StatusCode(201);
        }

        [HttpDelete("{employeeId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateEmployeeForServiceExistAttribute))]
        public async Task<IActionResult> DeleteEmployee(Guid serviceId, Guid employeeId)
        {
            var employee = HttpContext.Items["employee"] as EmployeeDto;

            await _employeeLogic.DeleteEmployee(employee);
            
            return NoContent();
        }
        
        [HttpPut("{employeeId}"), Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEmployeeForServiceExistAttribute))]
        public async Task<IActionResult> UpdateEmployee(Guid serviceId, Guid employeeId, [FromBody] EmployeeForUpdateDto employee)
        {
            await _employeeLogic.UpdateEmployee(employeeId, employee);

            return NoContent();
        }

    }
}
