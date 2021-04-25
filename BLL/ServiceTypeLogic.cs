using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.ServiceType;
using Contracts;

namespace BLL
{
    public class ServiceTypeLogic : IServiceTypeLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceTypeLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateServiceTypeForServiceDateInfoAsync(Guid serviceDateInfoId, ServiceTypeForCreateDto serviceTypeDto)
        {
            var serviceTypeEntity = _mapper.Map<ServiceType>(serviceTypeDto);

            _repositoryManager.ServiceType.CreateServiceTypeForServiceDateInfo(serviceTypeEntity, serviceDateInfoId);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteServiceTypeAsync(ServiceTypeDto serviceTypeDto)
        {
            var serviceTypeEntity = _mapper.Map<ServiceType>(serviceTypeDto);

            _repositoryManager.ServiceType.DeleteServiceType(serviceTypeEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<ServiceTypeDto> GetServiceTypeAsync(Guid id, Guid serviceDateInfoId)
        {
            var serviceTypeEntity = await _repositoryManager.ServiceType.GetServiceTypeAsync(id, serviceDateInfoId, trackChanges: false);

            var serviceTypeDto = _mapper.Map<ServiceTypeDto>(serviceTypeEntity);

            return serviceTypeDto;
        }

        public async Task<ServiceTypeDto> GetServiceTypeAsync(Guid id)
        {
            var serviceTypeEntity = await _repositoryManager.ServiceType.GetServiceTypeAsync(id, trackChanges: false);

            var serviceTypeDto = _mapper.Map<ServiceTypeDto>(serviceTypeEntity);

            return serviceTypeDto;
        }

        public async Task<IEnumerable<ServiceTypeDto>> GetServiceTypesAsync(Guid serviceDateInfoId)
        {
            var serviceTypeEntities = await _repositoryManager.ServiceType.GetServiceTypesAsync(serviceDateInfoId, trackChanges: false);

            var serviceTypeDto = _mapper.Map<IEnumerable<ServiceTypeDto>>(serviceTypeEntities);

            return serviceTypeDto;
        }

        public async Task UpdateServiceTypeAsync(Guid id, Guid serviceDateInfoId, ServiceTypeForUpdateDto serviceTypeDto)
        {
            var serviceTypeEntity = await _repositoryManager.ServiceType.GetServiceTypeAsync(id, serviceDateInfoId, trackChanges: true);

            _mapper.Map(serviceTypeDto, serviceTypeEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
