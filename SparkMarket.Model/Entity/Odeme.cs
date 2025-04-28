using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Odeme : BaseEntity
{
    

    public int? SiparisId { get; set; }

    public int? OdemeTuruId { get; set; }

    public DateTime? Tarih { get; set; }

    

    public bool? Onay { get; set; }

    public decimal? OdemeTutari { get; set; }

    public int? BankaId { get; set; }

    public virtual Banka? Banka { get; set; }

    public virtual OdemeTuru? OdemeTuru { get; set; }

    public virtual Sipari? Siparis { get; set; }
}
