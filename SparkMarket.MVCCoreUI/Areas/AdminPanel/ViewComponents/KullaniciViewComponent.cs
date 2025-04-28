using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;

namespace SparkMarket.MVCCoreUI.Areas.AdminPanel.ViewComponents
{
    public class KullaniciViewComponent:ViewComponent
    {
        private readonly IKullaniciBS kullaniciBS;
        private readonly IMapper mapper;
        
        public KullaniciViewComponent(IKullaniciBS kullaniciBS, IMapper mapper)
        {
            this.kullaniciBS = kullaniciBS;  
            this.mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            List<Kullanici> kullanicilar = kullaniciBS.GetAll(includelist: ["KullaniciRols", "KullaniciRols.Rol"]);
            List<KullaniciVm> model=mapper.Map<List<KullaniciVm>>(kullanicilar);
            
            return View(model);
        }
    }
}
