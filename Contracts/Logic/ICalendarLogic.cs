using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DTO.Calendar;
using Entities.RequestFeatures;

namespace Contracts.Logic
{
    public interface ICalendarLogic
    {
        Task<IEnumerable<CalendarDto>> GetCalendarsAsync(CalendarParameters calendarParameters);
        Task<CalendarDto> GetCalendarAsync(Guid id);
        Task CreateCalendarAsync(CalendarForCreateDto calendarDto);
        Task DeleteCalendarAsync(CalendarDto calendarDto);
        Task UpdateCalendarAsync(Guid id, CalendarForUpdateDto calendarDto);
    }
}
