using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebAppDemo.AbsenceService.DataAccess.Entities;

#nullable disable

namespace WebAppDemo.AbsenceService.DataAccess.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "AbsenceTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AbsenceTypes", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Countries",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ShortName = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Countries", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "States",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CountryId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_States", x => x.Id);
                table.ForeignKey(
                    name: "FK_States_Countries_CountryId",
                    column: x => x.CountryId,
                    principalTable: "Countries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Addresses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                ZipCode = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                HouseNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                HouseNumberAddition = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                    .Annotation("MySql:CharSet", "utf8mb4"),
                StateId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Addresses", x => x.Id);
                table.ForeignKey(
                    name: "FK_Addresses_States_StateId",
                    column: x => x.StateId,
                    principalTable: "States",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                AddressId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    name: "FK_Employees_Addresses_AddressId",
                    column: x => x.AddressId,
                    principalTable: "Addresses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Absences",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                AbsencseTypeId = table.Column<int>(type: "int", nullable: false),
                Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                End = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                EmployeeId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Absences", x => x.Id);
                table.ForeignKey(
                    name: "FK_Absences_AbsenceTypes_AbsencseTypeId",
                    column: x => x.AbsencseTypeId,
                    principalTable: "AbsenceTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Absences_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateIndex(
            name: "IX_Absences_AbsencseTypeId",
            table: "Absences",
            column: "AbsencseTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Absences_EmployeeId",
            table: "Absences",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_AbsenceTypes_Name",
            table: "AbsenceTypes",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Addresses_StateId",
            table: "Addresses",
            column: "StateId");

        migrationBuilder.CreateIndex(
            name: "IX_Employees_AddressId",
            table: "Employees",
            column: "AddressId");

        migrationBuilder.CreateIndex(
            name: "IX_States_CountryId",
            table: "States",
            column: "CountryId");

        migrationBuilder.CreateIndex(
            name: "IX_States_Name",
            table: "States",
            column: "Name",
            unique: true);

        CreateInitDataset(migrationBuilder);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Absences");

        migrationBuilder.DropTable(
            name: "AbsenceTypes");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Addresses");

        migrationBuilder.DropTable(
            name: "States");

        migrationBuilder.DropTable(
            name: "Countries");
    }

    private void CreateInitDataset(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Countries",
            columns: new[] 
            { 
                nameof(Country.FullName),
                nameof(Country.ShortName) 
            },
            values: new object[,]
            {
                { "Germany", "GER" },
                { "France", "FRE" },
                { "United States of America", "USA" }
            }
        );

        migrationBuilder.InsertData(
            table: "States",
            columns: new[] 
            { 
                nameof(State.Name),
                nameof(State.CountryId) 
            },
            values: new object[,]
            {
                { "Niedersachsen", "1" },
                { "Bayern", "1" },
                { "Brittany", "2" },
                { "Normandy", "2" },
                { "Texas", "3" },
                { "Washingtion", "3" }
            }
        );

        migrationBuilder.InsertData(
            table: "AbsenceTypes",
            columns: new[] 
            { 
                nameof(AbsenceType.Name) 
            },
            values: new object[,]
            {
                { "Vacation" },
                { "Special Vacation" },
                { "Maternity protection" }
            }
        );

        migrationBuilder.InsertData(
            table: "Addresses",
            columns: new[] 
            {
                nameof(Address.ZipCode),
                nameof(Address.City),
                nameof(Address.Street),
                nameof(Address.HouseNumber),
                nameof(Address.HouseNumberAddition),
                nameof(Address.StateId)
            },
            values: new object[,]
            {
                { "27804", "Berne", "Deichweg", "328", "a", "1" },
                { "27798", "Hude", "Rudolf-Kinau-Straße", "4", "", "1" },
                { "85111", "Adelschlag", "Bahnhofstaße", "15", "", "2" },
                { "85111", "Adelschlag", "Saumweg", "9", "", "2" },

                { "22200", "Guingamp", "Rue du Dr Corson", "35", "", "3" },
                { "22200", "Guingamp", "Rue de la Brasserie", "3", "", "3" },
                { "14000", "Caen", "All. des Aubépines", "7", "", "4"},
                { "14000", "Caen" , "Rue de Bretagne", "45", "", "4"},

                { "76501", "Temple", "S 30th St", "1414", "A", "5" },
                { "76501", "Temple", "S 30th St", "1212", "", "5" },
                { "76681", "Richland", "Main St", "106", "", "6" },
                { "76681", "Richland", "Main St", "502", "", "6" }
            }
        );

        migrationBuilder.InsertData(
            table: "Employees",
            columns: new[] 
            { 
                nameof(Employee.FirstName),
                nameof(Employee.LastName),
                nameof(Employee.AddressId)
            },
            values: new object[,]
            {
                { "Robin", "Smit", "1" },
                { "Roland", "Senftleben", "2" },
                { "Rudolf", "Schmidt", "3" },
                { "Michael", "Schwarz", "4" },
                { "Katrin", "Müller", "5" },
                { "Christin", "von Lindern", "6" },
                { "Lutz", "Dirkes", "7" },
                { "Adam", "Flegel", "8" },
                { "Ludolf", "Mitchel", "9" },
                { "Werner", "Rud", "10" },
                { "Christian", "Reichelt", "11" },
                { "Ulf", "Morthal", "12" }
            }
        );
    }
}
