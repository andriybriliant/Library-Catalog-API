using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsAndCheckouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Books_BookId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Users_UserId",
                table: "Checkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkout",
                table: "Checkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Checkout",
                newName: "Checkouts");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Checkout_UserId",
                table: "Checkouts",
                newName: "IX_Checkouts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkout_BookId",
                table: "Checkouts",
                newName: "IX_Checkouts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Users_UserId",
                table: "Checkouts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Users_UserId",
                table: "Checkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Checkouts",
                newName: "Checkout");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_UserId",
                table: "Checkout",
                newName: "IX_Checkout_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkout",
                newName: "IX_Checkout_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkout",
                table: "Checkout",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Books_BookId",
                table: "Checkout",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Users_UserId",
                table: "Checkout",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
