using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Angular_Senti.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DynamicTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicRows_DynamicTables_DynamicTableId",
                        column: x => x.DynamicTableId,
                        principalTable: "DynamicTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicRows_DynamicTableId",
                table: "DynamicRows",
                column: "DynamicTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicRows");

            migrationBuilder.DropTable(
                name: "DynamicTables");
        }
    }
}
