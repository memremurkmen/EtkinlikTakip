using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class changeActivityColmnNameMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Activity",
                newName: "Lokasyon");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Activity",
                newName: "Fotograf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lokasyon",
                table: "Activity",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Fotograf",
                table: "Activity",
                newName: "Image");
        }
    }
}
