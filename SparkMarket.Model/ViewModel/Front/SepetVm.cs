using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Front
{
    public class SepetVm
    {
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }
        public int Adet { get; set; }

        public string Resim { get; set; }

        public decimal BirimFiyat { get; set; }

        public string UrunKodu { get; set; }
        public decimal ToplamTutar { get; set; }

    }
}
