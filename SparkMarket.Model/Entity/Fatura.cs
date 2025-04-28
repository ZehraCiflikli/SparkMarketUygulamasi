using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Fatura:BaseEntity
{
 

    public string FaturaNo { get; set; } = null!;

    public int SiparisId { get; set; }

    public DateTime? FaturaTarihi { get; set; }

    public int? AdresId { get; set; }

    public string? KargoFisNo { get; set; }

    public decimal? ToplamTutari { get; set; }

    

    public virtual ICollection<FaturaDetay> FaturaDetays { get; set; } = new List<FaturaDetay>();

    public virtual Sipari Siparis { get; set; } = null!;
}
