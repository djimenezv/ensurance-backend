using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ensurance.Migrations
{
    public partial class EnsuranceModelsEnsuranceContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Identification = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Identification);
                });

            migrationBuilder.CreateTable(
                name: "Coverings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    CoveragePeriod = table.Column<int>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    RiskType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyNumber);
                });

            migrationBuilder.CreateTable(
                name: "ClientPolicies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identification = table.Column<int>(nullable: true),
                    PolicyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientPolicies_Clients_Identification",
                        column: x => x.Identification,
                        principalTable: "Clients",
                        principalColumn: "Identification",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPolicies_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyCoverings",
                columns: table => new
                {
                    CoveringID = table.Column<int>(nullable: false),
                    PolicyNumber = table.Column<int>(nullable: false),
                    CoveragePercentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCoverings", x => new { x.PolicyNumber, x.CoveringID });
                    table.ForeignKey(
                        name: "FK_PolicyCoverings_Coverings_CoveringID",
                        column: x => x.CoveringID,
                        principalTable: "Coverings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyCoverings_Policies_PolicyNumber",
                        column: x => x.PolicyNumber,
                        principalTable: "Policies",
                        principalColumn: "PolicyNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Identification", "Name" },
                values: new object[,]
                {
                    { 123, "Diego Jimenez" },
                    { 21213, "Juan Manuel" },
                    { 3324324, "Leidy Jhoana" }
                });

            migrationBuilder.InsertData(
                table: "Coverings",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Terremoto" },
                    { 2, "Incendio" },
                    { 3, "Robo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPolicies_Identification",
                table: "ClientPolicies",
                column: "Identification");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPolicies_PolicyId",
                table: "ClientPolicies",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCoverings_CoveringID",
                table: "PolicyCoverings",
                column: "CoveringID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPolicies");

            migrationBuilder.DropTable(
                name: "PolicyCoverings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Coverings");

            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
