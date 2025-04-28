using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SparkMarket.Model.Entity;


public partial class Kargo : BaseEntity
{
    

    public int? KargoFirması { get; set; }

    

    public virtual ICollection<SiparisKargo> SiparisKargos { get; set; } = new List<SiparisKargo>();
}
