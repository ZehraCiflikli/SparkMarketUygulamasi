using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class OdemeTuru : BaseEntity
{
    

    public string? OdemeTuruAdi { get; set; }

   

    public virtual ICollection<Odeme> Odemes { get; set; } = new List<Odeme>();
}
