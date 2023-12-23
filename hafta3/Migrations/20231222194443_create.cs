using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hafta3.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Besinler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Besinler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Konum = table.Column<string>(type: "TEXT", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    Soyadi = table.Column<string>(type: "TEXT", nullable: false),
                    TC = table.Column<string>(type: "TEXT", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvcilHayvanlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isim = table.Column<string>(type: "TEXT", nullable: false),
                    Kodu = table.Column<int>(type: "INTEGER", nullable: false),
                    Tur = table.Column<string>(type: "TEXT", nullable: false),
                    KullaniciID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvcilHayvanlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvcilHayvanlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aktiviteler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktiviteler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aktiviteler_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beslenme",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BesinlerID = table.Column<int>(type: "INTEGER", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beslenme", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beslenme_Besinler_BesinlerID",
                        column: x => x.BesinlerID,
                        principalTable: "Besinler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beslenme_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Egitimler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EgitimTuru = table.Column<string>(type: "TEXT", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Durum = table.Column<string>(type: "TEXT", nullable: false),
                    Notlar = table.Column<string>(type: "TEXT", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitimler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Egitimler_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaglikDurumlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DurumAdi = table.Column<string>(type: "TEXT", nullable: false),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HastaMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaglikDurumlari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaglikDurumlari_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SosyalEtkilesimler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EtkinlikID = table.Column<int>(type: "INTEGER", nullable: false),
                    EvcilHayvanID = table.Column<int>(type: "INTEGER", nullable: false),
                    isSilindi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalEtkilesimler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SosyalEtkilesimler_Etkinlikler_EtkinlikID",
                        column: x => x.EtkinlikID,
                        principalTable: "Etkinlikler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SosyalEtkilesimler_EvcilHayvanlar_EvcilHayvanID",
                        column: x => x.EvcilHayvanID,
                        principalTable: "EvcilHayvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktiviteler_EvcilHayvanID",
                table: "Aktiviteler",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Beslenme_BesinlerID",
                table: "Beslenme",
                column: "BesinlerID");

            migrationBuilder.CreateIndex(
                name: "IX_Beslenme_EvcilHayvanID",
                table: "Beslenme",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Egitimler_EvcilHayvanID",
                table: "Egitimler",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_EvcilHayvanlar_KullaniciID",
                table: "EvcilHayvanlar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_SaglikDurumlari_EvcilHayvanID",
                table: "SaglikDurumlari",
                column: "EvcilHayvanID");

            migrationBuilder.CreateIndex(
                name: "IX_SosyalEtkilesimler_EtkinlikID",
                table: "SosyalEtkilesimler",
                column: "EtkinlikID");

            migrationBuilder.CreateIndex(
                name: "IX_SosyalEtkilesimler_EvcilHayvanID",
                table: "SosyalEtkilesimler",
                column: "EvcilHayvanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktiviteler");

            migrationBuilder.DropTable(
                name: "Beslenme");

            migrationBuilder.DropTable(
                name: "Egitimler");

            migrationBuilder.DropTable(
                name: "SaglikDurumlari");

            migrationBuilder.DropTable(
                name: "SosyalEtkilesimler");

            migrationBuilder.DropTable(
                name: "Besinler");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "EvcilHayvanlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
