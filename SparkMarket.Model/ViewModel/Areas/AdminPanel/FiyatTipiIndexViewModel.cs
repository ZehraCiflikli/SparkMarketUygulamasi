using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class FiyatTipiIndexViewModel
    {
        public string? FiyatTipiAdi { get; set; }

      public  List<FiyatTipi> FiyatTipiListe { get; set; }
    }
}
