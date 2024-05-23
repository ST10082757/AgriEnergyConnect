using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agriEnergy.Migrations.ProductsDb
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    imageFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsDetails");
        }
    }
}
