using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Patient;
using Entities.RequestFeatures;

namespace Contracts.Logic
{
    public interface IPatientLogic
    {
        Task<IEnumerable<PatientDto>> GetPatientsAsync(PatientParameters patientParameters);
        Task<PatientDto> GetPatientAsync(Guid id, Guid serviceDateInfoId);
        Task<PatientDto> GetPatientAsync(Guid id);
        Task CreatePatientAsync(PatientForCreateDto patientDto);
        Task DeletePatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(Guid id, PatientForUpdateDto patientDto);
    }
}
