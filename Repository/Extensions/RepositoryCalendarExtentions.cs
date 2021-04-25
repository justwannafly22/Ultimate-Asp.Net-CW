using Entities.Models;
using System;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;
using System.Linq;


namespace Repository.Extensions
{
    public static class RepositoryCalendarExtentions
    {
        public static IQueryable<Calendar> Search(this IQueryable<Calendar> calendars, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return calendars;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return calendars.Where(c => c.Date.ToString().ToLower().Contains(searchTerm));
        }

        public static IQueryable<Calendar> Sort(this IQueryable<Calendar> calendars, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return calendars.OrderBy(d => d.Date);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Calendar>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return calendars.OrderBy(d => d.Date);

            return calendars.OrderBy(orderQuery);
        }

    }
}
