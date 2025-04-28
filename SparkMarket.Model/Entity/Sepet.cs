using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Sepet : BaseEntity
{
    

    public int? KullaniciId { get; set; }

    public int? UrunId { get; set; }

    public int? Adet { get; set; }

    




    public virtual Kullanici? Kullanici { get; set; }

    public virtual Urun? Urun { get; set; }
}
