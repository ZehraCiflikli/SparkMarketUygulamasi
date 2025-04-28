using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class KullaniciAdre : BaseEntity
{
   

    public int? IlId { get; set; }

    public int? IlceId { get; set; }

    public string? Adres { get; set; }

    public int? KullaniciId { get; set; }

    

    public virtual Il? Il { get; set; }

    public virtual Ilce? Ilce { get; set; }

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<Sipari> SipariFaturaAdres { get; set; } = new List<Sipari>();

    public virtual ICollection<Sipari> SipariTeslimatAdres { get; set; } = new List<Sipari>();
}
