using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class KullaniciRol : BaseEntity
{
    

    public int? KullaniciId { get; set; }

    public int? RolId { get; set; }

    

    public virtual Kullanici? Kullanici { get; set; }

    public virtual Rol? Rol { get; set; }
}
