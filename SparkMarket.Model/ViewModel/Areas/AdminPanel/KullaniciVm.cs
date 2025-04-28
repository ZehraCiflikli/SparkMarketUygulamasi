using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciVm
    {
        public int Id { get; set; }
        public string Adi { get; set; } 
        public string Soyadi { get; set; } 
        public string Email { get; set; } 
        public bool Aktif { get; set; }
        public string TckimlikNo { get; set; }
        public string CepTelefonu { get; set; }
        public string Sifre { get; set; }
        public int KullaniciTipi { get; set; }
        public List<SelectListItem> KullaniciTipleri { get; set; }
        public List<string> Roller { get; set; }
    }
}
