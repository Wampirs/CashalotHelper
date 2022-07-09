using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashalotHelper.Migrations
{
    public partial class AddCashalotBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashalotBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    RemoteFolderPath = table.Column<string>(type: "TEXT", nullable: false),
                    LocalFolderPath = table.Column<string>(type: "TEXT", nullable: false),
                    LocalBatFile = table.Column<string>(type: "TEXT", nullable: false),
                    LocalExeFile = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashalotBranches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashalotBranches");
        }
    }
}
