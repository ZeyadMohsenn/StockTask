using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeZone.DAL.Migrations
{
    /// <inheritdoc />
    public partial class log3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StoreActivityLogs_StoreId",
                table: "StoreActivityLogs",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreActivityLogs_Stores_StoreId",
                table: "StoreActivityLogs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreActivityLogs_Stores_StoreId",
                table: "StoreActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_StoreActivityLogs_StoreId",
                table: "StoreActivityLogs");
        }
    }
}
