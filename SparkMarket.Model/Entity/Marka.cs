using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Marka : BaseEntity
{
   

    public string? MarkaAdi { get; set; }

    

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();
}
