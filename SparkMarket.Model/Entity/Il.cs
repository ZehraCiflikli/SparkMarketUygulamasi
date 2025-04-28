using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Il : BaseEntity
{
   

    public string? IlAdi { get; set; }

    

    public int? IlKodu { get; set; }

    public virtual ICollection<Ilce> Ilces { get; set; } = new List<Ilce>();

    public virtual ICollection<KullaniciAdre> KullaniciAdres { get; set; } = new List<KullaniciAdre>();
}
