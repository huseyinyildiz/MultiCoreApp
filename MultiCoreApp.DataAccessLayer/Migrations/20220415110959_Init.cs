using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"), false, "Pencils" });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"), false, "Books" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("056230f2-74bd-41ba-8927-ec9b267a624e"), new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"), false, "Kurşun Pencil", 62.53m, 100 },
                    { new Guid("0afa79d4-fbb2-4e60-962a-e9602f4fce3f"), new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"), false, "Çizgili Book", 23.53m, 100 },
                    { new Guid("666b9199-3d90-469d-8dbb-dbe2ad9a06cc"), new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"), false, "Tükenmez Pencil", 122.53m, 100 },
                    { new Guid("8c9f19b5-11ea-4737-a098-85e77bf98624"), new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"), false, "Dolma Pencil", 12.53m, 100 },
                    { new Guid("c40c987b-0942-4cdc-9b46-9d98ca85394a"), new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"), false, "Dümdüz Book", 44.53m, 100 },
                    { new Guid("d4a925d1-8bcf-48d5-ac1f-bb0efd45c7b9"), new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"), false, "Kareli Book", 11.53m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
