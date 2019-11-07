using Microsoft.EntityFrameworkCore.Migrations;

namespace FosterCareAPI2.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    MoveInDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 1, "01/01/01", "08/08/08", "Ashton" });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 2, "01/01/96", "09/09/09", "Dylan" });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 3, "01/01/05", "02/02/12", "Lilly" });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 4, "01/01/12", "03/03/13", "Mariah" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Child");
        }
    }
}
