using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiringForm.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCalledToInterview",
                table: "Applicants",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEliminated",
                table: "Applicants",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCalledToInterview",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "IsEliminated",
                table: "Applicants");
        }
    }
}
