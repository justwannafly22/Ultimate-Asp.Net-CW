using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private DiagnosRepository _diagnosRepository;
        private PatientRepository _patientRepository;
        private ServiceDateInfoRepository _serviceDateInfoRepository;
        private CalendarRepository _calendarRepository;
        private ServiceTypeRepository _serviceTypeRepository;
        private ServiceRepository _serviceRepository;
        private EmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IEmployeeRepository Employee 
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }

        public IDiagnosRepository Diagnos
        {
            get
            {
                if (_diagnosRepository == null)
                    _diagnosRepository = new DiagnosRepository(_repositoryContext);
                return _diagnosRepository;
            }
        }

        public IPatientRepository Patient
        {
            get
            {
                if (_patientRepository == null)
                    _patientRepository = new PatientRepository(_repositoryContext);
                return _patientRepository;
            }
        }

        public IServiceDateInfo ServiceDateInfo
        {
            get
            {
                if (_serviceDateInfoRepository == null)
                    _serviceDateInfoRepository = new ServiceDateInfoRepository(_repositoryContext);
                return _serviceDateInfoRepository;
            }
        }

        public ICalendarRepository Calendar
        {
            get
            {
                if (_calendarRepository == null)
                    _calendarRepository = new CalendarRepository(_repositoryContext);
                return _calendarRepository;
            }
        }

        public IServiceTypeRepository ServiceType
        {
            get
            {
                if (_serviceTypeRepository == null)
                    _serviceTypeRepository = new ServiceTypeRepository(_repositoryContext);
                return _serviceTypeRepository;
            }
        }

        public IServiceRepository Service
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new ServiceRepository(_repositoryContext);
                return _serviceRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

    }
}
