using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMQ_MyAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class DMQ_InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMQ_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Prioty = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMQ_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMQ_Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMQ_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMQ_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMQ_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DMQ_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SalePrice = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMQ_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMQ_Product_DMQ_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DMQ_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DMQ_Banner_Name",
                table: "DMQ_Banner",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMQ_Blog_Name",
                table: "DMQ_Blog",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMQ_Category_Name",
                table: "DMQ_Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMQ_Product_CategoryId",
                table: "DMQ_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DMQ_Product_Name",
                table: "DMQ_Product",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMQ_Banner");

            migrationBuilder.DropTable(
                name: "DMQ_Blog");

            migrationBuilder.DropTable(
                name: "DMQ_Product");

            migrationBuilder.DropTable(
                name: "DMQ_Category");
        }
    }
}
