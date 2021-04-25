using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateCalendarExistAttribute : IAsyncActionFilter
    {
        private readonly ICalendarLogic _calendarLogic;
        private readonly ILoggerManager _logger;
        public ValidateCalendarExistAttribute(ICalendarLogic calendarLogic, ILoggerManager logger)
        {
            _calendarLogic = calendarLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var calendarId = (Guid)context.ActionArguments["calendarId"];
            var calendar = await _calendarLogic.GetCalendarAsync(calendarId);

            if(calendar == null)
            {
                _logger.LogInfo($"Calendar with id: {calendarId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("calendar", calendar);
                await next();
            }
        }
    }
}
