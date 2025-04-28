using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Urun : BaseEntity
{
   

    public string? UrunAdi { get; set; }

    public string? Aciklama { get; set; }

    public int? KategoriId { get; set; }

    public int? MarkaId { get; set; }

    public string? UrunKodu { get; set; }

    public int? BirimId { get; set; }

    public int? KdvId { get; set; }

    public int? Stok { get; set; }

    

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public virtual Birim? Birim { get; set; }

    public virtual ICollection<FaturaDetay> FaturaDetays { get; set; } = new List<FaturaDetay>();

    public virtual Kategori? Kategori { get; set; }

    public virtual Kdv? Kdv { get; set; }

    public virtual Marka? Marka { get; set; }

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<UrunFiyat> UrunFiyats { get; set; } = new List<UrunFiyat>();

    public virtual ICollection<UrunIndirim> UrunIndirims { get; set; } = new List<UrunIndirim>();

    public virtual ICollection<UrunOzellikDeger> UrunOzellikDegers { get; set; } = new List<UrunOzellikDeger>();

    public virtual ICollection<UrunResim> UrunResims { get; set; } = new List<UrunResim>();

    public virtual ICollection<UrunYorum> UrunYorums { get; set; } = new List<UrunYorum>();
}
