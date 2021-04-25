using Contracts;
using Contracts.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using Ultimate_ASP.Net_Core.ActionFilters;
using System.Threading.Tasks;
using Entities.DTO.Patient;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;

namespace Ultimate_ASP.Net_Core.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : Controller
    {
        private readonly IPatientLogic _patientLogic;
        private readonly ILoggerManager _logger;
        
        public PatientsController(IPatientLogic patientLogic, ILoggerManager logger)
        {
            _patientLogic = patientLogic;
            _logger = logger;
        }

        [HttpGet, Authorize(Roles = "Administrator, Staff, User")]
        public async Task<IActionResult> GetPatients([FromQuery] PatientParameters patientParameters)//checked;
        {
            var patients = await _patientLogic.GetPatientsAsync(patientParameters);
            
            return Ok(patients);
        }

        [HttpGet("{id}"), Authorize(Roles = "Administrator, Staff, User")]
        public async Task<IActionResult> GetPatient(Guid id)//checked;
        {
            var patient = await _patientLogic.GetPatientAsync(id);

            if (patient == null)
            {
                _logger.LogInfo($"Patient with id: {id} doesn`t exist in the database.");
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost, Authorize(Roles = "User")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePatient([FromBody] PatientForCreateDto patientDto)//checked;
        {
            await _patientLogic.CreatePatientAsync(patientDto);
            
            return Ok();
        }
        
        [HttpDelete("{patientId}"), Authorize(Roles = "Administrator, User")]
        [ServiceFilter(typeof(ValidatePatientExistAttribute))]
        public async Task<IActionResult> DeletePatient(Guid patientId)//checked;
        {
            var patient = HttpContext.Items["patient"] as PatientDto;

            await _patientLogic.DeletePatientAsync(patient);

            return NoContent();
        }

        [HttpPut("{patientId}"), Authorize(Roles = "Administrator, Staff, User")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidatePatientExistAttribute))]
        public async Task<IActionResult> UpdatePatient(Guid patientId, [FromBody] PatientForUpdateDto patient)//checked;
        {
            await _patientLogic.UpdatePatientAsync(patientId, patient);
            
            return NoContent();
        }

    }
}
