using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CCM.Domain.Migrations
{
    public partial class DatabaseInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "day",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organisation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: true, defaultValueSql: "'NULL'"),
                    Capacity = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'0'"),
                    AuthorizedCapacity = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'100'"),
                    OrganisationId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_map", x => x.Id);
                    table.ForeignKey(
                        name: "map_organisation_Id_fk",
                        column: x => x.OrganisationId,
                        principalTable: "organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    LastName = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    Email = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "'NULL'"),
                    Password = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "'NULL'"),
                    RoleId = table.Column<int>(type: "int(11)", nullable: false),
                    OrganisationId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "user_organisation_Id_fk",
                        column: x => x.OrganisationId,
                        principalTable: "organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_role_Id_fk",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "openingtime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OpeningHour = table.Column<string>(maxLength: 100, nullable: false),
                    ClosingHour = table.Column<string>(maxLength: 100, nullable: false),
                    MapId = table.Column<int>(type: "int(11)", nullable: false),
                    DayId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_openingtime", x => x.Id);
                    table.ForeignKey(
                        name: "openingtime_day_Id_fk",
                        column: x => x.DayId,
                        principalTable: "day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "openingtime_map_Id_fk",
                        column: x => x.MapId,
                        principalTable: "map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    x = table.Column<int>(type: "int(11)", nullable: true),
                    y = table.Column<int>(type: "int(11)", nullable: true),
                    MapId = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seat", x => x.Id);
                    table.ForeignKey(
                        name: "seat_map_Id_fk",
                        column: x => x.MapId,
                        principalTable: "map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    StartHour = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    EndHour = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    Link = table.Column<string>(nullable: true),
                    SeatId = table.Column<int>(type: "int(11)", nullable: false),
                    UserId = table.Column<int>(type: "int(11)", nullable: false),
                    EventId = table.Column<int>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "reservation_seat_Id_fk",
                        column: x => x.SeatId,
                        principalTable: "seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "reservation_user_Id_fk",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "map_organisation_Id_fk",
                table: "map",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "openingtime_day_Id_fk",
                table: "openingtime",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "openingtime_map_Id_fk",
                table: "openingtime",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "reservation_seat_Id_fk",
                table: "reservation",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "reservation_user_Id_fk",
                table: "reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "seat_map_Id_fk",
                table: "seat",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "user_organisation_Id_fk",
                table: "user",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "user_role_Id_fk",
                table: "user",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "openingtime");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "day");

            migrationBuilder.DropTable(
                name: "seat");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "map");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "organisation");
        }
    }
}
