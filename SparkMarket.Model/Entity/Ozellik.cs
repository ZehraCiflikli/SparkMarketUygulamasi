using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Ozellik : BaseEntity
{
    

    public string? OzellikAdi { get; set; }

    public int? OzellikTipi { get; set; }

    

    public virtual ICollection<KategoriOzellik> KategoriOzelliks { get; set; } = new List<KategoriOzellik>();

    public virtual ICollection<OzellikSecenek> OzellikSeceneks { get; set; } = new List<OzellikSecenek>();

    public virtual ICollection<UrunOzellikDeger> UrunOzellikDegers { get; set; } = new List<UrunOzellikDeger>();
}
