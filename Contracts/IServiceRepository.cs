using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServicesAsync(Guid serviceTypeId, bool trackChanges);
        Task<Service> GetServiceAsync(Guid id, Guid serviceTypeId, bool trackChanges);
        Task<Service> GetServiceAsync(Guid id, bool trackChanges);
        void CreateServiceForServiceType(Service service, Guid serviceTypeId);
        void DeleteService(Service service);
    }
}
