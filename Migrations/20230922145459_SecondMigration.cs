using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    AwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.AwardId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Pegi_labels",
                columns: table => new
                {
                    Pegi_labelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegi_labels", x => x.Pegi_labelId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Software_houses",
                columns: table => new
                {
                    Software_houseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_houses", x => x.Software_houseId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Software_houseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogames_Software_houses_Software_houseId",
                        column: x => x.Software_houseId,
                        principalTable: "Software_houses",
                        principalColumn: "Software_houseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTournament",
                columns: table => new
                {
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false),
                    TournamentsTournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournament", x => new { x.PlayersPlayerId, x.TournamentsTournamentId });
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Tournaments_TournamentsTournamentId",
                        column: x => x.TournamentsTournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwardVideogame",
                columns: table => new
                {
                    AwardsAwardId = table.Column<int>(type: "int", nullable: false),
                    VideogamesVideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardVideogame", x => new { x.AwardsAwardId, x.VideogamesVideogameId });
                    table.ForeignKey(
                        name: "FK_AwardVideogame_Awards_AwardsAwardId",
                        column: x => x.AwardsAwardId,
                        principalTable: "Awards",
                        principalColumn: "AwardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardVideogame_Videogames_VideogamesVideogameId",
                        column: x => x.VideogamesVideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryVideogame",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    VideogamesVideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVideogame", x => new { x.CategoriesCategoryId, x.VideogamesVideogameId });
                    table.ForeignKey(
                        name: "FK_CategoryVideogame_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVideogame_Videogames_VideogamesVideogameId",
                        column: x => x.VideogamesVideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceVideogame",
                columns: table => new
                {
                    DevicesDeviceId = table.Column<int>(type: "int", nullable: false),
                    VideogamesVideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceVideogame", x => new { x.DevicesDeviceId, x.VideogamesVideogameId });
                    table.ForeignKey(
                        name: "FK_DeviceVideogame_Devices_DevicesDeviceId",
                        column: x => x.DevicesDeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceVideogame_Videogames_VideogamesVideogameId",
                        column: x => x.VideogamesVideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pegi_labelVideogame",
                columns: table => new
                {
                    Pegi_labelsPegi_labelId = table.Column<int>(type: "int", nullable: false),
                    VideoGamesVideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegi_labelVideogame", x => new { x.Pegi_labelsPegi_labelId, x.VideoGamesVideogameId });
                    table.ForeignKey(
                        name: "FK_Pegi_labelVideogame_Pegi_labels_Pegi_labelsPegi_labelId",
                        column: x => x.Pegi_labelsPegi_labelId,
                        principalTable: "Pegi_labels",
                        principalColumn: "Pegi_labelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegi_labelVideogame_Videogames_VideoGamesVideogameId",
                        column: x => x.VideoGamesVideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentVideogame",
                columns: table => new
                {
                    TournamentsTournamentId = table.Column<int>(type: "int", nullable: false),
                    VideogamesVideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentVideogame", x => new { x.TournamentsTournamentId, x.VideogamesVideogameId });
                    table.ForeignKey(
                        name: "FK_TournamentVideogame_Tournaments_TournamentsTournamentId",
                        column: x => x.TournamentsTournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentVideogame_Videogames_VideogamesVideogameId",
                        column: x => x.VideogamesVideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardVideogame_VideogamesVideogameId",
                table: "AwardVideogame",
                column: "VideogamesVideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVideogame_VideogamesVideogameId",
                table: "CategoryVideogame",
                column: "VideogamesVideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVideogame_VideogamesVideogameId",
                table: "DeviceVideogame",
                column: "VideogamesVideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegi_labelVideogame_VideoGamesVideogameId",
                table: "Pegi_labelVideogame",
                column: "VideoGamesVideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournament_TournamentsTournamentId",
                table: "PlayerTournament",
                column: "TournamentsTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_VideogameId",
                table: "Reviews",
                column: "VideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentVideogame_VideogamesVideogameId",
                table: "TournamentVideogame",
                column: "VideogamesVideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_Software_houseId",
                table: "Videogames",
                column: "Software_houseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardVideogame");

            migrationBuilder.DropTable(
                name: "CategoryVideogame");

            migrationBuilder.DropTable(
                name: "DeviceVideogame");

            migrationBuilder.DropTable(
                name: "Pegi_labelVideogame");

            migrationBuilder.DropTable(
                name: "PlayerTournament");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TournamentVideogame");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Pegi_labels");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Software_houses");
        }
    }
}
