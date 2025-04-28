using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class TeslimatTipi : BaseEntity
{
    

    public string? TeslimatTipiAdi { get; set; }

    

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();
}
