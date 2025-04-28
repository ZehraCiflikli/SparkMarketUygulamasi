using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Birim:BaseEntity
{
    

    public string BirimAdi { get; set; }

    

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();
}
