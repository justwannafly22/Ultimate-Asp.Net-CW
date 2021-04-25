using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Logic;
using Entities.Models;
using Repository;
using AutoMapper;
using Entities.DTO.Calendar;
using Contracts;
using Entities.RequestFeatures;

namespace BLL
{
    public class CalendarLogic : ICalendarLogic
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CalendarLogic(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task CreateCalendarAsync(CalendarForCreateDto calendarDto)
        {
            var calendarEntity = _mapper.Map<Calendar>(calendarDto);

            _repositoryManager.Calendar.CreateCalendar(calendarEntity);
            await _repositoryManager.SaveAsync();
        }


        public async Task DeleteCalendarAsync(CalendarDto calendarDto)
        {
            var calendarEntity = _mapper.Map<Calendar>(calendarDto);

            _repositoryManager.Calendar.DeleteCalendar(calendarEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<CalendarDto> GetCalendarAsync(Guid id)
        {
            var calendarEntity = await _repositoryManager.Calendar.GetCalendarAsync(id, trackChanges: false);

            var calendarDto = _mapper.Map<CalendarDto>(calendarEntity);

            return calendarDto;
        }

        public async Task<IEnumerable<CalendarDto>> GetCalendarsAsync(CalendarParameters calendarParameters)
        {
            var calendarEntities = await _repositoryManager.Calendar.GetCalendarsAsync(calendarParameters, trackChanges: false);

            var calendarDtoList = _mapper.Map<IEnumerable<CalendarDto>>(calendarEntities);

            return calendarDtoList;
        }

        public async Task UpdateCalendarAsync(Guid id, CalendarForUpdateDto calendarDto)
        {
            var calendarEntity = await _repositoryManager.Calendar.GetCalendarAsync(id, trackChanges: true);

            _mapper.Map(calendarDto, calendarEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}
