using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.ServiceDateInfo;

namespace Contracts.Logic
{
    public class ServiceDateInfoLogic : IServiceDateInfoLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServiceDateInfoLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateServiceDateInfoForCalendarAsync(Guid calendarId, ServiceDateInfoForCreateDto serviceDateInfoDto)
        {
            var serviceInfoEntity = _mapper.Map<ServiceDateInfo>(serviceDateInfoDto);

            serviceInfoEntity.CalendarId = calendarId;
            _repositoryManager.ServiceDateInfo.CreateServiceDateInfoForCalendar(calendarId, serviceInfoEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteServiceDateInfoAsync(ServiceDateInfoDto serviceDateInfoDto)
        {
            var serviceInfoEntity = _mapper.Map<ServiceDateInfo>(serviceDateInfoDto);

            _repositoryManager.ServiceDateInfo.DeleteServiceDateInfo(serviceInfoEntity);

            await _repositoryManager.SaveAsync();
        }

        public async Task<ServiceDateInfoDto> GetServiceDateInfoAsync(Guid id, Guid calendarId)
        {
            var serviceInfoEntity = await _repositoryManager.ServiceDateInfo.GetServiceDateInfo(id, calendarId, trackChanges: false);

            var serviceInfoDto = _mapper.Map<ServiceDateInfoDto>(serviceInfoEntity);

            return serviceInfoDto;
        }

        public async Task<ServiceDateInfoDto> GetServiceDateInfoAsync(Guid id)
        {
            var serviceInfoEntity = await _repositoryManager.ServiceDateInfo.GetServiceDateInfo(id, trackChanges: false);

            var serviceInfoDto = _mapper.Map<ServiceDateInfoDto>(serviceInfoEntity);

            return serviceInfoDto;
        }

        public async Task<IEnumerable<ServiceDateInfoDto>> GetServicesDateInfoAsync(Guid calendarId)
        {
            var serviceInfoEntities = await _repositoryManager.ServiceDateInfo.GetServicesDatesInfo(calendarId, trackChanges: false);

            var serviceInfoDto = _mapper.Map<IEnumerable<ServiceDateInfoDto>>(serviceInfoEntities);

            return serviceInfoDto;
        }

        public async Task UpdateServiceDateInfoAsync(Guid id, Guid calendarId, ServiceDateInfoForUpdateDto serviceDateInfoDto)
        {
            var serviceInfoEntity = await _repositoryManager.ServiceDateInfo.GetServiceDateInfo(id, calendarId, trackChanges: true);

            _mapper.Map(serviceDateInfoDto, serviceInfoEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
