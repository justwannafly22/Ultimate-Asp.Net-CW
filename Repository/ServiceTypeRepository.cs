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
    public class ServiceTypeRepository : RepositoryBase<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        
        public void CreateServiceTypeForServiceDateInfo(ServiceType serviceType, Guid serviceDateInfoId)
        {
            serviceType.ServiceDateInfoId = serviceDateInfoId;
            Create(serviceType);
        }

        public void DeleteServiceType(ServiceType serviceType) =>
            Delete(serviceType);

        public async Task<ServiceType> GetServiceTypeAsync(Guid id, Guid serviceDateInfoId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id) && s.ServiceDateInfoId.Equals(serviceDateInfoId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<ServiceType> GetServiceTypeAsync(Guid id, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<ServiceType>> GetServiceTypesAsync(Guid serviceDateInfoId, bool trackChanges) =>
            await FindByCondition(s => s.ServiceDateInfoId.Equals(serviceDateInfoId), trackChanges)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
