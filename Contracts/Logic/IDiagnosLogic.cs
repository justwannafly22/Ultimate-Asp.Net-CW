using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Diagnos;
using Entities.RequestFeatures;

namespace Contracts.Logic
{
    public interface IDiagnosLogic
    {
        Task<IEnumerable<DiagnosDto>> GetDiagnosesAsync(Guid patientId, DiagnosParameters diagnosParameters);
        Task<DiagnosDto> GetDiagnosAsync(Guid id, Guid patientId);
        Task CreateDiagnosForPatientAsync(Guid patientId, DiagnosForCreateDto diagnosDto);
        Task DeleteDiagnosAsync(DiagnosDto diagnosDto);
        Task UpdateDiagnosAsync(Guid id, Guid patientId, DiagnosForUpdateDto diagnosDto);
    }
}
