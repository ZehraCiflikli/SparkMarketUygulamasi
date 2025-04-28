using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciDigerBilgilerVm
    {        
        public int? KullaniciTipiId { get; set; }
        public int KullaniciId { get; set; }
        public KullaniciAdresVm KullaniciAdresi { get; set; }
        public string KullaniciTipi { get; set; }        
        public int? VergiNo { get; set; }
        public string? VergiDairesi { get; set; }
        public string TckimlikNo { get; set; }
        public string CepTelefonu { get; set; }
        public List<SelectListItem> Sehirler { get; set; }
        public List<SelectListItem> Semtler{ get; set; }
        public List<SelectListItem> KullaniciTipleri { get; set; }
    }
}
