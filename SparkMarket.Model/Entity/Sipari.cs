using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Sipari : BaseEntity
{
    

    public int? KullaniciId { get; set; }

    public DateTime? SiparisTarihi { get; set; }

    public string? Ip { get; set; }

    public string? SiparisKodu { get; set; }

    

    public int? TeslimatAdresId { get; set; }

    public int? FaturaAdresId { get; set; }

    public int? SiparisDurumId { get; set; }

    public int? IndirimId { get; set; }

    public int? TeslimatTipi { get; set; }

    public decimal? ToplamTutar { get; set; }

    public virtual KullaniciAdre? FaturaAdres { get; set; }

    public virtual ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();

    public virtual Indirim? Indirim { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<Odeme> Odemes { get; set; } = new List<Odeme>();

    public virtual ICollection<SiparisDetay> SiparisDetays { get; set; } = new List<SiparisDetay>();

    public virtual SiparisDurum? SiparisDurum { get; set; }

    public virtual ICollection<SiparisKargo> SiparisKargos { get; set; } = new List<SiparisKargo>();

    public virtual KullaniciAdre? TeslimatAdres { get; set; }

    public virtual TeslimatTipi? TeslimatTipiNavigation { get; set; }
}
