using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class LoginVm
    {
        //public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string Email { get; set; }

        public bool BeniHatirla { get; set; }


        public string GuvenlikKodu { get; set; }
    }
}
