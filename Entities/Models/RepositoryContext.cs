using Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities.Models
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DiagnosesConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceDateInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CalendarConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<Patient>()
                .HasOne(s => s.ServiceDateInfo)
                .WithOne(p => p.Patient)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServiceType>()
                .HasOne(s => s.ServiceDateInfo)
                .WithMany(t => t.ServiceTypes)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.ServiceType)
                .WithMany(a => a.Services)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasOne(s => s.Service)
                .WithMany(a => a.Employees)
                .OnDelete(DeleteBehavior.SetNull);
        }
        
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<ServiceDateInfo> ServiceDatesInfo { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnos> Diagnoses { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
