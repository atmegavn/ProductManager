using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Orgination_position_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_JobPosition_JobPositionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                schema: "HRM",
                table: "OrganizationPosition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_PositionId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_JobPosition_PositionId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "PositionId",
                principalSchema: "HRM",
                principalTable: "JobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_JobPosition_PositionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPosition_PositionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_JobPosition_JobPositionId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "JobPositionId",
                principalSchema: "HRM",
                principalTable: "JobPosition",
                principalColumn: "Id");
        }
    }
}
