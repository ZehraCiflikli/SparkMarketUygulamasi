using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class SiparisDetay : BaseEntity
{
    

    public int? SiparisId { get; set; }

    public int? UrunId { get; set; }

    public int? Miktar { get; set; }

    public decimal? BirimFiyati { get; set; }

   

    public int? İndirimId { get; set; }

    public decimal? SatirToplami { get; set; }

    public virtual Sipari? Siparis { get; set; }
}
