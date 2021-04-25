using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.Diagnos;
using Entities.DTO.Patient;
using Contracts;
using Entities.RequestFeatures;

namespace BLL
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PatientLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreatePatientAsync(PatientForCreateDto patientDto)
        {
            var patientEntity = _mapper.Map<Patient>(patientDto);

            _repositoryManager.Patient.CreatePatient(patientEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeletePatientAsync(PatientDto patientDto)
        {
            var patientEntity = _mapper.Map<Patient>(patientDto);

            _repositoryManager.Patient.DeletePatient(patientEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<PatientDto> GetPatientAsync(Guid id, Guid serviceDateInfoId)
        {
            var patientEntity = await _repositoryManager.Patient.GetPatientAsync(id, serviceDateInfoId, trackChanges: false);

            var patientDto = _mapper.Map<PatientDto>(patientEntity);

            return patientDto;
        }

        public async Task<IEnumerable<PatientDto>> GetPatientsAsync(PatientParameters patientParameters)
        {
            var entityPatients = await _repositoryManager.Patient.GetPatientsAsync(patientParameters, trackChanges: false);

            var dtoPatiens = _mapper.Map<IEnumerable<PatientDto>>(entityPatients);

            return dtoPatiens;
        }

        public async Task<PatientDto> GetPatientAsync(Guid id)
        {
            var entityPatient = await _repositoryManager.Patient.GetPatientAsync(id, trackChanges: false);

            var patientDto = _mapper.Map<PatientDto>(entityPatient);

            return patientDto;
        }

        public async Task UpdatePatientAsync(Guid id, PatientForUpdateDto patientDto)
        {
            var patientEntity = await _repositoryManager.Patient.GetPatientAsync(id, trackChanges: true);

            _mapper.Map(patientDto, patientEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
