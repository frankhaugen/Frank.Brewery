using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Frank.Brewery.Migrations
{
    public partial class ReInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fermentables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    BrewCategory = table.Column<int>(nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    MashTime = table.Column<int>(nullable: false),
                    BoilTime = table.Column<int>(nullable: false),
                    BatchSize = table.Column<int>(nullable: false),
                    YeastId = table.Column<int>(nullable: true),
                    YeastAmount = table.Column<int>(nullable: true)
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
                name: "Brews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeFermentables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    FermentableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeFermentables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeFermentables_Fermentables_FermentableId",
                        column: x => x.FermentableId,
                        principalTable: "Fermentables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeFermentables_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeHops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipeId = table.Column<int>(nullable: false),
                    HopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeHops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeHops_Hops_HopId",
                        column: x => x.HopId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeHops_Recipes_ReceipeId",
                        column: x => x.ReceipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    HopId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Hops_HopId",
                        column: x => x.HopId,
                        principalTable: "Hops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Steps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    ActualAmount = table.Column<int>(nullable: true),
                    BrewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewSteps_Brews_BrewId",
                        column: x => x.BrewId,
                        principalTable: "Brews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrewSteps_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brews_RecipeId",
                table: "Brews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewSteps_BrewId",
                table: "BrewSteps",
                column: "BrewId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewSteps_StepId",
                table: "BrewSteps",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFermentables_FermentableId",
                table: "RecipeFermentables",
                column: "FermentableId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeFermentables_RecipeId",
                table: "RecipeFermentables",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHops_HopId",
                table: "RecipeHops",
                column: "HopId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeHops_ReceipeId",
                table: "RecipeHops",
                column: "ReceipeId");

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
                name: "BrewSteps");

            migrationBuilder.DropTable(
                name: "RecipeFermentables");

            migrationBuilder.DropTable(
                name: "RecipeHops");

            migrationBuilder.DropTable(
                name: "Brews");

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
