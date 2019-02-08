using Microsoft.EntityFrameworkCore.Migrations;

namespace persistence.Migrations
{
    public partial class addedbasicseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Ask Pinky and Brain for details!", "Establish World Domination" });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Once you dominate all, declare world peace", "World Peace" });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "Take your fishing rod and decoys and get some fish.", "Go Fishing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
