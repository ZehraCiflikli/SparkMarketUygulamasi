using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Rol : BaseEntity
{
    

    public string? RolAdi { get; set; }

    

    public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

    public virtual ICollection<MenuYetki> MenuYetkis { get; set; } = new List<MenuYetki>();
}
