using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ultimate_ASP.Net_Core.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "ServiceDatesInfo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "Description", "Name", "ServiceDateInfoId" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 19, "Headache", "Andrey", null });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Age", "Description", "Name", "ServiceDateInfoId" },
                values: new object[] { new Guid("81abbca8-664d-4b20-b5de-024705497d4a"), 19, "Headache", "Alex", null });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "DiagnosId", "CourseOfDisease", "DateOfDiagnosis", "Name", "PatientId", "Treatment" },
                values: new object[] { new Guid("80abbca8-554d-4b20-b5de-024705497d4a"), "+ 4 cm", new DateTime(2021, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gigantism", new Guid("81abbca8-664d-4b20-b5de-024705497d4a"), "Smoking" });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "DiagnosId", "CourseOfDisease", "DateOfDiagnosis", "Name", "PatientId", "Treatment" },
                values: new object[] { new Guid("81abbca8-444d-4b20-b5de-024705497d4a"), "Without changes", new DateTime(2021, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migraine", new Guid("81abbca8-664d-4b20-b5de-024705497d4a"), "More sleeping" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "DiagnosId",
                keyValue: new Guid("80abbca8-554d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Diagnoses",
                keyColumn: "DiagnosId",
                keyValue: new Guid("81abbca8-444d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("81abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "ServiceDatesInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
