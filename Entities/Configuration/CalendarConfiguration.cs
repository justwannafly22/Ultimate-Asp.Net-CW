using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.HasData(
                new Calendar
                {
                    Id = new Guid("80abbca8-554d-4b16-b5de-024705497d4a"),
                    Date = new DateTime(2021, 4, 16)
                },
                new Calendar
                {
                    Id = new Guid("80abbca8-554d-4b17-b5de-024705497d4a"),
                    Date = new DateTime(2021, 4, 17)
                },
                new Calendar
                {
                    Id = new Guid("80abbca8-554d-4b18-b5de-024705497d4a"),
                    Date = new DateTime(2021, 4, 18)
                }
                );
        }
    }
}
