using Microsoft.EntityFrameworkCore.Migrations;

namespace Ultimate_ASP.Net_Core.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb8d9b08-18a4-4a45-ab62-ce910b877ff9", "d61dfc23-6137-429d-88e0-160f384c2c45", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e5373eb-af5b-4051-badd-8397f4eee92c", "5e4f5eaf-d0bf-446a-a748-7ccec6d189dc", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5976f256-2702-40fe-aae7-54bb0b787c92", "bb66273f-5dc6-46dc-9c0e-791521174539", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5976f256-2702-40fe-aae7-54bb0b787c92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e5373eb-af5b-4051-badd-8397f4eee92c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb8d9b08-18a4-4a45-ab62-ce910b877ff9");
        }
    }
}
