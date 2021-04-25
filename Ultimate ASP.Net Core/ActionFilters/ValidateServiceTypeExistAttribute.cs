using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateServiceTypeExistAttribute : IAsyncActionFilter
    {
        private readonly IServiceTypeLogic _serviceTypeLogic;
        private readonly ILoggerManager _logger;

        public ValidateServiceTypeExistAttribute(IServiceTypeLogic serviceTypeLogic, ILoggerManager logger)
        {
            _serviceTypeLogic = serviceTypeLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceTypeId = (Guid)context.ActionArguments["serviceTypeId"];
            var serviceType = await _serviceTypeLogic.GetServiceTypeAsync(serviceTypeId);

            if(serviceType == null)
            {
                _logger.LogInfo($"ServiceType with id: {serviceTypeId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("serviceType", serviceType);
                await next();
            }
        }
    }
}
