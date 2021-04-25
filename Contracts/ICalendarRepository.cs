using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface ICalendarRepository
    {
        Task<IEnumerable<Calendar>> GetCalendarsAsync(CalendarParameters calendarParameters, bool trackChanges);
        Task<Calendar> GetCalendarAsync(Guid id, bool trackChanges);
        void CreateCalendar(Calendar calendar);
        void DeleteCalendar(Calendar calendar);
    }
}
