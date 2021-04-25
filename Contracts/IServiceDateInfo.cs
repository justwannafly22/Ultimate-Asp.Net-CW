using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IServiceDateInfo
    {
        Task<IEnumerable<ServiceDateInfo>> GetServicesDatesInfo(Guid calendarId, bool trackChanges);
        Task<ServiceDateInfo> GetServiceDateInfo(Guid id, Guid calendarId, bool trackChanges);
        Task<ServiceDateInfo> GetServiceDateInfo(Guid id, bool trackChanges);
        void CreateServiceDateInfoForCalendar(Guid calendarId, ServiceDateInfo serviceDateInfo);
        void DeleteServiceDateInfo(ServiceDateInfo serviceDateInfo);
    }
}
