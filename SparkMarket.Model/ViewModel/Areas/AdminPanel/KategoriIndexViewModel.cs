using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KategoriIndexViewModel
    {
        public string? KategoriAdi { get; set; }

        public string? Aciklama { get; set; }

        public string? Resim { get; set; }

        public IFormFile FUResim { get; set; }
        public int? UstKategoriId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Keywords { get; set; }

        public string UstKategoriGorunum { get; set; }

        public Kategori kategori { get; set; }
        public List<SelectListItem> UstKategoriListe { get; set; }


    }
}
