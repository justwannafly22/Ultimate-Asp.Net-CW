using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using Entities.DTO.Calendar;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/calendars")]
    public class CalendarController : Controller
    {
        private readonly ICalendarLogic _calendarLogic;
        private readonly ILoggerManager _logger;

        public CalendarController(ICalendarLogic calendarLogic, ILoggerManager logger)
        {
            _calendarLogic = calendarLogic;
            _logger = logger;
        }

        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCalendars([FromQuery] CalendarParameters calendarParameters)//checked;
        {
            var calendars = await _calendarLogic.GetCalendarsAsync(calendarParameters);

            return Ok(calendars);
        }

        [HttpGet("{calendarId}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCalendar(Guid calendarId)//checked;
        {
            var calendar = await _calendarLogic.GetCalendarAsync(calendarId);

            if(calendar == null)
            {
                _logger.LogInfo($"Calendar with id: {calendarId} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(calendar);
        }
        
        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCalendar([FromBody] CalendarForCreateDto calendar)
        {
            await _calendarLogic.CreateCalendarAsync(calendar);

            return Ok();
        }

        [HttpDelete("{calendarId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateCalendarExistAttribute))]
        public async Task<IActionResult> DeleteCalendar(Guid calendarId)
        {
            var calendar = HttpContext.Items["calendar"] as CalendarDto;

            await _calendarLogic.DeleteCalendarAsync(calendar);

            return NoContent();
        }
        
        [HttpPut("{calendarId}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCalendarExistAttribute))]
        public async Task<IActionResult> UpdateCalendar(Guid calendarId, [FromBody] CalendarForUpdateDto calendar)
        {
            await _calendarLogic.UpdateCalendarAsync(calendarId, calendar);

            return NoContent();
        }
        
    }
}
