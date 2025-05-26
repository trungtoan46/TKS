using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKS.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                table: "tbl_DM_San_Pham");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tbl_DM_Don_Vi_Tinh",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham",
                column: "Don_Vi_Tinh_ID",
                principalTable: "tbl_DM_Don_Vi_Tinh",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                table: "tbl_DM_San_Pham",
                column: "Loai_San_Pham_ID",
                principalTable: "tbl_DM_Loai_San_Pham",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                table: "tbl_DM_San_Pham");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tbl_DM_Don_Vi_Tinh");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Don_Vi_Tinh_Don_Vi_Tinh_ID",
                table: "tbl_DM_San_Pham",
                column: "Don_Vi_Tinh_ID",
                principalTable: "tbl_DM_Don_Vi_Tinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DM_San_Pham_tbl_DM_Loai_San_Pham_Loai_San_Pham_ID",
                table: "tbl_DM_San_Pham",
                column: "Loai_San_Pham_ID",
                principalTable: "tbl_DM_Loai_San_Pham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
