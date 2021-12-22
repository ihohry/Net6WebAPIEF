﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net6WebAPIEF.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Contacts_Accounts_AccountName",
                        column: x => x.AccountName,
                        principalTable: "Accounts",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentName);
                    table.ForeignKey(
                        name: "FK_Incidents_Accounts_AccountName",
                        column: x => x.AccountName,
                        principalTable: "Accounts",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Contacts_ContactEmail",
                        column: x => x.ContactEmail,
                        principalTable: "Contacts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountName",
                table: "Contacts",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AccountName",
                table: "Incidents",
                column: "AccountName");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ContactEmail",
                table: "Incidents",
                column: "ContactEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
