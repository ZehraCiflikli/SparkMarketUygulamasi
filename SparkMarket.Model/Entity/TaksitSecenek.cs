using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class TaksitSecenek : BaseEntity
{
   

    public int? BankaId { get; set; }

    public int? TaksitSayisi { get; set; }

    public string? TaksitCizelge { get; set; }

    

    public virtual Banka? Banka { get; set; }
}
