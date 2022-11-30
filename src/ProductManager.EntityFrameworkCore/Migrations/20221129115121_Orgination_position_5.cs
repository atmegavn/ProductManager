using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Orgination_position_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrganizationPosition_Employee_EmployeesId",
            //    schema: "HRM",
            //    table: "OrganizationPosition");

            migrationBuilder.RenameTable(
                name: "Relationship",
                newName: "Relationship",
                newSchema: "HRM");

            migrationBuilder.RenameTable(
                name: "DecisionType",
                newName: "DecisionType",
                newSchema: "HRM");

            //migrationBuilder.RenameColumn(
            //    name: "EmployeesId",
            //    schema: "HRM",
            //    table: "OrganizationPosition",
            //    newName: "EmployeeId1");

            //migrationBuilder.RenameIndex(
            //    name: "IX_OrganizationPosition_EmployeesId",
            //    schema: "HRM",
            //    table: "OrganizationPosition",
            //    newName: "IX_OrganizationPosition_EmployeeId1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HRM",
                table: "Relationship",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                schema: "HRM",
                table: "Relationship",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "Relationship",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "HRM",
                table: "DecisionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                schema: "HRM",
                table: "DecisionType",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "DecisionType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrganizationPosition_Employee_EmployeeId1",
            //    schema: "HRM",
            //    table: "OrganizationPosition",
            //    column: "EmployeeId1",
            //    principalSchema: "HRM",
            //    principalTable: "Employee",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Employee_EmployeeId1",
                schema: "HRM",
                table: "OrganizationPosition");

            migrationBuilder.RenameTable(
                name: "Relationship",
                schema: "HRM",
                newName: "Relationship");

            migrationBuilder.RenameTable(
                name: "DecisionType",
                schema: "HRM",
                newName: "DecisionType");

            migrationBuilder.RenameColumn(
                name: "EmployeeId1",
                schema: "HRM",
                table: "OrganizationPosition",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationPosition_EmployeeId1",
                schema: "HRM",
                table: "OrganizationPosition",
                newName: "IX_OrganizationPosition_EmployeesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Relationship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                table: "Relationship",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Relationship",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DecisionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Disabled",
                table: "DecisionType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DecisionType",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_OrganizationPosition_Employee_EmployeesId",
            //    schema: "HRM",
            //    table: "OrganizationPosition",
            //    column: "EmployeesId",
            //    principalSchema: "HRM",
            //    principalTable: "Employee",
            //    principalColumn: "Id");
        }
    }
}
