using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_DM_Don_Vi_Tinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ten_Don_Vi_Tinh = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GhiChu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Don_Vi_Tinh", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_DM_Loai_San_Pham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ma_LSP = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ten_LSP = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GhiChu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Loai_San_Pham", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_DM_NCC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ma_NCC = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ten_NCC = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GhiChu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_NCC", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_DM_San_Pham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ma_San_Pham = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ten_San_Pham = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Loai_San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    Don_Vi_Tinh_ID = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_San_Pham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                        column: x => x.Don_Vi_Tinh_ID,
                        principalTable: "tbl_DM_Don_Vi_Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                        column: x => x.Loai_San_Pham_ID,
                        principalTable: "tbl_DM_Loai_San_Pham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Don_Vi_Tinh_Ten_Don_Vi_Tinh",
                table: "tbl_DM_Don_Vi_Tinh",
                column: "Ten_Don_Vi_Tinh");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Loai_San_Pham_Ma_LSP_Ten_LSP",
                table: "tbl_DM_Loai_San_Pham",
                columns: new[] { "Ma_LSP", "Ten_LSP" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_NCC_Ten_NCC",
                table: "tbl_DM_NCC",
                column: "Ten_NCC");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_San_Pham_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham",
                column: "Don_Vi_Tinh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_San_Pham_Loai_San_Pham_ID_Ten_San_Pham_Ma_San_Pham_Do~",
                table: "tbl_DM_San_Pham",
                columns: new[] { "Loai_San_Pham_ID", "Ten_San_Pham", "Ma_San_Pham", "Don_Vi_Tinh_ID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_NCC");

            migrationBuilder.DropTable(
                name: "tbl_DM_San_Pham");

            migrationBuilder.DropTable(
                name: "tbl_DM_Don_Vi_Tinh");

            migrationBuilder.DropTable(
                name: "tbl_DM_Loai_San_Pham");
        }
    }
}
