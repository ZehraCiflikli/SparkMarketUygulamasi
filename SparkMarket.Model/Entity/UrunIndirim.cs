using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class UrunIndirim : BaseEntity
{
   

    public int? UrunId { get; set; }

    public int? IndirimId { get; set; }

    

    public virtual Urun? Urun { get; set; }
}
