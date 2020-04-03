using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeedService.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FollowerUserName = table.Column<string>(nullable: false),
                    FollowedUserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RatedUserName = table.Column<string>(nullable: false),
                    RaterUserName = table.Column<string>(nullable: false),
                    TimeRated = table.Column<DateTime>(nullable: false),
                    GivenRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 12, nullable: true),
                    Bio = table.Column<string>(maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    FacebookId = table.Column<string>(nullable: true),
                    TwitterId = table.Column<string>(nullable: true),
                    LinkedInId = table.Column<string>(nullable: true),
                    InstagramId = table.Column<string>(nullable: true),
                    Joined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
