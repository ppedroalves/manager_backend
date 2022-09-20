using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Disponivel = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Valor = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oportunidade_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidade_UsuarioId",
                table: "Oportunidade",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oportunidade");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
