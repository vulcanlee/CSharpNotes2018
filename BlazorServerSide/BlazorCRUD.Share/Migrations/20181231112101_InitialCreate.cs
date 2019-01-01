using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCRUD.Share.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CityName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Designation = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Gender = table.Column<string>(unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
