using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentApi.Migrations
{
    public partial class AddCarClassToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarClassId",
                table: "Cars",
                column: "CarClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarClasses_CarClassId",
                table: "Cars",
                column: "CarClassId",
                principalTable: "CarClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarClasses_CarClassId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarClassId",
                table: "Cars");
        }
    }
}
