using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciIndexViewModel
    {
        public string Id { get; set; }
        public string Adi { get; set; } = null!;

        public string Soyadi { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Resim { get; set; }

        public string? CepTelefonu { get; set; }

        public string? TckimlikNo { get; set; }

        public DateTime? DogumTarihi { get; set; }
   
        public int? KullaniciTipi { get; set; }

        public int? Durum { get; set; }
        public string AdSoyad { get { return Adi + " " + Soyadi; } }

        public List<SelectListItem> KullaniciListe { get; set; }

        public List<Rol> Roller { get; set; }

        public virtual ICollection<KullaniciAdre> KullaniciAdres { get; set; } = new List<KullaniciAdre>();

        public virtual ICollection<KullaniciKurumsal> KullaniciKurumsals { get; set; } = new List<KullaniciKurumsal>();

        public virtual ICollection<KullaniciRol> KullaniciRols { get; set; } = new List<KullaniciRol>();

        public virtual KullaniciTipi? KullaniciTipiNavigation { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

        public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();


    }
}
