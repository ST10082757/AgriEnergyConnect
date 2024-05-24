using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agriEnergy.Migrations.FarmerDb
{
    /// <inheritdoc />
    public partial class FarmersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Farmers",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                   email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                   password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                   role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "RoleNameHere") // Change the default value as needed
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Farmers", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Farmers");
        }
    }
}