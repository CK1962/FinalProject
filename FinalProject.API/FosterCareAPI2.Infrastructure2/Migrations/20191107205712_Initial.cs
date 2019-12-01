using Microsoft.EntityFrameworkCore.Migrations;

namespace FosterCareAPI2.Infrastructure2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    MoveInDate = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Home_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 1, "Lubbock", "Keslin" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "HouseId", "MoveInDate", "Name" },
                values: new object[] { 1, "01/01/01", 1, "08/08/08", "Ashton" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "HouseId", "MoveInDate", "Name" },
                values: new object[] { 2, "01/01/96", 1, "09/09/09", "Dylan" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "HouseId", "MoveInDate", "Name" },
                values: new object[] { 3, "01/01/05", 1, "02/02/12", "Lilly" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "HouseId", "MoveInDate", "Name" },
                values: new object[] { 4, "01/01/12", 1, "03/03/13", "Mariah" });

            migrationBuilder.CreateIndex(
                name: "IX_Children_HouseId",
                table: "Children",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Home");
        }
    }
}
