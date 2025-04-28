using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Front;
using SparkMarket.MVCCoreUI.Filters;
using SparkMarket.MVCCoreUI.Models;

namespace SparkMarket.MVCCoreUI.Controllers
{
    public class HomeController : Controller
    {
        IUrunBS _urunBS;
        IKategoriBS _kategoriBS;
        IBirimBs _birimBs;
        IMarkaBS _markaBS;
        IKdvBS _kdvBS;
        IUrunFiyatBS _urunFiyatBS;
        IUrunIndirimBS _urunIndirimBS;
        IUrunOzellikDegerBS _urunOzellikDegerBS;
        IFiyatTipiBS _fiyatTipiBS;
        IMapper _mapper;
        ISessionManager _session;
        IUrunResimBS _urunResimBS;
        public HomeController(IUrunBS urunBS,
        IKategoriBS kategoriBS,
        IBirimBs birimBs,
        IMarkaBS markaBS,
        IKdvBS kdvBS,
        IUrunFiyatBS urunFiyatBS,
        IUrunIndirimBS urunIndirimBS,
        IFiyatTipiBS fiyatTipiBS,
        IUrunOzellikDegerBS urunOzellikDegerBS,
        IMapper mapper,
        ISessionManager session,
        IUrunResimBS urunResimBS)
        {

            _urunBS = urunBS;
            _kategoriBS = kategoriBS;
            _markaBS = markaBS;
            _kdvBS = kdvBS;
            _birimBs = birimBs;
            _urunIndirimBS = urunIndirimBS;
            _urunOzellikDegerBS = urunOzellikDegerBS;
            _urunFiyatBS = urunFiyatBS;
            _fiyatTipiBS = fiyatTipiBS;
            _mapper = mapper;
            _session = session;
            _urunResimBS = urunResimBS;
        }

        public IActionResult Index()
        
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.UrunListesi = _urunBS.GetAll(x => x.Aktif == true, includelist: ["UrunFiyats","UrunResims"]);



            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
