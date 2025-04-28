using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class UrunResim : BaseEntity
{
    

    public int? UrunId { get; set; }

    public string? ResimUrl { get; set; }

    

    public virtual Urun? Urun { get; set; }
}
