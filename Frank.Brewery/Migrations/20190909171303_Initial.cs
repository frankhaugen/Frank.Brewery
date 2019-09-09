using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frank.Brewery.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fermentables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Lovibond = table.Column<double>(nullable: false),
                    Ppg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AlphaAcid = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yeasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    BeerCategory = table.Column<int>(nullable: false),
                    AlcoholTolerance = table.Column<int>(nullable: false),
                    Flocculation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    MashTime = table.Column<int>(nullable: false),
                    BoilTime = table.Column<int>(nullable: false),
                    BatchSize = table.Column<int>(nullable: false),
                    YeastId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Yeasts_YeastId",
                        column: x => x.YeastId,
                        principalTable: "Yeasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeFermentable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false),
                    FermentableId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeFermentable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeFermentable_Fermentables_FermentableId",
                        column: x => x.FermentableId,
                        principalTable: "Fermentables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeFermentable_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    HopId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Hops_HopId",
                        column: x => x.HopId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFermentable_FermentableId",
                table: "RecipeFermentable",
                column: "FermentableId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFermentable_RecipeId",
                table: "RecipeFermentable",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_YeastId",
                table: "Recipes",
                column: "YeastId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_HopId",
                table: "Steps",
                column: "HopId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeFermentable");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Fermentables");

            migrationBuilder.DropTable(
                name: "Hops");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Yeasts");
        }
    }
}
