using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Indirim : BaseEntity
{
    

    public string? Baslik { get; set; }

    public string? Aciklama { get; set; }

    public int? IndirimTipiId { get; set; }

    public decimal? IndirimDegeri { get; set; }

    public string? KuponKodu { get; set; }

   

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public decimal? MinTutar { get; set; }

    public bool? KuponMu { get; set; }

    public virtual IndirimTipi? IndirimTipi { get; set; }

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
