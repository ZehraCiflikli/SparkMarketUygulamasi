using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class KullaniciKurumsal : BaseEntity
{
   

    public int? KullaniciId { get; set; }

    public int? VergiNo { get; set; }

    public string? VergiDairesi { get; set; }

    

    public virtual Kullanici? Kullanici { get; set; }
}
