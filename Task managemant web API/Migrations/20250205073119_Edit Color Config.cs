using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_managemant_web_API.Migrations
{
    /// <inheritdoc />
    public partial class EditColorConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StickyNotes_ColorID",
                table: "StickyNotes");

            migrationBuilder.CreateIndex(
                name: "IX_StickyNotes_ColorID",
                table: "StickyNotes",
                column: "ColorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StickyNotes_ColorID",
                table: "StickyNotes");

            migrationBuilder.CreateIndex(
                name: "IX_StickyNotes_ColorID",
                table: "StickyNotes",
                column: "ColorID",
                unique: true);
        }
    }
}
