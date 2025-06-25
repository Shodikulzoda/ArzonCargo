using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class pocketadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PocketItem_Orders_OrderId",
                table: "PocketItem");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PocketItem",
                newName: "PocketId");

            migrationBuilder.RenameIndex(
                name: "IX_PocketItem_OrderId",
                table: "PocketItem",
                newName: "IX_PocketItem_PocketId");

            migrationBuilder.CreateTable(
                name: "Pockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<double>(type: "double precision", nullable: false),
                    TotalWeight = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pockets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pockets_UserId",
                table: "Pockets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PocketItem_Pockets_PocketId",
                table: "PocketItem",
                column: "PocketId",
                principalTable: "Pockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PocketItem_Pockets_PocketId",
                table: "PocketItem");

            migrationBuilder.DropTable(
                name: "Pockets");

            migrationBuilder.RenameColumn(
                name: "PocketId",
                table: "PocketItem",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PocketItem_PocketId",
                table: "PocketItem",
                newName: "IX_PocketItem_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PocketItem_Orders_OrderId",
                table: "PocketItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
