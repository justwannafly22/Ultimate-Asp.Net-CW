using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class ServiceDateInfoConfiguration : IEntityTypeConfiguration<ServiceDateInfo>
    {
        public void Configure(EntityTypeBuilder<ServiceDateInfo> builder)
        {
            builder.HasData(
                new ServiceDateInfo
                {
                    Id = new Guid("80abbca8-554d-4a16-b5de-024705497d4a"),
                    Date = new DateTime(2021, 4, 16),
                    Description = "The patient has headache complaints",
                    CalendarId = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    PatientId = null
                },
                new ServiceDateInfo
                {
                    Id = new Guid("80abbca8-554d-4a17-b5de-024705497d4a"),
                    Date = new DateTime(2021, 4, 17),
                    Description = "The patient has headache complaints",
                    CalendarId = new Guid("80abbca8-554d-4b17-b5de-024705497d4a"),
                    PatientId = null
                }
                );
        }
    }
}
