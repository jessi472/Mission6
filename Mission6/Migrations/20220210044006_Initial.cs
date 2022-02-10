using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryResp",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryResp", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TaskResp",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<string>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResp", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskResp_CategoryResp_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryResp",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryResp",
                columns: new[] { "CategoryId", "CategoryTitle" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "CategoryResp",
                columns: new[] { "CategoryId", "CategoryTitle" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "CategoryResp",
                columns: new[] { "CategoryId", "CategoryTitle" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "CategoryResp",
                columns: new[] { "CategoryId", "CategoryTitle" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "TaskResp",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, 1, true, "09-09-2022", "Important & Urgent", "Win Win Win" });

            migrationBuilder.InsertData(
                table: "TaskResp",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 2, 2, true, "09-10-2022", "Important & Not Urgent", "Win Win Lose" });

            migrationBuilder.InsertData(
                table: "TaskResp",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 3, 3, false, "09-11-2022", "Not Important & Urgent", "Win Lose Lose" });

            migrationBuilder.InsertData(
                table: "TaskResp",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 4, 4, false, "09-12-2022", "Not Important & Not Urgent", "Lose Lose Lose" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResp_CategoryId",
                table: "TaskResp",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResp");

            migrationBuilder.DropTable(
                name: "CategoryResp");
        }
    }
}
