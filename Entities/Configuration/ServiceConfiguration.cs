using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service
                {
                    Id = new Guid("80gggc90-55hh-4a16-b5de-024705497d4a"),
                    Name = "Consultation",
                    Price = 25,
                    ServiceTypeId = new Guid("80gkgca8-554d-4a16-b5de-024705497d4a")
                },
                new Service
                {
                    Id = new Guid("80gggkl8-55hk-4a16-b5de-024705497d4a"),
                    Name = "Procedure",
                    Price = 125,
                    ServiceTypeId = new Guid("80gkgca8-554d-4a16-b5de-024705497d4a")
                }
                );
        }
    }
}
