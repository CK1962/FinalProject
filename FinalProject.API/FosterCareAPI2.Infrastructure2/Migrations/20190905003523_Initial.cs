using Microsoft.EntityFrameworkCore.Migrations;

namespace FosterCareAPI2.Infrastructure2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
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
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

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
                name: "ChildHomes",
                columns: table => new
                {
                    ChildId = table.Column<int>(nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildHomes", x => new { x.ChildId, x.HouseId });
                    table.ForeignKey(
                        name: "FK_ChildHomes_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildHomes_Home_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 1, "01/01/01", "08/08/08", "Ashton" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 2, "01/01/96", "09/09/09", "Dylan" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 3, "01/01/05", "02/02/12", "Lilly" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Dob", "MoveInDate", "Name" },
                values: new object[] { 4, "01/01/12", "03/03/13", "Mariah" });

            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 1, "Lubbock", "Keslin" });

            migrationBuilder.CreateIndex(
                name: "IX_ChildHomes_HouseId",
                table: "ChildHomes",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildHomes");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Home");
        }
    }
}
