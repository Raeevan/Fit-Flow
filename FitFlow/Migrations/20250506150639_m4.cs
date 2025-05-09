using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlow.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Memberships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Memberships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
