using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumDemoApp.Migrations
{
    public partial class IsDeletedColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Marks record as deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");
        }
    }
}
