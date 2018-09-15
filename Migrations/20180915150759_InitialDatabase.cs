using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoWebApi.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Key = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloPost = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    DescricaoPost = table.Column<string>(unicode: false, nullable: true),
                    CategoriaId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK__Post__CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome", "Key" },
                values: new object[] { 1, "CSHARP", "csharp" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome", "Key" },
                values: new object[] { 2, "VISUAL STUDIO 2017", "visualstudio" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome", "Key" },
                values: new object[] { 3, "SQL SERVER", "sqlserver" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome", "Key" },
                values: new object[] { 4, "ASP.NET CORE", "aspnetcore" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoriaId",
                table: "Post",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
