using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class MenuYetki : BaseEntity
{
    

    public int? MenuId { get; set; }

    public int? RolId { get; set; }

    public bool? InsertYetki { get; set; }

    public bool? UpdateYetki { get; set; }

    public bool? DeleteYetki { get; set; }

    public bool? SelectYetki { get; set; }

    

    public virtual Menu? Menu { get; set; }

    public virtual Rol? Rol { get; set; }
}
