using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supliex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changeintestmodel1rebository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76dcbca8-63ed-4a26-8aca-7b1a21bd5e3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897f6558-4598-4a9f-9535-c6653a856586");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5612b5e1-e073-4db5-a277-2e337b474c84", null, "Admin", "ADMIN" },
                    { "e10d4347-c75f-4c17-b320-7b5e601b4cad", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5612b5e1-e073-4db5-a277-2e337b474c84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e10d4347-c75f-4c17-b320-7b5e601b4cad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76dcbca8-63ed-4a26-8aca-7b1a21bd5e3f", null, "Admin", "ADMIN" },
                    { "897f6558-4598-4a9f-9535-c6653a856586", null, "User", "USER" }
                });
        }
    }
}
