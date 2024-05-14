using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuiviDepenses_Depenses_DepenseId",
                table: "SuiviDepenses");

            migrationBuilder.DropIndex(
                name: "IX_SuiviDepenses_DepenseId",
                table: "SuiviDepenses");

            migrationBuilder.DropColumn(
                name: "DepenseId",
                table: "SuiviDepenses");

            migrationBuilder.AddColumn<int>(
                name: "SuiviDepenseId",
                table: "Depenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depenses_SuiviDepenseId",
                table: "Depenses",
                column: "SuiviDepenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depenses_SuiviDepenses_SuiviDepenseId",
                table: "Depenses",
                column: "SuiviDepenseId",
                principalTable: "SuiviDepenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depenses_SuiviDepenses_SuiviDepenseId",
                table: "Depenses");

            migrationBuilder.DropIndex(
                name: "IX_Depenses_SuiviDepenseId",
                table: "Depenses");

            migrationBuilder.DropColumn(
                name: "SuiviDepenseId",
                table: "Depenses");

            migrationBuilder.AddColumn<int>(
                name: "DepenseId",
                table: "SuiviDepenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SuiviDepenses_DepenseId",
                table: "SuiviDepenses",
                column: "DepenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuiviDepenses_Depenses_DepenseId",
                table: "SuiviDepenses",
                column: "DepenseId",
                principalTable: "Depenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
