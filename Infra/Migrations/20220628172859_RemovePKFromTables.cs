using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    public partial class RemovePKFromTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planet_SolarSystem_SolarSystemId",
                table: "Planet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolarSystem",
                table: "SolarSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planet",
                table: "Planet");

            migrationBuilder.DropIndex(
                name: "IX_Planet_SolarSystemId",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SolarSystem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "SolarSystemId",
                table: "Planet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SolarSystem",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Planet",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "SolarSystemId",
                table: "Planet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolarSystem",
                table: "SolarSystem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planet",
                table: "Planet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planet_SolarSystemId",
                table: "Planet",
                column: "SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planet_SolarSystem_SolarSystemId",
                table: "Planet",
                column: "SolarSystemId",
                principalTable: "SolarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
