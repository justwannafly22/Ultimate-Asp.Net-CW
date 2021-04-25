using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasData(
                new ServiceType
                {
                    Id = new Guid("80gkgca8-554d-4a16-b5de-024705497d4a"),
                    Description = "Consultation and procedure",
                    Name = "ServiceTypeOne",
                    ServiceDateInfoId = new Guid("80abbca8-554d-4a16-b5de-024705497d4a")
                },
                new ServiceType
                {
                    Id = new Guid("80gagca8-554d-4a16-b5de-024705497d4a"),
                    Description = "Consultation and procedure",
                    Name = "ServiceTypeTwo",
                    ServiceDateInfoId = new Guid("80abbca8-554d-4b17-b5de-024705497d4a")
                }
                );
        }
    }
}
