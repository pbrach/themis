using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class addedplans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanId",
                table: "Chores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserListText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_PlanId",
                table: "Chores",
                column: "PlanId");

            /* SQLite does not support foreign keys */
//            migrationBuilder.AddForeignKey(
//                name: "FK_Chores_Plans_PlanId",
//                table: "Chores",
//                column: "PlanId",
//                principalTable: "Plans",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* SQLite does not support foreign keys */
//            migrationBuilder.DropForeignKey(
//                name: "FK_Chores_Plans_PlanId",
//                table: "Chores");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Chores_PlanId",
                table: "Chores");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Chores");
        }
    }
}
