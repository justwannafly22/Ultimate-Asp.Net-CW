using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.DTO.ServiceDateInfo;
using Entities.RequestFeatures;
using Entities.DTO.Calendar;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/calendar/{calendarId}/serviceDateInfo")]
    public class ServicesDateInfoController : Controller
    {
        private readonly IServiceDateInfoLogic _serviceDILogic;
        private readonly ILoggerManager _logger;

        public ServicesDateInfoController(IServiceDateInfoLogic serviceDILogic, ILoggerManager logger)
        {
            _serviceDILogic = serviceDILogic;
            _logger = logger;
        }

        [HttpGet, Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidateCalendarExistAttribute))]
        public async Task<IActionResult> GetServicesDateInfoForCalendar(Guid calendarId)
        {
            var servicesDateInfo = await _serviceDILogic.GetServicesDateInfoAsync(calendarId);
            
            return Ok(servicesDateInfo);
        }

        [HttpGet("{serviceDateInfoId}"), Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidateCalendarExistAttribute))]
        public async Task<IActionResult> GetServiceDateInfo(Guid calendarId, Guid serviceDateInfoId)
        {
            var calendar = HttpContext.Items["calendar"] as CalendarDto;
            var serviceDateInfo = await _serviceDILogic.GetServiceDateInfoAsync(serviceDateInfoId, calendar.Id);

            if(serviceDateInfo == null)
            {
                _logger.LogInfo($"ServiceDateInfo with id: {serviceDateInfoId} doesn`t exist in the database.");
                return NotFound();
            }
            
            return Ok(serviceDateInfo);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCalendarExistAttribute))]
        public async Task<IActionResult> CreateServiceDateInfoForCalendar(Guid calendarId, [FromBody] ServiceDateInfoForCreateDto serviceDateInfo)
        {
            var calendar = HttpContext.Items["calendar"] as CalendarDto;

            await _serviceDILogic.CreateServiceDateInfoForCalendarAsync(calendar.Id, serviceDateInfo);

            return NoContent();
        }

        [HttpDelete("{serviceDateInfoId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateServiceDateInfoForCalendarExistAttribute))]
        public async Task<IActionResult> DeleteServiceDateInfo(Guid calendarId, Guid serviceDateInfoId)
        {
            var serviceDateInfo = HttpContext.Items["serviceDateInfo"] as ServiceDateInfoDto;

            await _serviceDILogic.DeleteServiceDateInfoAsync(serviceDateInfo);

            return NoContent();
        }

        [HttpPut("{serviceDateInfoId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateServiceDateInfoForCalendarExistAttribute))]
        public async Task<IActionResult> UpdateServiceDateInfo(Guid serviceDateInfoId, Guid calendarId, [FromBody] ServiceDateInfoForUpdateDto serviceDateInfo)
        {
            await _serviceDILogic.UpdateServiceDateInfoAsync(serviceDateInfoId, calendarId, serviceDateInfo);

            return NoContent();
        }

    }
}
