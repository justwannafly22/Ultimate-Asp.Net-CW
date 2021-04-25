using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.ServiceDateInfo;

namespace Contracts.Logic
{
    public interface IServiceDateInfoLogic
    {
        Task<IEnumerable<ServiceDateInfoDto>> GetServicesDateInfoAsync(Guid calendarId);
        Task<ServiceDateInfoDto> GetServiceDateInfoAsync(Guid id, Guid calendarId);
        Task<ServiceDateInfoDto> GetServiceDateInfoAsync(Guid id);
        Task CreateServiceDateInfoForCalendarAsync(Guid calendarId, ServiceDateInfoForCreateDto serviceDateInfoDto);
        Task DeleteServiceDateInfoAsync(ServiceDateInfoDto serviceDateInfoDto);
        Task UpdateServiceDateInfoAsync(Guid id, Guid calendarId, ServiceDateInfoForUpdateDto serviceDateInfoDto);
    }
}
