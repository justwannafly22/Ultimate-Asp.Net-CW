using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IDiagnosRepository
    {
        Task<IEnumerable<Diagnos>> GetDiagnosesAsync(Guid patientId, DiagnosParameters diagnosParameters, bool trackChanges);
        Task<Diagnos> GetDiagnosAsync(Guid id, Guid patientId, bool trackChanges);
        Task<Diagnos> GetDiagnosByIdAsync(Guid id, bool trackChanges);
        void CreateDiagnosForPatient(Guid patientId, Diagnos diagnos);
        void DeleteDiagnos(Diagnos diagnos);
    }
}
