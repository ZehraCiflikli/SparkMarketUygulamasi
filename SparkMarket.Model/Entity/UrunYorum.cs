using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class UrunYorum : BaseEntity
{
   

    public int? KullaniciId { get; set; }

    public string? Yorum { get; set; }

    public int? Puan { get; set; }

    public int? UrunId { get; set; }

    

    public DateTime? Tarih { get; set; }

    public bool? Onay { get; set; }

    public DateTime? OnayTarihi { get; set; }

    public int? Onaylayan { get; set; }

    public virtual Urun? Urun { get; set; }
}
