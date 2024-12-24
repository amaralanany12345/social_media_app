using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class addFriendRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "commentImageId",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "friendRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sendedProfileId = table.Column<int>(type: "int", nullable: false),
                    recievedProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_friendRequests_profiles_recievedProfileId",
                        column: x => x.recievedProfileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friendRequests_profiles_sendedProfileId",
                        column: x => x.sendedProfileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_commentImageId",
                table: "comments",
                column: "commentImageId",
                unique: true,
                filter: "[commentImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_friendRequests_recievedProfileId",
                table: "friendRequests",
                column: "recievedProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_friendRequests_sendedProfileId",
                table: "friendRequests",
                column: "sendedProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_files_commentImageId",
                table: "comments",
                column: "commentImageId",
                principalTable: "files",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_files_commentImageId",
                table: "comments");

            migrationBuilder.DropTable(
                name: "friendRequests");

            migrationBuilder.DropIndex(
                name: "IX_comments_commentImageId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "commentImageId",
                table: "comments");
        }
    }
}
