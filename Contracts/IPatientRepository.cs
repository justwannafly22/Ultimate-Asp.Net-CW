using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync(PatientParameters patientParameters, bool trackChanges);
        Task<Patient> GetPatientAsync(Guid id, Guid? serviceDateInfoId, bool trackChanges);
        Task<Patient> GetPatientAsync(Guid id, bool trackChanges);
        void CreatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
