using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.Service;
using Contracts;

namespace BLL
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateServiceForServiceTypeAsync(Guid serviceTypeId, ServiceForCreateDto serviceDto)
        {
            var serviceEntity = _mapper.Map<Service>(serviceDto);

            _repositoryManager.Service.CreateServiceForServiceType(serviceEntity, serviceTypeId);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteServiceAsync(ServiceDto serviceDto)
        {
            var serviceEntity = _mapper.Map<Service>(serviceDto);

            _repositoryManager.Service.DeleteService(serviceEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<ServiceDto> GetServiceAsync(Guid id, Guid serviceTypeId)
        {
            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(id, serviceTypeId, trackChanges: false);

            var serviceDto = _mapper.Map<ServiceDto>(serviceEntity);

            return serviceDto;
        }

        public async Task<ServiceDto> GetServiceAsync(Guid id)
        {
            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(id, trackChanges: false);

            var serviceDto = _mapper.Map<ServiceDto>(serviceEntity);

            return serviceDto;
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesAsync(Guid serviceTypeId)
        {
            var serviceEntities = await _repositoryManager.Service.GetServicesAsync(serviceTypeId, trackChanges: false);

            var serviceDto = _mapper.Map<IEnumerable<ServiceDto>>(serviceEntities);

            return serviceDto;
        }

        public async Task UpdateServiceAsync(Guid id, Guid serviceTypeId, ServiceForUpdateDto serviceDto)
        {
            var serviceEntity = await _repositoryManager.Service.GetServiceAsync(id, serviceTypeId, trackChanges: true);

            _mapper.Map(serviceDto, serviceEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
