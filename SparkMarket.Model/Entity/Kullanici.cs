using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Kullanici : BaseEntity
{


    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Sifre { get; set; }

    public Guid UniqueId { get; set; }

    public string? Resim { get; set; }

    public string? Telefon { get; set; }

    public string? CepTelefonu { get; set; }

    public string? TckimlikNo { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public bool? EmailOnay { get; set; }

    public bool? CepTelefonuOnay { get; set; }

    public int? HataliGirisSayisi { get; set; }

    public string? Ip { get; set; }

    public int? KullaniciTipi { get; set; }

    public int? Durum { get; set; }

    public virtual ICollection<KullaniciAdre> KullaniciAdres { get; set; } = new List<KullaniciAdre>();

    public virtual ICollection<KullaniciKurumsal> KullaniciKurumsals { get; set; } = new List<KullaniciKurumsal>();

    public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

    public virtual KullaniciTipi? KullaniciTipiNavigation { get; set; }

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
