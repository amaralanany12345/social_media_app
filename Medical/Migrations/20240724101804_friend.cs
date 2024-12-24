using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Migrations
{
    /// <inheritdoc />
    public partial class friend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_profiles_Profileid",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_Profileid",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "Profileid",
                table: "profiles");

            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    profileId = table.Column<int>(type: "int", nullable: false),
                    friendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => new { x.profileId, x.friendId });
                    table.ForeignKey(
                        name: "FK_friends_profiles_profileId",
                        column: x => x.profileId,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_friends_users_friendId",
                        column: x => x.friendId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_friends_friendId",
                table: "friends",
                column: "friendId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.AddColumn<int>(
                name: "Profileid",
                table: "profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_Profileid",
                table: "profiles",
                column: "Profileid");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_profiles_Profileid",
                table: "profiles",
                column: "Profileid",
                principalTable: "profiles",
                principalColumn: "id");
        }
    }
}
