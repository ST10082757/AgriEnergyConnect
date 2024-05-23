using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace agriEnergy.Migrations
{
    /// <inheritdoc />
    public partial class SecondInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98a26ee7-db3f-4339-9f7d-bb9b3fce7aa0", null, "farmer", "farmer" },
                    { "dde8d8ab-246a-45bb-9fc0-e5aa1b845ce9", null, "employee", "employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98a26ee7-db3f-4339-9f7d-bb9b3fce7aa0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dde8d8ab-246a-45bb-9fc0-e5aa1b845ce9");
        }
    }
}
