using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class SiparisKargo : BaseEntity
{
   

    public int? SiparisId { get; set; }

    public int? KargoId { get; set; }

    public DateTime? TeslimatTarihi { get; set; }

    public DateTime? GonderimTarihi { get; set; }

    public string? Durumu { get; set; }

    

    public virtual Kargo? Kargo { get; set; }

    public virtual Sipari? Siparis { get; set; }
}
