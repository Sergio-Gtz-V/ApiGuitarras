using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGuitarras.Migrations
{
    public partial class Tiendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Guitarras",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Guitarras",
                newName: "Brand");

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiendas_Guitarras_GuitarraId",
                        column: x => x.GuitarraId,
                        principalTable: "Guitarras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_GuitarraId",
                table: "Tiendas",
                column: "GuitarraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guitarras",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Guitarras",
                newName: "brand");
        }
    }
}
