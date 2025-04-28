using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class UrunAddViewModel
    {
        public int Id { get; set; }
        public string? UrunAdi { get; set; }

        public string? Aciklama { get; set; }

        public int? KategoriId { get; set; }

        public int? MarkaId { get; set; }

        public string? UrunKodu { get; set; }

        public int? BirimId { get; set; }

        public int? KdvId { get; set; }

        public int? Stok { get; set; }

        public List<SelectListItem> KategoriListe { get; set; }
        public List<SelectListItem> BirimListe { get; set; }
        public List<SelectListItem> KdvListe { get; set; }
        public List<SelectListItem> MarkaListe { get; set; }
        public List<FiyatTipi> FiyatTipleri { get; set; }

    }
}
