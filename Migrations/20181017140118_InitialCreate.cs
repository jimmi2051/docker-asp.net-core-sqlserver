using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_Sach.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBook = table.Column<string>(nullable: true),
                    NameBook = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    NumPage = table.Column<int>(nullable: true),
                    TypeBook = table.Column<string>(nullable: true),
                    PublishingCompany = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
