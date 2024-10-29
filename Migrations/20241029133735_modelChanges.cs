using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_prosjekt.Migrations
{
    /// <inheritdoc />
    public partial class modelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "470b1546-59f8-4d0e-b1e0-4e30146f73ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d74e2e61-4e77-4863-9085-17600c5c394b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d3b4ea4-ffe2-4769-ba16-208deba718ce", null, "User", "USER" },
                    { "b0b5e20d-ba28-4214-8dd3-feb4b381e0c1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d3b4ea4-ffe2-4769-ba16-208deba718ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0b5e20d-ba28-4214-8dd3-feb4b381e0c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "470b1546-59f8-4d0e-b1e0-4e30146f73ce", null, "Admin", "ADMIN" },
                    { "d74e2e61-4e77-4863-9085-17600c5c394b", null, "User", "USER" }
                });
        }
    }
}
