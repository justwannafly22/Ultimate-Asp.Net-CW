using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using Entities.DTO.ServiceType;
using Entities.DTO.Service;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/serviceType/{serviceTypeId}/service")]
    public class ServiceController : Controller
    {
        private readonly IServiceLogic _serviceLogic;
        private readonly ILoggerManager _logger;

        public ServiceController(IServiceLogic serviceLogic, ILoggerManager logger)
        {
            _serviceLogic = serviceLogic;
            _logger = logger;
        }
        
        [HttpGet, Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidateServiceTypeExistAttribute))]
        public async Task<IActionResult> GetServicesForServiceType(Guid serviceTypeId)
        {
            var services = await _serviceLogic.GetServicesAsync(serviceTypeId);

            return Ok(services);
        }

        [HttpGet("{serviceId}"), Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidateServiceTypeExistAttribute))]
        public async Task<IActionResult> GetService(Guid serviceTypeId, Guid serviceId)
        {
            var serviceType = HttpContext.Items["serviceType"] as ServiceTypeDto;
            var service = await _serviceLogic.GetServiceAsync(serviceId, serviceTypeId);

            if(service == null)
            {
                _logger.LogInfo($"Service with id: {serviceId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateServiceTypeExistAttribute))]
        public async Task<IActionResult> CreateService(Guid serviceTypeId, [FromBody] ServiceForCreateDto service)
        {
            await _serviceLogic.CreateServiceForServiceTypeAsync(serviceTypeId, service);
            
            return StatusCode(201);
        }

        [HttpDelete("{serviceId}")]
        [ServiceFilter(typeof(ValidateServiceForServiceTypeExistAttribute))]
        public async Task<IActionResult> DeleteService(Guid serviceTypeId, Guid serviceId)
        {
            var service = HttpContext.Items["service"] as ServiceDto;

            await _serviceLogic.DeleteServiceAsync(service);

            return NoContent();
        }
        
        [HttpPut("{serviceId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateServiceForServiceTypeExistAttribute))]
        public async Task<IActionResult> UpdateService(Guid serviceTypeId, Guid serviceId, [FromBody] ServiceForUpdateDto service)
        {
            await _serviceLogic.UpdateServiceAsync(serviceId, serviceTypeId, service);

            return NoContent();
        }

    }
}
