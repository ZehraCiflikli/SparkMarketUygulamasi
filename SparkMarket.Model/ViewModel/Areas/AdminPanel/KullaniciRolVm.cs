using Microsoft.AspNetCore.Mvc.Rendering;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.ViewModel.Areas.AdminPanel
{
    public class KullaniciRolVm
    {
        public int KullaniciId { get; set; }
        public List<int> RolIds { get; set; }
        public List<SelectListItem> Roller { get; set; }

    }
}
