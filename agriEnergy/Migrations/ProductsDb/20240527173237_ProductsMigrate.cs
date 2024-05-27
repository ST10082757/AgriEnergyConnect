using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agriEnergy.Migrations.ProductsDb
{
    /// <inheritdoc />
    public partial class ProductsMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "imageFileName",
            //    table: "ProductsDetails");

            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "ProductsDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userID",
                table: "ProductsDetails");

            //migrationBuilder.AddColumn<string>(
            //    name: "imageFileName",
            //    table: "ProductsDetails",
            //    type: "nvarchar(100)",
            //    maxLength: 100,
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
