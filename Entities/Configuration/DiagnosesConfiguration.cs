using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class DiagnosesConfiguration : IEntityTypeConfiguration<Diagnos>
    {
        public void Configure(EntityTypeBuilder<Diagnos> builder)
        {
            builder.HasData(
                new Diagnos
                {
                    Id = new Guid("80abbca8-554d-4b20-b5de-024705497d4a"),
                    Name = "Gigantism",
                    DateOfDiagnosis = new DateTime(2021, 4, 16),
                    Treatment = "Smoking",
                    CourseOfDisease = "+ 4 cm",
                    PatientId = new Guid("81abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Diagnos
                {
                    Id = new Guid("81abbca8-444d-4b20-b5de-024705497d4a"),
                    Name = "Migraine",
                    DateOfDiagnosis = new DateTime(2021, 4, 16),
                    Treatment = "More sleeping",
                    CourseOfDisease = "Without changes",
                    PatientId = new Guid("81abbca8-664d-4b20-b5de-024705497d4a")
                }
                );
        }
    }
}
