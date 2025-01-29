using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_managemant_web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDayseOfWeekTasksPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOfWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DayNumber = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeeks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PriorityType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_DaysOfWeeks_DayId",
                        column: x => x.DayId,
                        principalTable: "DaysOfWeeks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DaysOfWeeks",
                columns: new[] { "Id", "DayNumber" },
                values: new object[,]
                {
                    { 1, (short)1 },
                    { 2, (short)2 },
                    { 3, (short)3 },
                    { 4, (short)4 },
                    { 5, (short)5 },
                    { 6, (short)6 },
                    { 7, (short)7 }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "PriorityType" },
                values: new object[,]
                {
                    { 1, (short)1 },
                    { 2, (short)2 },
                    { 3, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DayId", "IsDone", "PriorityId", "TaskDescription", "UserID" },
                values: new object[,]
                {
                    { 1, 1, false, 1, "i love Football", 1 },
                    { 2, 4, false, 2, "i love Moon", 1 },
                    { 3, 3, false, 1, "i love Study", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DayId",
                table: "Tasks",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserID",
                table: "Tasks",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "DaysOfWeeks");

            migrationBuilder.DropTable(
                name: "Priorities");
        }
    }
}
