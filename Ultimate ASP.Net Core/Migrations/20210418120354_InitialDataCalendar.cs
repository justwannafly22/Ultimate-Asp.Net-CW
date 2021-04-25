using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ultimate_ASP.Net_Core.Migrations
{
    public partial class InitialDataCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Calendar",
                columns: new[] { "CalendarId", "Date" },
                values: new object[] { new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), new DateTime(2021, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Calendar",
                columns: new[] { "CalendarId", "Date" },
                values: new object[] { new Guid("80abbca8-554d-4b17-b5de-024705497d4a"), new DateTime(2021, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Calendar",
                columns: new[] { "CalendarId", "Date" },
                values: new object[] { new Guid("80abbca8-554d-4b18-b5de-024705497d4a"), new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ServiceDatesInfo",
                columns: new[] { "ServiceDateInfoId", "CalendarId", "Date", "Description", "PatientId" },
                values: new object[] { new Guid("80abbca8-554d-4a16-b5de-024705497d4a"), new Guid("80abbca8-554d-4b16-b5de-024705497d4a"), new DateTime(2021, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The patient has headache complaints", null });

            migrationBuilder.InsertData(
                table: "ServiceDatesInfo",
                columns: new[] { "ServiceDateInfoId", "CalendarId", "Date", "Description", "PatientId" },
                values: new object[] { new Guid("80abbca8-554d-4a17-b5de-024705497d4a"), new Guid("80abbca8-554d-4b17-b5de-024705497d4a"), new DateTime(2021, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The patient has headache complaints", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calendar",
                keyColumn: "CalendarId",
                keyValue: new Guid("80abbca8-554d-4b18-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "ServiceDatesInfo",
                keyColumn: "ServiceDateInfoId",
                keyValue: new Guid("80abbca8-554d-4a16-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "ServiceDatesInfo",
                keyColumn: "ServiceDateInfoId",
                keyValue: new Guid("80abbca8-554d-4a17-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Calendar",
                keyColumn: "CalendarId",
                keyValue: new Guid("80abbca8-554d-4b16-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Calendar",
                keyColumn: "CalendarId",
                keyValue: new Guid("80abbca8-554d-4b17-b5de-024705497d4a"));
        }
    }
}
