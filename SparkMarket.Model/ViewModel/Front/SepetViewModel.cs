using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Front
{
    public class SepetViewModel
    {

        public List<Sepet> SepetUrunleri { get; set; }

        public decimal ToplamTutar { get; set; }
    }
}
