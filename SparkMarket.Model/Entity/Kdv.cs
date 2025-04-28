using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Kdv : BaseEntity
{
    

    public double? KdvOrani { get; set; }

    public string? KdvAdi { get; set; }

    

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();
}
