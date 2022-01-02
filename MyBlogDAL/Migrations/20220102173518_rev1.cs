using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogDAL.Migrations
{
    public partial class rev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_CreatorId1",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatorId1",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId1",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatorId1",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatorId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatorId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatorId",
                table: "Tags",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatorId",
                table: "Blogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatorId",
                table: "Articles",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_CreatorId",
                table: "Articles",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatorId",
                table: "Blogs",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId",
                table: "Tags",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_CreatorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatorId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatorId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreatorId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatorId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatorId1",
                table: "Tags",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatorId1",
                table: "Blogs",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatorId1",
                table: "Articles",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_CreatorId1",
                table: "Articles",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_CreatorId1",
                table: "Blogs",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId1",
                table: "Comments",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_CreatorId1",
                table: "Tags",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
