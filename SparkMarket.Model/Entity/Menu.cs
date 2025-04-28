using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class Menu : BaseEntity
{


    public string? Baslik { get; set; }

    public string? Aciklama { get; set; }

    public string? MenuIcon { get; set; }

    public string? Url { get; set; }
    public int? UstMenuId { get; set; }

    public int? Sira { get; set; }

    public virtual ICollection<Menu> InverseUstMenu { get; set; } = new List<Menu>();

    public virtual ICollection<MenuYetki> MenuYetkis { get; set; } = new List<MenuYetki>();

    public virtual Menu? UstMenu { get; set; }

    public string UstMenuGorunum { get; set; }


}
