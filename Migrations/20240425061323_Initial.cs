using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankBranchTable",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationURL = table.Column<string>(type: "TEXT", nullable: false),
                    BranchManager = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankBranchTable", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CivilId = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    BankBranchBankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_bankBranchTable_BankBranchBankId",
                        column: x => x.BankBranchBankId,
                        principalTable: "bankBranchTable",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "bankBranchTable",
                columns: new[] { "BankId", "BranchManager", "EmployeeCount", "LocationName", "LocationURL" },
                values: new object[,]
                {
                    { 1, "Mohammed Ali", 20, "Al-Jahra Branch", "https://maps.app.goo.gl/mPDxWzf5bcwgNCek9" },
                    { 2, "Saoud Faleh", 18, "Kaifan Branch", "https://maps.app.goo.gl/DnMgNCGQD1cpPJLFA" },
                    { 3, "Mubarak Mohammed", 24, "Al-Khaldiya Branch", "https://maps.app.goo.gl/R559DtfAFDN3f92g8" },
                    { 4, "Salem Ali", 35, "Farwaniya Branch", "https://maps.app.goo.gl/mmLBR5aSciF2k9q8A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BankBranchBankId",
                table: "Employees",
                column: "BankBranchBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CivilId",
                table: "Employees",
                column: "CivilId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "bankBranchTable");
        }
    }
}
