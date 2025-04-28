using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Kategori : BaseEntity
{
    

    public string? KategoriAdi { get; set; }

    public string? Aciklama { get; set; }

    public string? Resim { get; set; }

    

    public int? UstKategoriId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public string UstKategoriGorunum { get; set; }


    public virtual ICollection<Kategori> InverseUstKategori { get; set; } = new List<Kategori>();

    public virtual ICollection<KategoriOzellik> KategoriOzelliks { get; set; } = new List<KategoriOzellik>();

    public virtual ICollection<Urun> Uruns { get; set; } = new List<Urun>();

    public virtual Kategori? UstKategori { get; set; }
}
