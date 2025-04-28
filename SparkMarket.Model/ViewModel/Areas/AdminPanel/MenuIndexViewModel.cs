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
    public class MenuIndexViewModel
    {
        public string? Baslik { get; set; }

        public string? Aciklama { get; set; }

        public string? MenuIcon { get; set; }

        public string? Url { get; set; }
        public int? UstMenuId { get; set; }

        public int? Sira { get; set; }

        public string? UstMenuGorunum { get; set; }

        public Menu Menu { get; set; }

        public List<SelectListItem> UstMenuListe { get; set; }

        public IFormFile FUResim { get; set; }


        public List<Menu> Menuler { get; set; }


    }
}
