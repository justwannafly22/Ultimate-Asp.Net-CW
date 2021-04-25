using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.DTO.Diagnos;
using Entities.DTO.Patient;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/diagnoses")]
    
    public class DiagnosesController : Controller
    {
        private readonly IDiagnosLogic _diagnosLogic;
        private readonly ILoggerManager _logger;
        
        public DiagnosesController(IDiagnosLogic diagnosLogic, ILoggerManager logger)
        {
            _diagnosLogic = diagnosLogic;
            _logger = logger;
        }
        
        [HttpGet(Name = "GetDiagnosesForPatient"), Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidatePatientExistAttribute))]
        public async Task<IActionResult> GetDiagnosesForPatient(Guid patientId, [FromQuery] DiagnosParameters diagnosParameters)//correctly;
        {
            var diagnosesFromDB = await _diagnosLogic.GetDiagnosesAsync(patientId, diagnosParameters);

            return Ok(diagnosesFromDB);
        }

        [HttpGet("{id}", Name = "GetDiagnosForPatient"), Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidatePatientExistAttribute))]
        public async Task<IActionResult> GetDiagnosForPatient(Guid patientId, Guid id)//correctly;
        {
            var patient = HttpContext.Items["patient"] as PatientDto;
            var diagnos = await _diagnosLogic.GetDiagnosAsync(id, patient.Id);

            if(diagnos == null)
            {
                _logger.LogInfo($"Diagnos with id: {id} doesn`t exist in the database.");
                return NotFound();
            }
            
            return Ok(diagnos);
        }
        
        [HttpPost, Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidatePatientExistAttribute))]
        public async Task<IActionResult> CreateDiagnosForPatient(Guid patientId, [FromBody] DiagnosForCreateDto diagnos)//correctly;
        {
            var patient = HttpContext.Items["patient"] as PatientDto;

            await _diagnosLogic.CreateDiagnosForPatientAsync(patient.Id, diagnos);

            return Ok();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidateDiagnosForPatientExistAttribute))]
        public async Task<IActionResult> DeleteDiagnosForPatient(Guid patientId, Guid id)
        {
            var diagnos = HttpContext.Items["diagnos"] as DiagnosDto;

            await _diagnosLogic.DeleteDiagnosAsync(diagnos);

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator, Staff")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateDiagnosForPatientExistAttribute))]
        public async Task<IActionResult> UpdateDiagnosForPatient(Guid patientId, Guid id, [FromBody] DiagnosForUpdateDto diagnosUpd)
        {
            await _diagnosLogic.UpdateDiagnosAsync(id, patientId, diagnosUpd);

            return NoContent();
        }

    }
}
