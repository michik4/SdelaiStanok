using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SdelaiStanokAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGalleryModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemTag_GalleryItems_GalleryItemsId",
                table: "GalleryItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemTag_Tags_TagsId",
                table: "GalleryItemTag");

            migrationBuilder.DropIndex(
                name: "IX_GalleryItems_DescriptionId",
                table: "GalleryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GalleryItemTag",
                table: "GalleryItemTag");

            migrationBuilder.RenameTable(
                name: "GalleryItemTag",
                newName: "GalleryItemTags");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryItemTag_TagsId",
                table: "GalleryItemTags",
                newName: "IX_GalleryItemTags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GalleryItemTags",
                table: "GalleryItemTags",
                columns: new[] { "GalleryItemsId", "TagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryItems_DescriptionId",
                table: "GalleryItems",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemTags_GalleryItems_GalleryItemsId",
                table: "GalleryItemTags",
                column: "GalleryItemsId",
                principalTable: "GalleryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemTags_Tags_TagsId",
                table: "GalleryItemTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemTags_GalleryItems_GalleryItemsId",
                table: "GalleryItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_GalleryItemTags_Tags_TagsId",
                table: "GalleryItemTags");

            migrationBuilder.DropIndex(
                name: "IX_GalleryItems_DescriptionId",
                table: "GalleryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GalleryItemTags",
                table: "GalleryItemTags");

            migrationBuilder.RenameTable(
                name: "GalleryItemTags",
                newName: "GalleryItemTag");

            migrationBuilder.RenameIndex(
                name: "IX_GalleryItemTags_TagsId",
                table: "GalleryItemTag",
                newName: "IX_GalleryItemTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GalleryItemTag",
                table: "GalleryItemTag",
                columns: new[] { "GalleryItemsId", "TagsId" });

            migrationBuilder.CreateIndex(
                name: "IX_GalleryItems_DescriptionId",
                table: "GalleryItems",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemTag_GalleryItems_GalleryItemsId",
                table: "GalleryItemTag",
                column: "GalleryItemsId",
                principalTable: "GalleryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GalleryItemTag_Tags_TagsId",
                table: "GalleryItemTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
