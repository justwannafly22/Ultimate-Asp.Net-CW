using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.Diagnos;
using System.Linq;
using Contracts;
using Entities.RequestFeatures;

namespace BLL
{
    public class DiagnosLogic : IDiagnosLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DiagnosLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        
        public async Task CreateDiagnosForPatientAsync(Guid patientId, DiagnosForCreateDto diagnosDto)
        {
            var diagnosEntity = _mapper.Map<Diagnos>(diagnosDto);

            _repositoryManager.Diagnos.CreateDiagnosForPatient(patientId, diagnosEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteDiagnosAsync(DiagnosDto diagnosDto)
        {
            var diagnosEntity = _mapper.Map<Diagnos>(diagnosDto);

            _repositoryManager.Diagnos.DeleteDiagnos(diagnosEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<DiagnosDto> GetDiagnosAsync(Guid id, Guid patientId)
        {
            var entityDiagnos = await _repositoryManager.Diagnos.GetDiagnosAsync(id, patientId, trackChanges: false);

            var diagnosDto = _mapper.Map<DiagnosDto>(entityDiagnos);

            return diagnosDto;
        }

        public async Task<IEnumerable<DiagnosDto>> GetDiagnosesAsync(Guid patientId, DiagnosParameters diagnosParameters)
        {
            var entityDiagnoses = await _repositoryManager.Diagnos.GetDiagnosesAsync(patientId, diagnosParameters, trackChanges: false);

            var diagnosesDto = _mapper.Map<IEnumerable<DiagnosDto>>(entityDiagnoses);

            return diagnosesDto;
        }
        
        public async Task UpdateDiagnosAsync(Guid id, Guid patientId, DiagnosForUpdateDto diagnosDto)
        {
            var entityDiagnos = await _repositoryManager.Diagnos.GetDiagnosAsync(id, patientId, trackChanges: true);

            _mapper.Map(diagnosDto, entityDiagnos);

            await _repositoryManager.SaveAsync();
        }
    }
}
