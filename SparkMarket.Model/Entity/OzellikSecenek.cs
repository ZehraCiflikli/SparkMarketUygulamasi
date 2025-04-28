using Infrastructure.Entity;
using System;
using System.Collections.Generic;

namespace SparkMarket.Model.Entity;

public partial class OzellikSecenek:BaseEntity
{
   

    public int? OzellikId { get; set; }

    public string? Secenek { get; set; }

    

    public virtual Ozellik? Ozellik { get; set; }
}
