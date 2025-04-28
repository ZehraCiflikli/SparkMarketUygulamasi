using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class IndirimTipi : BaseEntity
{
    

    public string? IndirimTipAdi { get; set; }

    

    public virtual ICollection<Indirim> Indirims { get; set; } = new List<Indirim>();
}
