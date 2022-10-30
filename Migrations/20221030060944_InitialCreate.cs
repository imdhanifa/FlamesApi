using Microsoft.EntityFrameworkCore.Migrations;

namespace CSIT.Flames.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data_Details",
                columns: table => new
                {
                    SI = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BName = table.Column<string>(nullable: true),
                    GName = table.Column<string>(nullable: true),
                    Flames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data_Details", x => x.SI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data_Details");
        }
    }
}
