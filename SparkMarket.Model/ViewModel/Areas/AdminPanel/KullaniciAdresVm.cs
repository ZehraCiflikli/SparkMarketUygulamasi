using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciAdresVm
    {
        public int? SehirId { get; set; }
        public int? SemtId { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Adres { get; set; }
    }
}
