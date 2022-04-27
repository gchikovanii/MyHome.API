using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHome.Infrastructure.Migrations
{
    public partial class UpdateAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementFeatures_Features_FeatureId",
                table: "AdvertisementFeatures");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementFeatures_FeatureId",
                table: "AdvertisementFeatures");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "AdvertisementFeatures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "AdvertisementFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementFeatures_FeatureId",
                table: "AdvertisementFeatures",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementFeatures_Features_FeatureId",
                table: "AdvertisementFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }
    }
}
