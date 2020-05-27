using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class CartTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFoodCart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tblCustomerID = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    tblRestaurantID = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFoodCart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblFoodCartMapping",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TblFoodCartId = table.Column<int>(nullable: true),
                    tblMenuID = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    RecordTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    RecordTimeStampCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFoodCartMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblFoodCartMapping_tblFoodCartID",
                        column: x => x.TblFoodCartId,
                        principalTable: "tblFoodCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFoodCartMapping_TblFoodCartId",
                table: "tblFoodCartMapping",
                column: "TblFoodCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFoodCartMapping");

            migrationBuilder.DropTable(
                name: "tblFoodCart");
        }
    }
}
