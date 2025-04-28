using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class KullaniciTipi : BaseEntity
{
    

    public string? KullaniciTipiAdi { get; set; }

    

    public virtual ICollection<Kullanici> Kullanicis { get; set; } = new List<Kullanici>();
}
