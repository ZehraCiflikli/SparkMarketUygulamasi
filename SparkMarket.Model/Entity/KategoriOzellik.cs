using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class KategoriOzellik : BaseEntity
{
    

    public int? KategoriId { get; set; }

    public int? OzellikId { get; set; }

    

    public virtual Kategori? Kategori { get; set; }

    public virtual Ozellik? Ozellik { get; set; }
}
