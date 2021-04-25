using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateServiceForServiceTypeExistAttribute : IAsyncActionFilter
    {

        private readonly IServiceTypeLogic _serviceTypeLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly ILoggerManager _logger;
        
        public ValidateServiceForServiceTypeExistAttribute(IServiceTypeLogic serviceTypeLogic, IServiceLogic serviceLogic, ILoggerManager logger)
        {
            _serviceTypeLogic = serviceTypeLogic;
            _serviceLogic = serviceLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceTypeId = (Guid)context.ActionArguments["serviceTypeId"];
            var serviceType = await _serviceTypeLogic.GetServiceTypeAsync(serviceTypeId);

            if (serviceType == null)
            {
                _logger.LogInfo($"ServiceType with id: {serviceTypeId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }

            var serviceId = (Guid)context.ActionArguments["serviceId"];
            var service = await _serviceLogic.GetServiceAsync(serviceId, serviceTypeId);

            if (service == null)
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
