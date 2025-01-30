using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_managemant_web_API.Migrations
{
    /// <inheritdoc />
    public partial class addedNoteBookModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NoteBookTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoteBookDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notebooks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "Id", "NoteBookDescription", "NoteBookTitle", "UserID" },
                values: new object[,]
                {
                    { 1, "I Should Run 3KM", "Sport", 1 },
                    { 2, "Get Some Mobility Excercises ", "LifeStyle", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_UserID",
                table: "Notebooks",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notebooks");
        }
    }
}
