using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Banka:BaseEntity
{
   

    public string? BankaAdi { get; set; }

   

    public virtual ICollection<Odeme> Odemes { get; set; } = new List<Odeme>();

    public virtual ICollection<TaksitSecenek> TaksitSeceneks { get; set; } = new List<TaksitSecenek>();
}
