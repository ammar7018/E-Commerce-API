using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supliex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changeintestmodelrebository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ed63342-7314-417c-b708-bf839c2eb0de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c97852b-a0eb-4e13-913f-f4529a37bb68");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76dcbca8-63ed-4a26-8aca-7b1a21bd5e3f", null, "Admin", "ADMIN" },
                    { "897f6558-4598-4a9f-9535-c6653a856586", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76dcbca8-63ed-4a26-8aca-7b1a21bd5e3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897f6558-4598-4a9f-9535-c6653a856586");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ed63342-7314-417c-b708-bf839c2eb0de", null, "Admin", "ADMIN" },
                    { "4c97852b-a0eb-4e13-913f-f4529a37bb68", null, "User", "USER" }
                });
        }
    }
}
