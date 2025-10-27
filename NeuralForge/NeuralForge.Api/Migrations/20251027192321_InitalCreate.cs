using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuralForge.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chips",
                columns: table => new
                {
                    chip_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    chip_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    number_of_cores = table.Column<int>(type: "int", nullable: false),
                    production_time = table.Column<double>(type: "double", precision: 18, scale: 2, nullable: false),
                    market_price = table.Column<double>(type: "double", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chips", x => x.chip_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sites",
                columns: table => new
                {
                    site_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    location = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    number_of_lines = table.Column<int>(type: "int", nullable: false),
                    chips_per_hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sites", x => x.site_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "assembly_lines",
                columns: table => new
                {
                    assembly_line_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    site_id = table.Column<int>(type: "int", nullable: false),
                    chip_id = table.Column<int>(type: "int", nullable: false),
                    number_of_machines = table.Column<int>(type: "int", nullable: true),
                    chips_per_hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assembly_lines", x => x.assembly_line_id);
                    table.ForeignKey(
                        name: "FK_assembly_lines_chips_chip_id",
                        column: x => x.chip_id,
                        principalTable: "chips",
                        principalColumn: "chip_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assembly_lines_sites_site_id",
                        column: x => x.site_id,
                        principalTable: "sites",
                        principalColumn: "site_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "downtime_events",
                columns: table => new
                {
                    downtime_event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    assembly_line_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    event_type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_downtime_events", x => x.downtime_event_id);
                    table.ForeignKey(
                        name: "FK_downtime_events_assembly_lines_assembly_line_id",
                        column: x => x.assembly_line_id,
                        principalTable: "assembly_lines",
                        principalColumn: "assembly_line_id");
                    table.ForeignKey(
                        name: "FK_downtime_events_chips_ChipId",
                        column: x => x.ChipId,
                        principalTable: "chips",
                        principalColumn: "chip_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "production_records",
                columns: table => new
                {
                    production_record_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    assembly_line_id = table.Column<int>(type: "int", nullable: false),
                    number_of_chips = table.Column<int>(type: "int", nullable: false),
                    hour_of_day = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production_records", x => x.production_record_id);
                    table.ForeignKey(
                        name: "FK_production_records_assembly_lines_assembly_line_id",
                        column: x => x.assembly_line_id,
                        principalTable: "assembly_lines",
                        principalColumn: "assembly_line_id");
                    table.ForeignKey(
                        name: "FK_production_records_chips_ChipId",
                        column: x => x.ChipId,
                        principalTable: "chips",
                        principalColumn: "chip_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_assembly_lines_chip_id",
                table: "assembly_lines",
                column: "chip_id");

            migrationBuilder.CreateIndex(
                name: "IX_assembly_lines_site_id",
                table: "assembly_lines",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_downtime_events_assembly_line_id",
                table: "downtime_events",
                column: "assembly_line_id");

            migrationBuilder.CreateIndex(
                name: "IX_downtime_events_ChipId",
                table: "downtime_events",
                column: "ChipId");

            migrationBuilder.CreateIndex(
                name: "IX_production_records_assembly_line_id",
                table: "production_records",
                column: "assembly_line_id");

            migrationBuilder.CreateIndex(
                name: "IX_production_records_ChipId",
                table: "production_records",
                column: "ChipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "downtime_events");

            migrationBuilder.DropTable(
                name: "production_records");

            migrationBuilder.DropTable(
                name: "assembly_lines");

            migrationBuilder.DropTable(
                name: "chips");

            migrationBuilder.DropTable(
                name: "sites");
        }
    }
}
