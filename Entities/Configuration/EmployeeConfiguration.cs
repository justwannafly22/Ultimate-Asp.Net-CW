using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("80abda8-554d-4b16-b5de-024705497d4a"),
                    Name = "Alexey Sergeevich",
                    Age = 45,
                    Speciality = "Surgeon",
                    ServiceId = new Guid("80gggkl8-55hk-4a16-b5de-024705497d4a")
                },
                new Employee
                {
                    Id = new Guid("80ablda8-554d-4b16-b5de-024705497d4a"),
                    Name = "Tatyana Tatyanovna",
                    Age = 45,
                    Speciality = "Nurse",
                    ServiceId = new Guid("80gggkl8-55hk-4a16-b5de-024705497d4a")
                }
                );
        }
    }
}
