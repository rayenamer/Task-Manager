using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_taches.Data.Migrations
{
    /// <inheritdoc />
    public partial class migaloose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nomp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priorité = table.Column<int>(type: "int", nullable: false),
                    BudgetAllouee = table.Column<float>(type: "real", nullable: false),
                    DateDebut = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinPrevue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.IdProject);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    IdRessources = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cout = table.Column<float>(type: "real", nullable: true),
                    unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProject = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.IdRessources);
                    table.ForeignKey(
                        name: "FK_Ressources_Project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_IdProject",
                table: "Ressources",
                column: "IdProject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
