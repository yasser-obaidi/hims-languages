using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HimsLanguages.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LocaleStringResource");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LocaleStringResource",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
