using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeZone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class log2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StoreActivityLogs_ItemId",
                table: "StoreActivityLogs",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreActivityLogs_Items_ItemId",
                table: "StoreActivityLogs",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreActivityLogs_Items_ItemId",
                table: "StoreActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_StoreActivityLogs_ItemId",
                table: "StoreActivityLogs");
        }
    }
}
