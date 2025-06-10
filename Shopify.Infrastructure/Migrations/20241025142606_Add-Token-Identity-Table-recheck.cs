using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supliex.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenIdentityTablerecheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "663ecf5e-6cc4-417e-a4a9-6ef8881fe1d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea81144a-8270-484f-80a8-6cb6a89beb22");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ac301c1-93ad-4673-accc-e242742a3270", null, "Admin", "ADMIN" },
                    { "6fc6ffe7-2e07-499b-969b-e260fddcf705", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac301c1-93ad-4673-accc-e242742a3270");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc6ffe7-2e07-499b-969b-e260fddcf705");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "663ecf5e-6cc4-417e-a4a9-6ef8881fe1d1", null, "Admin", "ADMIN" },
                    { "ea81144a-8270-484f-80a8-6cb6a89beb22", null, "User", "USER" }
                });
        }
    }
}
