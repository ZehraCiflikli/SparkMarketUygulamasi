using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class OdemeTuruIndexViewModel
    {
        public string? OdemeTuruAdi { get; set; }

       public List<OdemeTuru> OdemeTuruListe { get; set; }
    }
}
