using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMHaulage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(maxLength: 255, nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: false),
                    Driver = table.Column<string>(maxLength: 100, nullable: false),
                    Vehicle = table.Column<string>(maxLength: 30, nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
