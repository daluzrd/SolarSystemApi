using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    public partial class AddDescriptionColumnToPlanetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planet_SolarSytem_SolarSystemId",
                table: "Planet");

            migrationBuilder.DropTable(
                name: "SolarSytem");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Planet",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SolarSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystem", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Planet_SolarSystem_SolarSystemId",
                table: "Planet",
                column: "SolarSystemId",
                principalTable: "SolarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planet_SolarSystem_SolarSystemId",
                table: "Planet");

            migrationBuilder.DropTable(
                name: "SolarSystem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Planet");

            migrationBuilder.CreateTable(
                name: "SolarSytem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSytem", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Planet_SolarSytem_SolarSystemId",
                table: "Planet",
                column: "SolarSystemId",
                principalTable: "SolarSytem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}