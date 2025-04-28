using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class UrunOzellikDeger : BaseEntity
{
    

    public int? UrunId { get; set; }

    public int? OzellikId { get; set; }

    public int? SecenekId { get; set; }

    

    public virtual Ozellik? Ozellik { get; set; }

    public virtual Urun? Urun { get; set; }
}
