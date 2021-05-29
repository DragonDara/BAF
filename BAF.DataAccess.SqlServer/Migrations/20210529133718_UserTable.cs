using Microsoft.EntityFrameworkCore.Migrations;

namespace BAF.DataAccess.SqlServer.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AuthId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiKeyHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiSecretValueHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AuthId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
