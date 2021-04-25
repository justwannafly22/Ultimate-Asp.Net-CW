using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IDiagnosRepository Diagnos { get; }
        IPatientRepository Patient { get; }
        IServiceDateInfo ServiceDateInfo { get; }
        ICalendarRepository Calendar { get; }
        IServiceTypeRepository ServiceType { get; }
        IServiceRepository Service { get; }
        IEmployeeRepository Employee { get; }
        
        Task SaveAsync();
    }
}
