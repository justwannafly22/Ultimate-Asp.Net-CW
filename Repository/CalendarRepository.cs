using System;
using System.Collections.Generic;
using Entities.Models;
using Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Entities.RequestFeatures;

namespace Repository
{
    public class CalendarRepository : RepositoryBase<Calendar>, ICalendarRepository
    {
        public CalendarRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateCalendar(Calendar calendar) =>
            Create(calendar);

        public void DeleteCalendar(Calendar calendar) =>
            Delete(calendar);

        public async Task<Calendar> GetCalendarAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Calendar>> GetCalendarsAsync(CalendarParameters calendarParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .Search(calendarParameters.SearchTerm)
            .Sort(calendarParameters.OrderBy)
            .ToListAsync();
    }
}
