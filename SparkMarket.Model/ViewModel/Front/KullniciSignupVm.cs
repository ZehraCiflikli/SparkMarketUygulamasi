using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Front
{
    public class KullniciSignupVm
    {
        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Email { get; set; }

        public string Sifre { get; set; }

        public string SifreTekrar { get; set; }


        // Eğitim Amaçlı
        public int SehirId { get; set; }

        public List<SelectListItem> Sehirler { get; set; }


    }
}
