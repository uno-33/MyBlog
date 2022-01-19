using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogDAL.Migrations
{
    public partial class simplifyTagEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatorId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatorId",
                table: "Tags",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId",
                table: "Tags",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
