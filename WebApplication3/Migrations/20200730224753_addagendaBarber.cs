using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Data.Migrations
{
    public partial class addagendaBarber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda_Barbeiros",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempoDeProdução = table.Column<int>(nullable: false),
                    Domingo = table.Column<bool>(nullable: false),
                    Segunda = table.Column<bool>(nullable: false),
                    Terca = table.Column<bool>(nullable: false),
                    Quarta = table.Column<bool>(nullable: false),
                    Quinta = table.Column<bool>(nullable: false),
                    Sexta = table.Column<bool>(nullable: false),
                    Sabado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda_Barbeiros", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda_Barbeiros");
        }
    }
}
