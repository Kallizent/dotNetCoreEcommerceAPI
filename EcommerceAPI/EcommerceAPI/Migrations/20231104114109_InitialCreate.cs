using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tanggal_daftar = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategori = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voucher_Claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherid = table.Column<int>(type: "int", nullable: false),
                    tanggal_Claim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher_Claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_voucher_Claims_Vouchers_voucherid",
                        column: x => x.voucherid,
                        principalTable: "Vouchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_voucher_Claims_voucherid",
                table: "voucher_Claims",
                column: "voucherid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "voucher_Claims");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
