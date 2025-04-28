using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.Entity
{
    public class Rapor:BaseEntity
    {
        public int Durum { get; set; }    
        public DateTime? TalepTarih { get; set; }
        public DateTime? RaporTarih { get; set; }
        public string RaporUrl { get; set; }
        public int RaporTipId { get; set; }
    }
}
