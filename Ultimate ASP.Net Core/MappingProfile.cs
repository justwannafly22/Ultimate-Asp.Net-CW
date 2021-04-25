using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using AutoMapper;
using Entities.DTO.Diagnos;
using Entities.DTO.Patient;
using Entities.DTO.ServiceDateInfo;
using Entities.DTO.Calendar;
using Entities.DTO.ServiceType;
using Entities.DTO.Service;
using Entities.DTO.Employee;
using Entities.DTO.User;

namespace Ultimate_ASP.Net_Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Employee
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<EmployeeForCreateDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            #endregion

            #region Diagnos
            CreateMap<Diagnos, DiagnosDto>().ReverseMap();

            CreateMap<DiagnosForCreateDto, Diagnos>();

            CreateMap<DiagnosForUpdateDto, Diagnos>().ReverseMap();
            #endregion

            #region Patient
            CreateMap<Patient, PatientDto>().ReverseMap();

            CreateMap<PatientForCreateDto, Patient>();

            CreateMap<PatientForUpdateDto, Patient>().ReverseMap();
            #endregion

            #region ServiceDateInfo
            CreateMap<ServiceDateInfo, ServiceDateInfoDto>().ReverseMap();

            CreateMap<ServiceDateInfoForCreateDto, ServiceDateInfo>();

            CreateMap<ServiceDateInfoForUpdateDto, ServiceDateInfo>().ReverseMap();
            #endregion

            #region Calendar
            CreateMap<Calendar, CalendarDto>().ReverseMap();

            CreateMap<CalendarForCreateDto, Calendar>();

            CreateMap<CalendarForUpdateDto, Calendar>().ReverseMap();
            #endregion

            #region ServiceType
            CreateMap<ServiceType, ServiceTypeDto>().ReverseMap();

            CreateMap<ServiceTypeForCreateDto, ServiceType>();

            CreateMap<ServiceTypeForUpdateDto, ServiceType>().ReverseMap();
            #endregion

            #region Service
            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<ServiceForCreateDto, Service>();

            CreateMap<ServiceForUpdateDto, Service>().ReverseMap();
            #endregion

            #region User
            CreateMap<UserForRegistrationDto, User>();
            #endregion

        }

    }
}
