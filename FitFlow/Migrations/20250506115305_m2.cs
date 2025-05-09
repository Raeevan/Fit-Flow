using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFlow.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_MemberID",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_MemberID",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Memberships");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_PersonID",
                table: "Memberships",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Persons_PersonID",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_PersonID",
                table: "Memberships");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Memberships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberID",
                table: "Memberships",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Persons_MemberID",
                table: "Memberships",
                column: "MemberID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
