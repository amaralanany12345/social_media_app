using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class updateFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "postImageId",
                table: "posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_postImageId",
                table: "posts",
                column: "postImageId",
                unique: true,
                filter: "[postImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_files_postImageId",
                table: "posts",
                column: "postImageId",
                principalTable: "files",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_files_postImageId",
                table: "posts");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropIndex(
                name: "IX_posts_postImageId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "postImageId",
                table: "posts");
        }
    }
}
