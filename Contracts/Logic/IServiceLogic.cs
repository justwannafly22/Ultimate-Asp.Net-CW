using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Service;

namespace Contracts.Logic
{
    public interface IServiceLogic
    {
        Task<IEnumerable<ServiceDto>> GetServicesAsync(Guid serviceTypeId);
        Task<ServiceDto> GetServiceAsync(Guid id, Guid serviceTypeId);
        Task<ServiceDto> GetServiceAsync(Guid id);
        Task CreateServiceForServiceTypeAsync(Guid serviceTypeId, ServiceForCreateDto serviceDto);
        Task DeleteServiceAsync(ServiceDto serviceDto);
        Task UpdateServiceAsync(Guid id, Guid serviceTypeId, ServiceForUpdateDto serviceDto);
    }
}
