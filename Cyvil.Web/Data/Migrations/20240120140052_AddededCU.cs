using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyvil.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddededCU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanCreateCampaign",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CampaignUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CanEditCampaign = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanDeleteCampaign = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanCreateOpportunity = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanEditOpportunity = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanDeleteOpportunity = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanCreateEvent = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanEditEvent = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanDeleteEvent = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanRemoveVolunteer = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanRemoveManager = table.Column<bool>(type: "INTEGER", nullable: false),
                    CampaignId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignUsers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUsers_CampaignId",
                table: "CampaignUsers",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUsers_UserId",
                table: "CampaignUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignUsers");

            migrationBuilder.DropColumn(
                name: "CanCreateCampaign",
                table: "AspNetUsers");
        }
    }
}
