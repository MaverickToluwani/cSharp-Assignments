using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_CategoryZs_CategoryId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryZs",
                table: "CategoryZs");

            migrationBuilder.RenameTable(
                name: "CategoryZs",
                newName: "CategoriesZ");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesZ",
                table: "CategoriesZ",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_CategoriesZ_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "CategoriesZ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_CategoriesZ_CategoryId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesZ",
                table: "CategoriesZ");

            migrationBuilder.RenameTable(
                name: "CategoriesZ",
                newName: "CategoryZs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryZs",
                table: "CategoryZs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_CategoryZs_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "CategoryZs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
