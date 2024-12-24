using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Profileid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_profiles_profiles_Profileid",
                        column: x => x.Profileid,
                        principalTable: "profiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_profiles_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    parentCommentID = table.Column<int>(type: "int", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_comments_parentCommentID",
                        column: x => x.parentCommentID,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "postLikes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postId = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postLikes", x => x.id);
                    table.ForeignKey(
                        name: "FK_postLikes_posts_postId",
                        column: x => x.postId,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_postLikes_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "commentLikes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentId = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentLikes", x => x.id);
                    table.ForeignKey(
                        name: "FK_commentLikes_comments_commentId",
                        column: x => x.commentId,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commentLikes_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commentLikes_commentId",
                table: "commentLikes",
                column: "commentId");

            migrationBuilder.CreateIndex(
                name: "IX_commentLikes_profileId",
                table: "commentLikes",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_parentCommentID",
                table: "comments",
                column: "parentCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_postId",
                table: "comments",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_profileId",
                table: "comments",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_postLikes_postId",
                table: "postLikes",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_postLikes_profileId",
                table: "postLikes",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_profileId",
                table: "posts",
                column: "profileId");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_Profileid",
                table: "profiles",
                column: "Profileid");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commentLikes");

            migrationBuilder.DropTable(
                name: "postLikes");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
