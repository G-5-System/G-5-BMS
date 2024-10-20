using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G_5_BMS.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BNature",
                table: "Clearances",
                newName: "BusinessNature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusinessNature",
                table: "Clearances",
                newName: "BNature");
        }
    }
}
