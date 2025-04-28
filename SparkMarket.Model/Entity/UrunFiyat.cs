using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class UrunFiyat : BaseEntity
{
   

    public int? UrunId { get; set; }

    public string? Aciklama { get; set; }

    public decimal? UrunFiyati { get; set; }

    public int? FiyatTipiId { get; set; }

    
    public virtual FiyatTipi? FiyatTipi { get; set; }

    public virtual Urun? Urun { get; set; }
}
