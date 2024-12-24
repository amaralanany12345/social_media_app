using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class reply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_comments_parentCommentID",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_parentCommentID",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "parentCommentID",
                table: "comments");

            migrationBuilder.CreateTable(
                name: "replies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reply = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    parentCommentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_replies", x => x.id);
                    table.ForeignKey(
                        name: "FK_replies_comments_parentCommentID",
                        column: x => x.parentCommentID,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_replies_parentCommentID",
                table: "replies",
                column: "parentCommentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "replies");

            migrationBuilder.AddColumn<int>(
                name: "parentCommentID",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_parentCommentID",
                table: "comments",
                column: "parentCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_comments_parentCommentID",
                table: "comments",
                column: "parentCommentID",
                principalTable: "comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
