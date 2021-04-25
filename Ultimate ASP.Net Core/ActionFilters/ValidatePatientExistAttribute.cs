using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Contracts.Logic;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidatePatientExistAttribute : IAsyncActionFilter
    {
        private readonly IPatientLogic _patientLogic;
        private readonly ILoggerManager _logger;

        public ValidatePatientExistAttribute(IPatientLogic patientLogic, ILoggerManager logger)
        {
            _patientLogic = patientLogic;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var patientId = (Guid)context.ActionArguments["patientId"];
            var patient = await _patientLogic.GetPatientAsync(patientId);

            if(patient == null)
            {
                _logger.LogInfo($"Patient with id: {patientId} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("patient", patient);
                await next();
            }
        }
    }
}
