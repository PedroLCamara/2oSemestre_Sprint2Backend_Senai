using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace senai.InLock.webAPI.CodeFirst.Migrations
{
    public partial class criacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTUDIO",
                columns: table => new
                {
                    IdEstudio = table.Column<byte>(type: "TINYINT", nullable: false),
                    NomeEstudio = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTUDIO", x => x.IdEstudio);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_USUARIO",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<byte>(type: "TINYINT", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_USUARIO", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "JOGO",
                columns: table => new
                {
                    IdJogo = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudio = table.Column<byte>(type: "TINYINT", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOGO", x => x.IdJogo);
                    table.ForeignKey(
                        name: "FK_JOGO_ESTUDIO_IdEstudio",
                        column: x => x.IdEstudio,
                        principalTable: "ESTUDIO",
                        principalColumn: "IdEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoUsuario = table.Column<byte>(type: "TINYINT", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_USUARIO_TIPO_USUARIO_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TIPO_USUARIO",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ESTUDIO",
                columns: new[] { "IdEstudio", "NomeEstudio" },
                values: new object[,]
                {
                    { (byte)1, "Blizzard" },
                    { (byte)2, "Rockstar Studios" },
                    { (byte)3, "Santa Monica Studios" }
                });

            migrationBuilder.InsertData(
                table: "TIPO_USUARIO",
                columns: new[] { "IdTipoUsuario", "Titulo" },
                values: new object[,]
                {
                    { (byte)1, "Administrador" },
                    { (byte)2, "Comum" }
                });

            migrationBuilder.InsertData(
                table: "JOGO",
                columns: new[] { "IdJogo", "DataLancamento", "Descricao", "IdEstudio", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2014, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um jogo de cartas virtual com foco principal em pvp", (byte)1, "Hearthstone", 59.99m },
                    { 2, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V é um jogo eletrônico de ação-aventura", (byte)2, "GTA V", 159.99m },
                    { 3, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sua vingança contra os deuses do Olimpo agora é passado, e Kratos vive como um homem comum nas terras dos monstros e deuses nórdicos. E é nesse mundo inóspito e implacável que ele precisa lutar para sobreviver... e ensinar seu filho a fazer o mesmo.", (byte)3, "God Of War IV", 159.99m }
                });

            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "IdUsuario", "Email", "IdTipoUsuario", "Senha" },
                values: new object[,]
                {
                    { 2, "admin@admin.com", (byte)1, "admin" },
                    { 1, "comum@comum.com", (byte)2, "comum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTUDIO_NomeEstudio",
                table: "ESTUDIO",
                column: "NomeEstudio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JOGO_IdEstudio",
                table: "JOGO",
                column: "IdEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_TIPO_USUARIO_Titulo",
                table: "TIPO_USUARIO",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Email",
                table: "USUARIO",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IdTipoUsuario",
                table: "USUARIO",
                column: "IdTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JOGO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ESTUDIO");

            migrationBuilder.DropTable(
                name: "TIPO_USUARIO");
        }
    }
}
