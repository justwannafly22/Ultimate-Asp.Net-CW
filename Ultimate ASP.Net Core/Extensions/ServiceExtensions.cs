using BLL;
using Contracts;
using Contracts.Logic;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultimate_ASP.Net_Core.ActionFilters;

namespace Ultimate_ASP.Net_Core.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
                
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("Ultimate ASP.Net Core")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureLogic(this IServiceCollection services)
        {
            services.AddScoped<IDiagnosLogic, DiagnosLogic>();
            services.AddScoped<IPatientLogic, PatientLogic>();
            services.AddScoped<IServiceDateInfoLogic, ServiceDateInfoLogic>();
            services.AddScoped<ICalendarLogic, CalendarLogic>();
            services.AddScoped<IServiceTypeLogic, ServiceTypeLogic>();
            services.AddScoped<IServiceLogic, ServiceLogic>();
            services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        }

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidatePatientExistAttribute>();
            services.AddScoped<ValidateDiagnosForPatientExistAttribute>();
            services.AddScoped<ValidateServiceDateInfoForCalendarExistAttribute>();
            services.AddScoped<ValidateCalendarExistAttribute>();
            services.AddScoped<ValidateServiceTypeForServiceDateInfoExistAttribute>();
            services.AddScoped<ValidateServiceDateInfoExistAttribute>();
            services.AddScoped<ValidateServiceTypeExistAttribute>();
            services.AddScoped<ValidateServiceForServiceTypeExistAttribute>();
            services.AddScoped<ValidateServiceExistAttribute>();
            services.AddScoped<ValidateEmployeeForServiceExistAttribute>();
        }
        
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("validAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

    }
}
