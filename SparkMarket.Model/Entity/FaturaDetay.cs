using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class FaturaDetay : BaseEntity
{
   

    public int? FaturaId { get; set; }

    public int? UrunId { get; set; }

    public int? Miktar { get; set; }

    public int? BirimFiyati { get; set; }

    public int? SatirToplami { get; set; }

    
    public virtual Fatura? Fatura { get; set; }

    public virtual Urun? Urun { get; set; }
}
