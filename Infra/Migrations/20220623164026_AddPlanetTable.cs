using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    public partial class AddPlanetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HasLife = table.Column<bool>(type: "boolean", nullable: false),
                    Circumference = table.Column<double>(type: "double precision", nullable: false),
                    Population = table.Column<int>(type: "integer", nullable: false),
                    SolarSystemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planet_SolarSytem_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSytem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planet_SolarSystemId",
                table: "Planet",
                column: "SolarSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planet");
        }
    }
}