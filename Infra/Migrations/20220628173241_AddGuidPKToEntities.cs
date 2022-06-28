using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddGuidPKToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SolarSystem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Planet",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SolarSystemId",
                table: "Planet",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
