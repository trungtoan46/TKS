using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS.Migrations
{
    /// <inheritdoc />
    public partial class AddKhoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tbl_DM_Don_Vi_Tinh");

            migrationBuilder.CreateTable(
                name: "tbl_DM_Kho",
                columns: table => new
                {
                    Kho_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ten_Kho = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ghi_Chu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DM_Kho", x => x.Kho_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DM_Kho_Ten_Kho",
                table: "tbl_DM_Kho",
                column: "Ten_Kho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DM_Kho");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
