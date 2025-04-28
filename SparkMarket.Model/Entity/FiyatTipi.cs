using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class FiyatTipi : BaseEntity
{
   

    public string? FiyatTipiAdi { get; set; }

    

    public virtual ICollection<UrunFiyat> UrunFiyats { get; set; } = new List<UrunFiyat>();
}
