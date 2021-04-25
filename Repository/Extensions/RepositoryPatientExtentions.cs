using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryPatientExtentions
    {
        public static IQueryable<Patient> FilterPatients(this IQueryable<Patient> patients, uint minAge, uint maxAge) =>
            patients.Where(p => (p.Age > minAge && p.Age < maxAge));

        public static IQueryable<Patient> Search(this IQueryable<Patient> patients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return patients;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return patients.Where(p => p.Name.ToLower().Contains(searchTerm));
        }
        
        public static IQueryable<Patient> Sort(this IQueryable<Patient> patients, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return patients.OrderBy(p => p.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Patient>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return patients.OrderBy(p => p.Name);

            return patients.OrderBy(orderQuery);
        }
    }
}
