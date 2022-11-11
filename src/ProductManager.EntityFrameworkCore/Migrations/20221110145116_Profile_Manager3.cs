using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Profile_Manager3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relative_Profile_PersonId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                schema: "HRM",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Relative_ProfileId",
                schema: "HRM",
                table: "Relative",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relative_Profile_PersonId",
                schema: "HRM",
                table: "Relative",
                column: "PersonId",
                principalSchema: "HRM",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relative_Profile_ProfileId",
                schema: "HRM",
                table: "Relative",
                column: "ProfileId",
                principalSchema: "HRM",
                principalTable: "Profile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relative_Profile_PersonId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropForeignKey(
                name: "FK_Relative_Profile_ProfileId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropIndex(
                name: "IX_Relative_ProfileId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                schema: "HRM",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Relative_Profile_PersonId",
                schema: "HRM",
                table: "Relative",
                column: "PersonId",
                principalSchema: "HRM",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
