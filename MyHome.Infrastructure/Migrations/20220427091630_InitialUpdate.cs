using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHome.Infrastructure.Migrations
{
    public partial class InitialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureItemSelcts_FeatureItems_FeatureItemId",
                table: "FeatureItemSelcts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureItemSelcts",
                table: "FeatureItemSelcts");

            migrationBuilder.RenameTable(
                name: "FeatureItemSelcts",
                newName: "FeatureItemSelects");

            migrationBuilder.RenameColumn(
                name: "IsChecked",
                table: "AdvertisementFeatures",
                newName: "IsCheked");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureItemSelcts_FeatureItemId",
                table: "FeatureItemSelects",
                newName: "IX_FeatureItemSelects_FeatureItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureItemSelects",
                table: "FeatureItemSelects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureItemSelects_FeatureItems_FeatureItemId",
                table: "FeatureItemSelects",
                column: "FeatureItemId",
                principalTable: "FeatureItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureItemSelects_FeatureItems_FeatureItemId",
                table: "FeatureItemSelects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureItemSelects",
                table: "FeatureItemSelects");

            migrationBuilder.RenameTable(
                name: "FeatureItemSelects",
                newName: "FeatureItemSelcts");

            migrationBuilder.RenameColumn(
                name: "IsCheked",
                table: "AdvertisementFeatures",
                newName: "IsChecked");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureItemSelects_FeatureItemId",
                table: "FeatureItemSelcts",
                newName: "IX_FeatureItemSelcts_FeatureItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureItemSelcts",
                table: "FeatureItemSelcts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureItemSelcts_FeatureItems_FeatureItemId",
                table: "FeatureItemSelcts",
                column: "FeatureItemId",
                principalTable: "FeatureItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
