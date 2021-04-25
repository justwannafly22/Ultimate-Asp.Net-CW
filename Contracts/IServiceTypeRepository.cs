using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IServiceTypeRepository
    {
        Task<IEnumerable<ServiceType>> GetServiceTypesAsync(Guid serviceDateInfoId, bool trackChanges);
        Task<ServiceType> GetServiceTypeAsync(Guid id, Guid serviceDateInfoId, bool trackChanges);
        Task<ServiceType> GetServiceTypeAsync(Guid id, bool trackChanges);
        void CreateServiceTypeForServiceDateInfo(ServiceType serviceType, Guid serviceDateInfoId);
        void DeleteServiceType(ServiceType serviceType);
    }
}
