using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPersonalInfoSummaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summry",
                table: "PersonalInfos",
                newName: "Summary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "PersonalInfos",
                newName: "Summry");
        }
    }
}
