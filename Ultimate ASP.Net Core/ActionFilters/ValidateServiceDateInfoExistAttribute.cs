using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateServiceDateInfoExistAttribute : IAsyncActionFilter
    {
        private readonly IServiceDateInfoLogic _serviceDILogic;
        private readonly ILoggerManager _logger;

        public ValidateServiceDateInfoExistAttribute(IServiceDateInfoLogic serviceDILogic, ILoggerManager logger)
        {
            _serviceDILogic = serviceDILogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceDateInfoId = (Guid)context.ActionArguments["serviceDateInfoId"];
            var serviceDateInfo = await _serviceDILogic.GetServiceDateInfoAsync(serviceDateInfoId);

            if(serviceDateInfo == null)
            {
                _logger.LogInfo($"ServiceDateInfo with id: {serviceDateInfoId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("serviceDateInfo", serviceDateInfo);
                await next();
            }
        }
    }
}
