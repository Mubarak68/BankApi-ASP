using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialValuesForSec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_bankBranchTable_BankBranchBankId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "bankBranchTable");

            migrationBuilder.RenameColumn(
                name: "BankBranchBankId",
                table: "Employees",
                newName: "BankBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankBranchBankId",
                table: "Employees",
                newName: "IX_Employees_BankBranchId");

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationURL = table.Column<string>(type: "TEXT", nullable: false),
                    BranchManager = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BankBranches_BankBranchId",
                table: "Employees",
                column: "BankBranchId",
                principalTable: "BankBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BankBranches_BankBranchId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.RenameColumn(
                name: "BankBranchId",
                table: "Employees",
                newName: "BankBranchBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankBranchId",
                table: "Employees",
                newName: "IX_Employees_BankBranchBankId");

            migrationBuilder.CreateTable(
                name: "bankBranchTable",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchManager = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationURL = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankBranchTable", x => x.BankId);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_bankBranchTable_BankBranchBankId",
                table: "Employees",
                column: "BankBranchBankId",
                principalTable: "bankBranchTable",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
