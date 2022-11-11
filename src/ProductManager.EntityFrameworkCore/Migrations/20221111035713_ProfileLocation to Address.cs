using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class ProfileLocationtoAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileLocation",
                schema: "HRM");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "HRM",
                table: "PhoneNumber",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "HRM",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.ProfileId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_Address_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "HRM",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "HRM",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "HRM",
                table: "Address",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProfileId_LocationId",
                schema: "HRM",
                table: "Address",
                columns: new[] { "ProfileId", "LocationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "HRM");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "HRM",
                table: "PhoneNumber",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ProfileLocation",
                schema: "HRM",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileLocation", x => new { x.ProfileId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ProfileLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "HRM",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileLocation_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "HRM",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLocation_LocationId",
                schema: "HRM",
                table: "ProfileLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLocation_ProfileId_LocationId",
                schema: "HRM",
                table: "ProfileLocation",
                columns: new[] { "ProfileId", "LocationId" });
        }
    }
}
