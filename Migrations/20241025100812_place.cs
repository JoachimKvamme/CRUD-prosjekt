using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_prosjekt.Migrations
{
    /// <inheritdoc />
    public partial class place : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Books");
        }
    }
}
