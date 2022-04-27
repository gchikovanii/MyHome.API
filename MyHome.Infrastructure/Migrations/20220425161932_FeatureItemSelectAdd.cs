using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHome.Infrastructure.Migrations
{
    public partial class FeatureItemSelectAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatireItemSelectId",
                table: "AdvertisementFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureItemSlecets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureItemSlecets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureItemSlecets_FeatureItems_FeatureItemId",
                        column: x => x.FeatureItemId,
                        principalTable: "FeatureItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureItemSlecets_FeatureItemId",
                table: "FeatureItemSlecets",
                column: "FeatureItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureItemSlecets");

            migrationBuilder.DropColumn(
                name: "FeatireItemSelectId",
                table: "AdvertisementFeatures");
        }
    }
}
