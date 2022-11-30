using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Orgination_position_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "JobTitle",
                newName: "JobTitle",
                newSchema: "HRM");

            migrationBuilder.RenameTable(
                name: "JobPosition",
                newName: "JobPosition",
                newSchema: "HRM");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HRM",
                table: "JobTitle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                schema: "HRM",
                table: "JobTitle",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "JobTitle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HRM",
                table: "JobPosition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                schema: "HRM",
                table: "JobPosition",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "JobPosition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "DecisionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Decision",
                schema: "HRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplyDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExperiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decision_DecisionType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DecisionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Decision_Employee_DecisionMakerId",
                        column: x => x.DecisionMakerId,
                        principalSchema: "HRM",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Decision_Employee_DecisionReceiverId",
                        column: x => x.DecisionReceiverId,
                        principalSchema: "HRM",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_DecisionId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_EmployeeId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_OrganizationId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_DecisionMakerId",
                schema: "HRM",
                table: "Decision",
                column: "DecisionMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_DecisionReceiverId",
                schema: "HRM",
                table: "Decision",
                column: "DecisionReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_TypeId",
                schema: "HRM",
                table: "Decision",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_Decision_DecisionId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "DecisionId",
                principalSchema: "HRM",
                principalTable: "Decision",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_Employee_EmployeeId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "EmployeeId",
                principalSchema: "HRM",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_Employee_EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "EmployeesId",
                principalSchema: "HRM",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPosition_Organization_OrganizationId",
                schema: "HRM",
                table: "OrganizationPosition",
                column: "OrganizationId",
                principalSchema: "HRM",
                principalTable: "Organization",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Decision_DecisionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Employee_EmployeeId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Employee_EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Organization_OrganizationId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropTable(
                name: "Decision",
                schema: "HRM");

            migrationBuilder.DropTable(
                name: "DecisionType");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPosition_DecisionId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPosition_EmployeeId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPosition_EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPosition_OrganizationId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.RenameTable(
                name: "JobTitle",
                schema: "HRM",
                newName: "JobTitle");

            migrationBuilder.RenameTable(
                name: "JobPosition",
                schema: "HRM",
                newName: "JobPosition");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobTitle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                table: "JobTitle",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "JobTitle",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobPosition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                table: "JobPosition",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "JobPosition",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");
        }
    }
}
