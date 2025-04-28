using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Ilce : BaseEntity
{
    

    public string? IlceAdi { get; set; }

    public int? IlId { get; set; }


    public int? IlceKodu { get; set; }

    public virtual Il? Il { get; set; }

    public virtual ICollection<KullaniciAdre> KullaniciAdres { get; set; } = new List<KullaniciAdre>();
}
