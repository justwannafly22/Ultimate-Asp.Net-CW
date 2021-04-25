using System;
using System.Collections.Generic;
using Entities.Models;
using Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Entities.RequestFeatures;

namespace Repository
{
    public class DiagnosRepository : RepositoryBase<Diagnos>, IDiagnosRepository
    {
        public DiagnosRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateDiagnosForPatient(Guid patientId, Diagnos diagnos)
        {
            diagnos.PatientId = patientId;
            Create(diagnos);
        }
        
        public void DeleteDiagnos(Diagnos diagnos) =>
            Delete(diagnos);
        
        public async Task<Diagnos> GetDiagnosAsync(Guid id, Guid patientId, bool trackChanges) =>
            await FindByCondition(d => d.Id.Equals(id) && d.PatientId.Equals(patientId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Diagnos>> GetDiagnosesAsync(Guid patientId, DiagnosParameters diagnosParameters, bool trackChanges) =>
            await FindByCondition(d => d.PatientId.Equals(patientId), trackChanges)
            .Search(diagnosParameters.SearchTerm)
            .Sort(diagnosParameters.OrderBy)
            .ToListAsync();
        
        public async Task<Diagnos> GetDiagnosByIdAsync(Guid id, bool trackChanges) =>
            await FindByCondition(d => d.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
