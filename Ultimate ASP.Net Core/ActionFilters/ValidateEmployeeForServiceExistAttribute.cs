using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateEmployeeForServiceExistAttribute : IAsyncActionFilter
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IServiceLogic _serviceLogic;
        private readonly ILoggerManager _logger;

        public ValidateEmployeeForServiceExistAttribute(IEmployeeLogic employeeLogic, IServiceLogic serviceLogic, ILoggerManager logger)
        {
            _employeeLogic = employeeLogic;
            _serviceLogic = serviceLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var serviceId = (Guid)context.ActionArguments["serviceId"];
            var service = await _serviceLogic.GetServiceAsync(serviceId);

            if (service == null)
            {
                _logger.LogInfo($"Service with id: {serviceId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }

            var employeeId = (Guid)context.ActionArguments["employeeId"];
            var employee = await _employeeLogic.GetEmployee(employeeId, serviceId);

            if(employee == null)
            {
                _logger.LogInfo($"Employee with id: {employeeId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("employee", employee);
                await next();
            }

        }
    }
}
