using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THConfigUpdater.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomOperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomOperations",
                table: "FileBasedConfigs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomOperations",
                table: "FileBasedConfigs");
        }
    }
}
