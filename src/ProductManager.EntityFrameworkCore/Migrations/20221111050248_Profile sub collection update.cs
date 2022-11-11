using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class Profilesubcollectionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialLink",
                schema: "HRM");

            migrationBuilder.DropColumn(
                name: "Relationship",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.RenameColumn(
                name: "IsMain",
                schema: "HRM",
                table: "BankAccount",
                newName: "IsPrimary");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "HRM",
                table: "Relative",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "HRM",
                table: "Relative",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelationshipId",
                schema: "HRM",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "HRM",
                table: "Email",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descriptioin",
                schema: "HRM",
                table: "BankAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetwork",
                schema: "HRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetwork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialContact",
                schema: "HRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialNetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialContact_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "HRM",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialContact_SocialNetwork_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalSchema: "HRM",
                        principalTable: "SocialNetwork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relative_RelationshipId",
                schema: "HRM",
                table: "Relative",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialContact_ProfileId",
                schema: "HRM",
                table: "SocialContact",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialContact_SocialNetworkId",
                schema: "HRM",
                table: "SocialContact",
                column: "SocialNetworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relative_Relationship_RelationshipId",
                schema: "HRM",
                table: "Relative",
                column: "RelationshipId",
                principalTable: "Relationship",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relative_Relationship_RelationshipId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "SocialContact",
                schema: "HRM");

            migrationBuilder.DropTable(
                name: "SocialNetwork",
                schema: "HRM");

            migrationBuilder.DropIndex(
                name: "IX_Relative_RelationshipId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropColumn(
                name: "RelationshipId",
                schema: "HRM",
                table: "Relative");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "HRM",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "Descriptioin",
                schema: "HRM",
                table: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "IsPrimary",
                schema: "HRM",
                table: "BankAccount",
                newName: "IsMain");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "HRM",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");

            migrationBuilder.AddColumn<int>(
                name: "Relationship",
                schema: "HRM",
                table: "Relative",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SocialLink",
                schema: "HRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Network = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLink_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "HRM",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialLink_ProfileId",
                schema: "HRM",
                table: "SocialLink",
                column: "ProfileId");
        }
    }
}
