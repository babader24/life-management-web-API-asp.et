using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_managemant_web_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedHabitEntityandepositoryPattern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HabitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sat = table.Column<bool>(type: "bit", nullable: false),
                    Sun = table.Column<bool>(type: "bit", nullable: false),
                    Mon = table.Column<bool>(type: "bit", nullable: false),
                    Tue = table.Column<bool>(type: "bit", nullable: false),
                    Wed = table.Column<bool>(type: "bit", nullable: false),
                    Thu = table.Column<bool>(type: "bit", nullable: false),
                    Fri = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habits_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Fri", "HabitName", "Mon", "Sat", "Sun", "Thu", "Tue", "UserId", "Wed" },
                values: new object[] { 1, false, "Eat breakfast", true, true, false, true, false, 1, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
