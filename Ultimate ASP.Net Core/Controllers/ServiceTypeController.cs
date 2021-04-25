using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using Entities.DTO.ServiceDateInfo;
using Entities.DTO.ServiceType;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/serviceDateInfo/{serviceDateInfoId}/serviceType")]
    public class ServiceTypeController : Controller
    {
        private readonly IServiceTypeLogic _serviceTypeLogic;
        private readonly ILoggerManager _logger;

        public ServiceTypeController(IServiceTypeLogic serviceTypeLogic, ILoggerManager logger)
        {
            _serviceTypeLogic = serviceTypeLogic;
            _logger = logger;
        }

        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetServiceTypes(Guid serviceDateInfoId)
        {
            var types = await _serviceTypeLogic.GetServiceTypesAsync(serviceDateInfoId);
            
            return Ok(types);
        }

        [HttpGet("{serviceTypeId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateServiceDateInfoExistAttribute))]
        public async Task<IActionResult> GetServiceType(Guid serviceDateInfoId, Guid serviceTypeId)
        {
            var serviceDateInfo = HttpContext.Items["serviceDateInfo"] as ServiceDateInfoDto;
            var serviceType = await _serviceTypeLogic.GetServiceTypeAsync(serviceTypeId, serviceDateInfoId);

            if(serviceType == null)
            {
                _logger.LogInfo($"ServiceType with id: {serviceTypeId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(serviceType);
        }
        
        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateServiceType(Guid serviceDateInfoId, [FromBody] ServiceTypeForCreateDto serviceType)
        {
            await _serviceTypeLogic.CreateServiceTypeForServiceDateInfoAsync(serviceDateInfoId, serviceType);

            return Ok(serviceType);
        }

        [HttpDelete("{serviceTypeId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateServiceTypeForServiceDateInfoExistAttribute))]
        public async Task<IActionResult> DeleteServiceType(Guid serviceDateInfoId, Guid serviceTypeId)
        {
            var serviceType = HttpContext.Items["serviceType"] as ServiceTypeDto;

            await _serviceTypeLogic.DeleteServiceTypeAsync(serviceType);

            return NoContent();
        }

        [HttpPut("{serviceTypeId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateServiceTypeForServiceDateInfoExistAttribute))]
        public async Task<IActionResult> UpdateServiceType(Guid serviceDateInfoId, Guid serviceTypeId, [FromBody] ServiceTypeForUpdateDto serviceType)
        {
            await _serviceTypeLogic.UpdateServiceTypeAsync(serviceTypeId, serviceDateInfoId, serviceType);

            return NoContent();
        }
    }
}
