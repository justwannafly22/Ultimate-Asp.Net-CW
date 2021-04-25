using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ultimate_ASP.Net_Core.ActionFilters
{
    public class ValidateDiagnosForPatientExistAttribute : IAsyncActionFilter
    {
        private readonly IPatientLogic _patientLogic;
        private readonly IDiagnosLogic _diagnosLogic;
        private readonly ILoggerManager _logger;

        public ValidateDiagnosForPatientExistAttribute(IPatientLogic patientLogic, IDiagnosLogic diagnosLogic, ILoggerManager logger)
        {
            _patientLogic = patientLogic;
            _diagnosLogic = diagnosLogic;
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

            var id = (Guid)context.ActionArguments["id"];
            var diagnos = await _diagnosLogic.GetDiagnosAsync(id, patientId);

            if(diagnos == null)
            {
                _logger.LogInfo($"Diagnos with id: {id} doesn`t exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("diagnos", diagnos);
                await next();
            }
        }
    }
}
