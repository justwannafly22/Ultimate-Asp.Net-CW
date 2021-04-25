using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateServiceExistAttribute : IAsyncActionFilter
    {
        private readonly IServiceLogic _serviceLogic;
        private readonly ILoggerManager _logger;

        public ValidateServiceExistAttribute(IServiceLogic serviceLogic, ILoggerManager logger)
        {
            _serviceLogic = serviceLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceId = (Guid)context.ActionArguments["serviceId"];
            var service = await _serviceLogic.GetServiceAsync(serviceId);

            if(service == null)
            {
                _logger.LogInfo($"Service with id: {serviceId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("service", service);
                await next();
            }
        }
    }
}
