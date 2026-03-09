using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace saborperu.Migrations
{
    /// <inheritdoc />
    public partial class FixDataBaseV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponile",
                table: "Platos",
                newName: "Disponible");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Disponible",
                table: "Platos",
                newName: "Disponile");
        }
    }
}
