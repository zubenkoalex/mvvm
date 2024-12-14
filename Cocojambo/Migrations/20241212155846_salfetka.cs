using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cocojambo.Migrations
{
    /// <inheritdoc />
    public partial class salfetka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenerationEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameGeneration = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Generati__3214EC07F4B7FCEF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarkEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameMark = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MarkEnti__3214EC076EEB34C5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameModelCar = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModelEnt__3214EC0751E504B4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacageEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EngineVolume = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false),
                    KPPType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CallType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CallColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Rudder = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NamePacage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PacageEn__3214EC0791A6B555", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MarkID = table.Column<int>(type: "int", nullable: true),
                    ModelID = table.Column<int>(type: "int", nullable: true),
                    GenerationID = table.Column<int>(type: "int", nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    PacageID = table.Column<int>(type: "int", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarEntit__3214EC07C6B45D39", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CarEntiti__Gener__412EB0B6",
                        column: x => x.GenerationID,
                        principalTable: "GenerationEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CarEntiti__MarkI__3F466844",
                        column: x => x.MarkID,
                        principalTable: "MarkEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CarEntiti__Model__403A8C7D",
                        column: x => x.ModelID,
                        principalTable: "ModelEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CarEntiti__Pacag__4222D4EF",
                        column: x => x.PacageID,
                        principalTable: "PacageEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEntities_GenerationID",
                table: "CarEntities",
                column: "GenerationID");

            migrationBuilder.CreateIndex(
                name: "IX_CarEntities_MarkID",
                table: "CarEntities",
                column: "MarkID");

            migrationBuilder.CreateIndex(
                name: "IX_CarEntities_ModelID",
                table: "CarEntities",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CarEntities_PacageID",
                table: "CarEntities",
                column: "PacageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEntities");

            migrationBuilder.DropTable(
                name: "GenerationEntities");

            migrationBuilder.DropTable(
                name: "MarkEntities");

            migrationBuilder.DropTable(
                name: "ModelEntities");

            migrationBuilder.DropTable(
                name: "PacageEntities");
        }
    }
}
