using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace THConfigUpdater.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileBasedConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileBasedConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    Sha256 = table.Column<string>(type: "TEXT", nullable: false),
                    ClientPath = table.Column<string>(type: "TEXT", nullable: false),
                    ServerPath = table.Column<string>(type: "TEXT", nullable: true),
                    ServerUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FileBasedConfigId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigFiles_FileBasedConfigs_FileBasedConfigId",
                        column: x => x.FileBasedConfigId,
                        principalTable: "FileBasedConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigFiles_FileBasedConfigId",
                table: "ConfigFiles",
                column: "FileBasedConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigFiles");

            migrationBuilder.DropTable(
                name: "FileBasedConfigs");
        }
    }
}
