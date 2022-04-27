using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHome.Infrastructure.Migrations
{
    public partial class UpdateFeatureItemSelect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureItemSlecets_FeatureItems_FeatureItemId",
                table: "FeatureItemSlecets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureItemSlecets",
                table: "FeatureItemSlecets");

            migrationBuilder.RenameTable(
                name: "FeatureItemSlecets",
                newName: "FeatureItemSelcts");

            migrationBuilder.RenameColumn(
                name: "FeatireItemSelectId",
                table: "AdvertisementFeatures",
                newName: "FeatureItemSelectId");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureItemSlecets_FeatureItemId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureItemSelcts_FeatureItems_FeatureItemId",
                table: "FeatureItemSelcts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureItemSelcts",
                table: "FeatureItemSelcts");

            migrationBuilder.RenameTable(
                name: "FeatureItemSelcts",
                newName: "FeatureItemSlecets");

            migrationBuilder.RenameColumn(
                name: "FeatureItemSelectId",
                table: "AdvertisementFeatures",
                newName: "FeatireItemSelectId");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureItemSelcts_FeatureItemId",
                table: "FeatureItemSlecets",
                newName: "IX_FeatureItemSlecets_FeatureItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureItemSlecets",
                table: "FeatureItemSlecets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureItemSlecets_FeatureItems_FeatureItemId",
                table: "FeatureItemSlecets",
                column: "FeatureItemId",
                principalTable: "FeatureItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
