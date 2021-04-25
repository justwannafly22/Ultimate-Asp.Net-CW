using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.ServiceType;

namespace Contracts.Logic
{
    public interface IServiceTypeLogic
    {
        Task<IEnumerable<ServiceTypeDto>> GetServiceTypesAsync(Guid serviceDateInfoId);
        Task<ServiceTypeDto> GetServiceTypeAsync(Guid id, Guid serviceDateInfoId);
        Task<ServiceTypeDto> GetServiceTypeAsync(Guid id);
        Task CreateServiceTypeForServiceDateInfoAsync(Guid serviceDateInfoId, ServiceTypeForCreateDto serviceTypeDto);
        Task DeleteServiceTypeAsync(ServiceTypeDto serviceTypeDto);
        Task UpdateServiceTypeAsync(Guid id, Guid serviceDateInfoId, ServiceTypeForUpdateDto serviceTypeDto);
    }
}
