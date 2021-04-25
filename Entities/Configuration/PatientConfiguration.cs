using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(
                new Patient
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Andrey",
                    Age = 19,
                    Description = "Headache",
                    ServiceDateInfoId = null
                },
                new Patient
                {
                    Id = new Guid("81abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Alex",
                    Age = 19,
                    Description = "Headache",
                    ServiceDateInfoId = null
                }
                );
        }
    }
}
