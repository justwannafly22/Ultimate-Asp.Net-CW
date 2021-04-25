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
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        
        public void CreatePatient(Patient patient) =>
            Create(patient);

        public void DeletePatient(Patient patient) =>
            Delete(patient);

        public async Task<Patient> GetPatientAsync(Guid id, Guid? serviceDateInfoId, bool trackChanges) =>
            await FindByCondition(p => p.ServiceDateInfoId.Equals(serviceDateInfoId) && p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Patient>> GetPatientsAsync(PatientParameters patientParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .FilterPatients(patientParameters.MinAge, patientParameters.MaxAge)
            .Search(patientParameters.SearchTerm)
            .Sort(patientParameters.OrderBy)
            .ToListAsync();

        public async Task<Patient> GetPatientAsync(Guid id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
