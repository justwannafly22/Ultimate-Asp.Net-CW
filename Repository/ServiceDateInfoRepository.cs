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
    public class ServiceDateInfoRepository : RepositoryBase<ServiceDateInfo>, IServiceDateInfo
    {
        public ServiceDateInfoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateServiceDateInfoForCalendar(Guid calendarId, ServiceDateInfo serviceDateInfo)
        {
            serviceDateInfo.CalendarId = calendarId;
            Create(serviceDateInfo);
        }

        public void DeleteServiceDateInfo(ServiceDateInfo serviceDateInfo) =>
            Delete(serviceDateInfo);

        public async Task<ServiceDateInfo> GetServiceDateInfo(Guid id, Guid calendarId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id) && s.CalendarId.Equals(calendarId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<ServiceDateInfo> GetServiceDateInfo(Guid id, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<ServiceDateInfo>> GetServicesDatesInfo(Guid calendarId, bool trackChanges) =>
            await FindByCondition(s => s.CalendarId.Equals(calendarId), trackChanges)
            .OrderBy(s => s.Date)
            .ToListAsync();
    }
}
