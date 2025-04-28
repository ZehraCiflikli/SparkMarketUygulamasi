using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparkMarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class baslangic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiyatTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiyatTipiAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiyatTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndirimTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndirimTipAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirimTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "il",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ilKodu = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_il", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KargoFirması = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UstKategoriId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategori_Kategori",
                        column: x => x.UstKategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kdv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KdvOrani = table.Column<double>(type: "float", nullable: true),
                    KdvAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kdv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciTipiAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MenuIcon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UstMenuId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu",
                        column: x => x.UstMenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OdemeTuru",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeTuruAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ozellik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OzellikTipi = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozellikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDurum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisDurumAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDurum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeslimatTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeslimatTipiAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeslimatTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaksitSecenek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaId = table.Column<int>(type: "int", nullable: true),
                    TaksitSayisi = table.Column<int>(type: "int", nullable: true),
                    TaksitCizelge = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaksitSecenek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaksitSecenek_Banka",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Indirim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IndirimTipiId = table.Column<int>(type: "int", nullable: true),
                    IndirimDegeri = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KuponKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    MinTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KuponMu = table.Column<bool>(type: "bit", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indirim_IndirimTipi",
                        column: x => x.IndirimTipiId,
                        principalTable: "IndirimTipi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ilce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilceAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ilId = table.Column<int>(type: "int", nullable: true),
                    ilceKodu = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ilce_il",
                        column: x => x.ilId,
                        principalTable: "il",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TCKimlikNo = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmailOnay = table.Column<bool>(type: "bit", nullable: true),
                    CepTelefonuOnay = table.Column<bool>(type: "bit", nullable: true),
                    HataliGirisSayisi = table.Column<int>(type: "int", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KullaniciTipi = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanici_KullaniciTipi",
                        column: x => x.KullaniciTipi,
                        principalTable: "KullaniciTipi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirimId = table.Column<int>(type: "int", nullable: true),
                    KdvId = table.Column<int>(type: "int", nullable: true),
                    Stok = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_Birim",
                        column: x => x.BirimId,
                        principalTable: "Birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Urun_Kategori",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Urun_Kdv",
                        column: x => x.KdvId,
                        principalTable: "Kdv",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Urun_Marka",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KategoriOzellik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    OzellikId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriOzellik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategoriOzellik_Kategori",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KategoriOzellik_Ozellik",
                        column: x => x.OzellikId,
                        principalTable: "Ozellik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OzellikSecenek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzellikId = table.Column<int>(type: "int", nullable: true),
                    Secenek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzellikSecenek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OzellikSecenek_Ozellik",
                        column: x => x.OzellikId,
                        principalTable: "Ozellik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuYetki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    InsertYetki = table.Column<bool>(type: "bit", nullable: true),
                    UpdateYetki = table.Column<bool>(type: "bit", nullable: true),
                    DeleteYetki = table.Column<bool>(type: "bit", nullable: true),
                    SelectYetki = table.Column<bool>(type: "bit", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuYetki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuYetki_Menu",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuYetki_Rol",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciAdres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilId = table.Column<int>(type: "int", nullable: true),
                    ilceId = table.Column<int>(type: "int", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciAdres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciAdres_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciAdres_il",
                        column: x => x.ilId,
                        principalTable: "il",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciAdres_ilce",
                        column: x => x.ilceId,
                        principalTable: "ilce",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciKurumsal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    VergiNo = table.Column<int>(type: "int", nullable: true),
                    VergiDairesi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciKurumsal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciKurumsal_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullaniciRol_Rol",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Adet = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sepet_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sepet_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunFiyat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UrunFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FiyatTipiId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunFiyat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunFiyat_FiyatTipi",
                        column: x => x.FiyatTipiId,
                        principalTable: "FiyatTipi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunFiyat_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunIndirim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    IndirimId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunIndirim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunIndirim_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunOzellikDeger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    OzellikId = table.Column<int>(type: "int", nullable: true),
                    SecenekId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunOzellikDeger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunOzellikDeger_Ozellik",
                        column: x => x.OzellikId,
                        principalTable: "Ozellik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunOzellikDeger_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunResim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    ResimUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunResim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunResim_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunYorum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    Yorum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Puan = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Onay = table.Column<bool>(type: "bit", nullable: true),
                    OnayTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Onaylayan = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunYorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunYorum_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiparisKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TeslimatAdresId = table.Column<int>(type: "int", nullable: true),
                    FaturaAdresId = table.Column<int>(type: "int", nullable: true),
                    SiparisDurumId = table.Column<int>(type: "int", nullable: true),
                    IndirimId = table.Column<int>(type: "int", nullable: true),
                    TeslimatTipi = table.Column<int>(type: "int", nullable: true),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_Indirim",
                        column: x => x.IndirimId,
                        principalTable: "Indirim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparis_Kullanici",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparis_KullaniciAdres",
                        column: x => x.FaturaAdresId,
                        principalTable: "KullaniciAdres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparis_KullaniciAdres1",
                        column: x => x.TeslimatAdresId,
                        principalTable: "KullaniciAdres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparis_SiparisDurum",
                        column: x => x.SiparisDurumId,
                        principalTable: "SiparisDurum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Siparis_TeslimatTipi",
                        column: x => x.TeslimatTipi,
                        principalTable: "TeslimatTipi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: true),
                    KargoFisNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToplamTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fatura_Siparis",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: true),
                    OdemeTuruId = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Onay = table.Column<bool>(type: "bit", nullable: true),
                    OdemeTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BankaId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odeme_Banka",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odeme_OdemeTuru",
                        column: x => x.OdemeTuruId,
                        principalTable: "OdemeTuru",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odeme_Siparis",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    BirimFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    İndirimId = table.Column<int>(type: "int", nullable: true),
                    SatirToplami = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Siparis",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiparisKargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: true),
                    KargoId = table.Column<int>(type: "int", nullable: true),
                    TeslimatTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    GonderimTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Durumu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisKargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisKargo_Kargo",
                        column: x => x.KargoId,
                        principalTable: "Kargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiparisKargo_Siparis",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FaturaDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    BirimFiyati = table.Column<int>(type: "int", nullable: true),
                    SatirToplami = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OlusturanId = table.Column<int>(type: "int", nullable: true),
                    DegistirenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaDetay_Fatura",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FaturaDetay_Urun",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_SiparisId",
                table: "Fatura",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_FaturaId",
                table: "FaturaDetay",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_UrunId",
                table: "FaturaDetay",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Indirim_IndirimTipiId",
                table: "Indirim",
                column: "IndirimTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ilce_ilId",
                table: "ilce",
                column: "ilId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategori_UstKategoriId",
                table: "Kategori",
                column: "UstKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriOzellik_KategoriId",
                table: "KategoriOzellik",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KategoriOzellik_OzellikId",
                table: "KategoriOzellik",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_KullaniciTipi",
                table: "Kullanici",
                column: "KullaniciTipi");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAdres_ilceId",
                table: "KullaniciAdres",
                column: "ilceId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAdres_ilId",
                table: "KullaniciAdres",
                column: "ilId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAdres_KullaniciId",
                table: "KullaniciAdres",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciKurumsal_KullaniciId",
                table: "KullaniciKurumsal",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_KullaniciId",
                table: "KullaniciRol",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRol_RolId",
                table: "KullaniciRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_UstMenuId",
                table: "Menu",
                column: "UstMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuYetki_MenuId",
                table: "MenuYetki",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuYetki_RolId",
                table: "MenuYetki",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_BankaId",
                table: "Odeme",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_OdemeTuruId",
                table: "Odeme",
                column: "OdemeTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_SiparisId",
                table: "Odeme",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_OzellikSecenek_OzellikId",
                table: "OzellikSecenek",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_KullaniciId",
                table: "Sepet",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_UrunId",
                table: "Sepet",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_FaturaAdresId",
                table: "Siparis",
                column: "FaturaAdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_IndirimId",
                table: "Siparis",
                column: "IndirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_KullaniciId",
                table: "Siparis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_SiparisDurumId",
                table: "Siparis",
                column: "SiparisDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_TeslimatAdresId",
                table: "Siparis",
                column: "TeslimatAdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_TeslimatTipi",
                table: "Siparis",
                column: "TeslimatTipi");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKargo_KargoId",
                table: "SiparisKargo",
                column: "KargoId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKargo_SiparisId",
                table: "SiparisKargo",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_TaksitSecenek_BankaId",
                table: "TaksitSecenek",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_BirimId",
                table: "Urun",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KdvId",
                table: "Urun",
                column: "KdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_MarkaId",
                table: "Urun",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunFiyat_FiyatTipiId",
                table: "UrunFiyat",
                column: "FiyatTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunFiyat_UrunId",
                table: "UrunFiyat",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunIndirim_UrunId",
                table: "UrunIndirim",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunOzellikDeger_OzellikId",
                table: "UrunOzellikDeger",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunOzellikDeger_UrunId",
                table: "UrunOzellikDeger",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunResim_UrunId",
                table: "UrunResim",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYorum_UrunId",
                table: "UrunYorum",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaDetay");

            migrationBuilder.DropTable(
                name: "KategoriOzellik");

            migrationBuilder.DropTable(
                name: "KullaniciKurumsal");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropTable(
                name: "MenuYetki");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropTable(
                name: "OzellikSecenek");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "SiparisKargo");

            migrationBuilder.DropTable(
                name: "TaksitSecenek");

            migrationBuilder.DropTable(
                name: "UrunFiyat");

            migrationBuilder.DropTable(
                name: "UrunIndirim");

            migrationBuilder.DropTable(
                name: "UrunOzellikDeger");

            migrationBuilder.DropTable(
                name: "UrunResim");

            migrationBuilder.DropTable(
                name: "UrunYorum");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "OdemeTuru");

            migrationBuilder.DropTable(
                name: "Kargo");

            migrationBuilder.DropTable(
                name: "Banka");

            migrationBuilder.DropTable(
                name: "FiyatTipi");

            migrationBuilder.DropTable(
                name: "Ozellik");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Kdv");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Indirim");

            migrationBuilder.DropTable(
                name: "KullaniciAdres");

            migrationBuilder.DropTable(
                name: "SiparisDurum");

            migrationBuilder.DropTable(
                name: "TeslimatTipi");

            migrationBuilder.DropTable(
                name: "IndirimTipi");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "ilce");

            migrationBuilder.DropTable(
                name: "KullaniciTipi");

            migrationBuilder.DropTable(
                name: "il");
        }
    }
}
