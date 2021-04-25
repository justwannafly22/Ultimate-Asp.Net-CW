using System;
using System.Collections.Generic;
using Entities.Models;
using Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateServiceForServiceType(Service service, Guid serviceTypeId)
        {
            service.ServiceTypeId = serviceTypeId;
            Create(service);
        }

        public void DeleteService(Service service) =>
            Delete(service);

        public async Task<Service> GetServiceAsync(Guid id, Guid serviceTypeId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id) && s.ServiceTypeId.Equals(serviceTypeId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Service> GetServiceAsync(Guid id, bool trackChanges) =>
           await FindByCondition(s => s.Id.Equals(id), trackChanges)
           .SingleOrDefaultAsync();

        public async Task<IEnumerable<Service>> GetServicesAsync(Guid serviceTypeId, bool trackChanges) =>
            await FindByCondition(s => s.ServiceTypeId.Equals(serviceTypeId), trackChanges)
            .ToListAsync();
    }
}
