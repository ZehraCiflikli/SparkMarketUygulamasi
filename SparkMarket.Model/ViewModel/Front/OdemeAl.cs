using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Front
{
    public class OdemeModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string KartSahibi { get; set; }
        public string KartNumarasi { get; set; }
        public string SonKullanmaAy { get; set; }
        public string SonKullanmaYil { get; set; }
        public string Cvc { get; set; }
        public decimal Tutar { get; set; }
    }
}
