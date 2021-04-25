using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateServiceTypeForServiceDateInfoExistAttribute : IAsyncActionFilter
    {
        private readonly IServiceDateInfoLogic _serviceDILogic;
        private readonly IServiceTypeLogic _serviceTypeLogic;
        private readonly ILoggerManager _logger;
        
        public ValidateServiceTypeForServiceDateInfoExistAttribute(IServiceDateInfoLogic serviceDILogic, IServiceTypeLogic serviceTypeLogic, ILoggerManager logger)
        {
            _serviceDILogic = serviceDILogic;
            _serviceTypeLogic = serviceTypeLogic;
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

            var serviceTypeId = (Guid)context.ActionArguments["serviceTypeId"];
            var serviceType = await _serviceTypeLogic.GetServiceTypeAsync(serviceTypeId, serviceDateInfo.Id);

            if (serviceType == null)
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
