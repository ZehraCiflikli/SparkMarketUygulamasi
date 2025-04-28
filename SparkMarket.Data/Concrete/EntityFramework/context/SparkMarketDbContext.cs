using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SparkMarket.Infrastructure.Interceptors;
using SparkMarket.Model.Entity;

namespace SparkMarket.Data.Concrete.EntityFramework.context;

public partial class SparkMarketDbContext : DbContext
{

    public SparkMarketDbContext()
    {


    }
    //public SparkMarketDbContext(DbContextOptions<SparkMarketDbContext> options): base(options)
    //{



    //}


    public virtual DbSet<Banka> Bankas { get; set; }

    public virtual DbSet<Birim> Birims { get; set; }

    public virtual DbSet<Fatura> Faturas { get; set; }

    public virtual DbSet<FaturaDetay> FaturaDetays { get; set; }

    public virtual DbSet<FiyatTipi> FiyatTipis { get; set; }

    public virtual DbSet<Il> Ils { get; set; }

    public virtual DbSet<Ilce> Ilces { get; set; }

    public virtual DbSet<Indirim> Indirims { get; set; }

    public virtual DbSet<IndirimTipi> IndirimTipis { get; set; }

    public virtual DbSet<Kargo> Kargos { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<KategoriOzellik> KategoriOzelliks { get; set; }

    public virtual DbSet<Kdv> Kdvs { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<KullaniciAdre> KullaniciAdres { get; set; }

    public virtual DbSet<KullaniciKurumsal> KullaniciKurumsals { get; set; }

    public virtual DbSet<KullaniciRol> KullaniciRols { get; set; }

    public virtual DbSet<KullaniciTipi> KullaniciTipis { get; set; }

    public virtual DbSet<Marka> Markas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuYetki> MenuYetkis { get; set; }

    public virtual DbSet<Odeme> Odemes { get; set; }

    public virtual DbSet<OdemeTuru> OdemeTurus { get; set; }

    public virtual DbSet<Ozellik> Ozelliks { get; set; }

    public virtual DbSet<OzellikSecenek> OzellikSeceneks { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<Sipari> Siparis { get; set; }

    public virtual DbSet<SiparisDetay> SiparisDetays { get; set; }

    public virtual DbSet<SiparisDurum> SiparisDurums { get; set; }

    public virtual DbSet<SiparisKargo> SiparisKargos { get; set; }

    public virtual DbSet<TaksitSecenek> TaksitSeceneks { get; set; }

    public virtual DbSet<TeslimatTipi> TeslimatTipis { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<UrunFiyat> UrunFiyats { get; set; }

    public virtual DbSet<UrunIndirim> UrunIndirims { get; set; }

    public virtual DbSet<UrunOzellikDeger> UrunOzellikDegers { get; set; }

    public virtual DbSet<UrunResim> UrunResims { get; set; }

    public virtual DbSet<UrunYorum> UrunYorums { get; set; }
    public virtual DbSet<Rapor> Rapor { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        // INTERCEPTOR
        //optionsBuilder.AddInterceptors(_auditInterceptor);

        optionsBuilder.UseSqlServer("server=DESKTOP-CI46R5B;database=SparkMarketDB;trusted_connection=true;TrustServerCertificate=true;").AddInterceptors(new AuditInterceptor());

        //optionsBuilder.UseSqlServer("server= sql8006.site4now.net;database=db_aa2c0a_sparkuser;user id =db_aa2c0a_sparkuser_admin;password=Dlza0311;TrustServerCertificate=true;").AddInterceptors(new AuditInterceptor());



    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banka>(entity =>
        {
            entity.ToTable("Banka");

            entity.Property(e => e.BankaAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Birim>(entity =>
        {
            entity.ToTable("Birim");

            entity.Property(e => e.BirimAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.ToTable("Fatura");

            entity.Property(e => e.FaturaNo).HasMaxLength(50);
            entity.Property(e => e.FaturaTarihi).HasColumnType("datetime");
            entity.Property(e => e.KargoFisNo).HasMaxLength(50);
            entity.Property(e => e.ToplamTutari).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Siparis).WithMany(p => p.Faturas)
                .HasForeignKey(d => d.SiparisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fatura_Siparis");
        });

        modelBuilder.Entity<FaturaDetay>(entity =>
        {
            entity.ToTable("FaturaDetay");

            entity.HasOne(d => d.Fatura).WithMany(p => p.FaturaDetays)
                .HasForeignKey(d => d.FaturaId)
                .HasConstraintName("FK_FaturaDetay_Fatura");

            entity.HasOne(d => d.Urun).WithMany(p => p.FaturaDetays)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_FaturaDetay_Urun");
        });

        modelBuilder.Entity<FiyatTipi>(entity =>
        {
            entity.ToTable("FiyatTipi");

            entity.Property(e => e.FiyatTipiAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Il>(entity =>
        {
            entity.ToTable("il");

            entity.Property(e => e.IlAdi)
                .HasMaxLength(50)
                .HasColumnName("ilAdi");
            entity.Property(e => e.IlKodu).HasColumnName("ilKodu");
        });

        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.ToTable("ilce");

            entity.Property(e => e.IlId).HasColumnName("ilId");
            entity.Property(e => e.IlceAdi)
                .HasMaxLength(50)
                .HasColumnName("ilceAdi");
            entity.Property(e => e.IlceKodu).HasColumnName("ilceKodu");

            entity.HasOne(d => d.Il).WithMany(p => p.Ilces)
                .HasForeignKey(d => d.IlId)
                .HasConstraintName("FK_ilce_il");
        });

        modelBuilder.Entity<Indirim>(entity =>
        {
            entity.ToTable("Indirim");

            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.Baslik).HasMaxLength(100);
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.IndirimDegeri).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.KuponKodu).HasMaxLength(50);
            entity.Property(e => e.MinTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IndirimTipi).WithMany(p => p.Indirims)
                .HasForeignKey(d => d.IndirimTipiId)
                .HasConstraintName("FK_Indirim_IndirimTipi");
        });

        modelBuilder.Entity<IndirimTipi>(entity =>
        {
            entity.ToTable("IndirimTipi");

            entity.Property(e => e.IndirimTipAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Kargo>(entity =>
        {
            entity.ToTable("Kargo");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.ToTable("Kategori");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(110);
            entity.Property(e => e.KategoriAdi).HasMaxLength(50);
            entity.Property(e => e.Keywords).HasMaxLength(70);
            entity.Property(e => e.Resim).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(70);

            entity.HasOne(d => d.UstKategori).WithMany(p => p.InverseUstKategori)
                .HasForeignKey(d => d.UstKategoriId)
                .HasConstraintName("FK_Kategori_Kategori");
        });

        modelBuilder.Entity<KategoriOzellik>(entity =>
        {
            entity.ToTable("KategoriOzellik");

            entity.HasOne(d => d.Kategori).WithMany(p => p.KategoriOzelliks)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK_KategoriOzellik_Kategori");

            entity.HasOne(d => d.Ozellik).WithMany(p => p.KategoriOzelliks)
                .HasForeignKey(d => d.OzellikId)
                .HasConstraintName("FK_KategoriOzellik_Ozellik");
        });

        modelBuilder.Entity<Kdv>(entity =>
        {
            entity.ToTable("Kdv");

            entity.Property(e => e.KdvAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");

            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.CepTelefonu).HasMaxLength(50);
            entity.Property(e => e.DogumTarihi).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.OlusturulmaTarihi).HasColumnType("datetime");
            entity.Property(e => e.Resim).HasMaxLength(100);
            entity.Property(e => e.Sifre).HasMaxLength(100);
            entity.Property(e => e.Soyadi).HasMaxLength(50);
            entity.Property(e => e.TckimlikNo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCKimlikNo");
            entity.Property(e => e.Telefon).HasMaxLength(50);

            entity.HasOne(d => d.KullaniciTipiNavigation).WithMany(p => p.Kullanicis)
                .HasForeignKey(d => d.KullaniciTipi)
                .HasConstraintName("FK_Kullanici_KullaniciTipi");
        });

        modelBuilder.Entity<KullaniciAdre>(entity =>
        {
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.IlId).HasColumnName("ilId");
            entity.Property(e => e.IlceId).HasColumnName("ilceId");

            entity.HasOne(d => d.Il).WithMany(p => p.KullaniciAdres)
                .HasForeignKey(d => d.IlId)
                .HasConstraintName("FK_KullaniciAdres_il");

            entity.HasOne(d => d.Ilce).WithMany(p => p.KullaniciAdres)
                .HasForeignKey(d => d.IlceId)
                .HasConstraintName("FK_KullaniciAdres_ilce");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciAdres)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_KullaniciAdres_Kullanici");
        });

        modelBuilder.Entity<KullaniciKurumsal>(entity =>
        {
            entity.ToTable("KullaniciKurumsal");

            entity.Property(e => e.VergiDairesi).HasMaxLength(50);

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciKurumsals)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_KullaniciKurumsal_Kullanici");
        });

        modelBuilder.Entity<KullaniciRol>(entity =>
        {
            entity.ToTable("KullaniciRol");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_KullaniciRol_Kullanici");

            entity.HasOne(d => d.Rol).WithMany(p => p.KullaniciRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_KullaniciRol_Rol");
        });

        modelBuilder.Entity<KullaniciTipi>(entity =>
        {
            entity.ToTable("KullaniciTipi");

            entity.Property(e => e.KullaniciTipiAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Marka>(entity =>
        {
            entity.ToTable("Marka");

            entity.Property(e => e.MarkaAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Aciklama).HasMaxLength(200);
            entity.Property(e => e.Baslik).HasMaxLength(50);
            entity.Property(e => e.MenuIcon).HasMaxLength(200);

            entity.HasOne(d => d.UstMenu).WithMany(p => p.InverseUstMenu)
                .HasForeignKey(d => d.UstMenuId)
                .HasConstraintName("FK_Menu_Menu");
        });

        modelBuilder.Entity<MenuYetki>(entity =>
        {
            entity.ToTable("MenuYetki");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuYetkis)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_MenuYetki_Menu");

            entity.HasOne(d => d.Rol).WithMany(p => p.MenuYetkis)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_MenuYetki_Rol");
        });

        modelBuilder.Entity<Odeme>(entity =>
        {
            entity.ToTable("Odeme");

            entity.Property(e => e.OdemeTutari).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tarih).HasColumnType("datetime");

            entity.HasOne(d => d.Banka).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.BankaId)
                .HasConstraintName("FK_Odeme_Banka");

            entity.HasOne(d => d.OdemeTuru).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.OdemeTuruId)
                .HasConstraintName("FK_Odeme_OdemeTuru");

            entity.HasOne(d => d.Siparis).WithMany(p => p.Odemes)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK_Odeme_Siparis");
        });

        modelBuilder.Entity<OdemeTuru>(entity =>
        {
            entity.ToTable("OdemeTuru");

            entity.Property(e => e.OdemeTuruAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Ozellik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ozellikler");

            entity.ToTable("Ozellik");

            entity.Property(e => e.OzellikAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<OzellikSecenek>(entity =>
        {
            entity.ToTable("OzellikSecenek");

            entity.Property(e => e.Secenek).HasMaxLength(50);

            entity.HasOne(d => d.Ozellik).WithMany(p => p.OzellikSeceneks)
                .HasForeignKey(d => d.OzellikId)
                .HasConstraintName("FK_OzellikSecenek_Ozellik");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.RolAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.ToTable("Sepet");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_Sepet_Kullanici");

            entity.HasOne(d => d.Urun).WithMany(p => p.Sepets)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_Sepet_Urun");
        });

        modelBuilder.Entity<Sipari>(entity =>
        {
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.SiparisKodu).HasMaxLength(50);
            entity.Property(e => e.SiparisTarihi).HasColumnType("datetime");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.FaturaAdres).WithMany(p => p.SipariFaturaAdres)
                .HasForeignKey(d => d.FaturaAdresId)
                .HasConstraintName("FK_Siparis_KullaniciAdres");

            entity.HasOne(d => d.Indirim).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.IndirimId)
                .HasConstraintName("FK_Siparis_Indirim");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("FK_Siparis_Kullanici");

            entity.HasOne(d => d.SiparisDurum).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.SiparisDurumId)
                .HasConstraintName("FK_Siparis_SiparisDurum");

            entity.HasOne(d => d.TeslimatAdres).WithMany(p => p.SipariTeslimatAdres)
                .HasForeignKey(d => d.TeslimatAdresId)
                .HasConstraintName("FK_Siparis_KullaniciAdres1");

            entity.HasOne(d => d.TeslimatTipiNavigation).WithMany(p => p.Siparis)
                .HasForeignKey(d => d.TeslimatTipi)
                .HasConstraintName("FK_Siparis_TeslimatTipi");
        });

        modelBuilder.Entity<SiparisDetay>(entity =>
        {
            entity.ToTable("SiparisDetay");

            entity.Property(e => e.BirimFiyati).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SatirToplami).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetays)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK_SiparisDetay_Siparis");
        });

        modelBuilder.Entity<SiparisDurum>(entity =>
        {
            entity.ToTable("SiparisDurum");

            entity.Property(e => e.SiparisDurumAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<SiparisKargo>(entity =>
        {
            entity.ToTable("SiparisKargo");

            entity.Property(e => e.Durumu).HasMaxLength(100);
            entity.Property(e => e.GonderimTarihi).HasColumnType("datetime");
            entity.Property(e => e.TeslimatTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Kargo).WithMany(p => p.SiparisKargos)
                .HasForeignKey(d => d.KargoId)
                .HasConstraintName("FK_SiparisKargo_Kargo");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisKargos)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK_SiparisKargo_Siparis");
        });

        modelBuilder.Entity<TaksitSecenek>(entity =>
        {
            entity.ToTable("TaksitSecenek");

            entity.Property(e => e.TaksitCizelge).HasMaxLength(200);

            entity.HasOne(d => d.Banka).WithMany(p => p.TaksitSeceneks)
                .HasForeignKey(d => d.BankaId)
                .HasConstraintName("FK_TaksitSecenek_Banka");
        });

        modelBuilder.Entity<TeslimatTipi>(entity =>
        {
            entity.ToTable("TeslimatTipi");

            entity.Property(e => e.TeslimatTipiAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.ToTable("Urun");

            entity.Property(e => e.Aciklama).HasMaxLength(2000);
            entity.Property(e => e.Description).HasMaxLength(110);
            entity.Property(e => e.Keywords).HasMaxLength(70);
            entity.Property(e => e.Title).HasMaxLength(70);
            entity.Property(e => e.UrunAdi).HasMaxLength(100);
            entity.Property(e => e.UrunKodu).HasMaxLength(50);

            entity.HasOne(d => d.Birim).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.BirimId)
                .HasConstraintName("FK_Urun_Birim");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK_Urun_Kategori");

            entity.HasOne(d => d.Kdv).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.KdvId)
                .HasConstraintName("FK_Urun_Kdv");

            entity.HasOne(d => d.Marka).WithMany(p => p.Uruns)
                .HasForeignKey(d => d.MarkaId)
                .HasConstraintName("FK_Urun_Marka");
        });

        modelBuilder.Entity<UrunFiyat>(entity =>
        {
            entity.ToTable("UrunFiyat");

            entity.Property(e => e.Aciklama).HasMaxLength(50);
            entity.Property(e => e.UrunFiyati).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.FiyatTipi).WithMany(p => p.UrunFiyats)
                .HasForeignKey(d => d.FiyatTipiId)
                .HasConstraintName("FK_UrunFiyat_FiyatTipi");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunFiyats)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_UrunFiyat_Urun");
        });

        modelBuilder.Entity<UrunIndirim>(entity =>
        {
            entity.ToTable("UrunIndirim");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunIndirims)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_UrunIndirim_Urun");
        });

        modelBuilder.Entity<UrunOzellikDeger>(entity =>
        {
            entity.ToTable("UrunOzellikDeger");

            entity.HasOne(d => d.Ozellik).WithMany(p => p.UrunOzellikDegers)
                .HasForeignKey(d => d.OzellikId)
                .HasConstraintName("FK_UrunOzellikDeger_Ozellik");

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunOzellikDegers)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_UrunOzellikDeger_Urun");
        });

        modelBuilder.Entity<UrunResim>(entity =>
        {
            entity.ToTable("UrunResim");

            entity.Property(e => e.ResimUrl).HasMaxLength(200);

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunResims)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_UrunResim_Urun");
        });

        modelBuilder.Entity<UrunYorum>(entity =>
        {
            entity.ToTable("UrunYorum");

            entity.Property(e => e.OnayTarihi).HasColumnType("datetime");
            entity.Property(e => e.Tarih).HasColumnType("datetime");
            entity.Property(e => e.Yorum).HasMaxLength(200);

            entity.HasOne(d => d.Urun).WithMany(p => p.UrunYorums)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK_UrunYorum_Urun");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
