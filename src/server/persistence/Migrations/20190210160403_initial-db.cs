﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    UserListText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlanId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chores_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "PlanId", "Title" },
                values: new object[] { 1, "Ask Pinky and Brain for details!", null, "Establish World Domination" });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "PlanId", "Title" },
                values: new object[] { 2, "Once you dominate all, declare world peace", null, "World Peace" });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "PlanId", "Title" },
                values: new object[] { 3, "Take your fishing rod and decoys and get some fish.", null, "Go Fishing" });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_PlanId",
                table: "Chores",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
