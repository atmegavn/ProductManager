using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Profile_Manager1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLocationHRM_Location_LocationId",
                table: "ProfileLocationHRM");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLocationHRM_Profile_ProfileId",
                table: "ProfileLocationHRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileLocationHRM",
                table: "ProfileLocationHRM");

            migrationBuilder.RenameTable(
                name: "ProfileLocationHRM",
                newName: "ProfileLocation",
                newSchema: "HRM");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLocationHRM_ProfileId_LocationId",
                schema: "HRM",
                table: "ProfileLocation",
                newName: "IX_ProfileLocation_ProfileId_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLocationHRM_LocationId",
                schema: "HRM",
                table: "ProfileLocation",
                newName: "IX_ProfileLocation_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileLocation",
                schema: "HRM",
                table: "ProfileLocation",
                columns: new[] { "ProfileId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLocation_Location_LocationId",
                schema: "HRM",
                table: "ProfileLocation",
                column: "LocationId",
                principalSchema: "HRM",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLocation_Profile_ProfileId",
                schema: "HRM",
                table: "ProfileLocation",
                column: "ProfileId",
                principalSchema: "HRM",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLocation_Location_LocationId",
                schema: "HRM",
                table: "ProfileLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLocation_Profile_ProfileId",
                schema: "HRM",
                table: "ProfileLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileLocation",
                schema: "HRM",
                table: "ProfileLocation");

            migrationBuilder.RenameTable(
                name: "ProfileLocation",
                schema: "HRM",
                newName: "ProfileLocationHRM");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLocation_ProfileId_LocationId",
                table: "ProfileLocationHRM",
                newName: "IX_ProfileLocationHRM_ProfileId_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileLocation_LocationId",
                table: "ProfileLocationHRM",
                newName: "IX_ProfileLocationHRM_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileLocationHRM",
                table: "ProfileLocationHRM",
                columns: new[] { "ProfileId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLocationHRM_Location_LocationId",
                table: "ProfileLocationHRM",
                column: "LocationId",
                principalSchema: "HRM",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLocationHRM_Profile_ProfileId",
                table: "ProfileLocationHRM",
                column: "ProfileId",
                principalSchema: "HRM",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
