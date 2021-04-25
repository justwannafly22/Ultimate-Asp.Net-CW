using Entities.Models;
using System;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;
using System.Linq;

namespace Repository.Extensions
{
    public static class RepositoryDiagnosExtentions
    {
        public static IQueryable<Diagnos> Search(this IQueryable<Diagnos> diagnoses, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return diagnoses;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return diagnoses.Where(d => d.Name.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Diagnos> Sort(this IQueryable<Diagnos> diagnoses, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return diagnoses.OrderBy(d => d.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Diagnos>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return diagnoses.OrderBy(d => d.Name);

            return diagnoses.OrderBy(orderQuery);
        }
    }
}
