using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SparkMarket.Business.Abstract;
using SparkMarket.Model.ViewModel.Front;
using SparkMarket.MVCCoreUI.Filters;

namespace SparkMarket.MVCCoreUI.ViewComponents
{
	public class categoryViewComponent : ViewComponent
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
        public categoryViewComponent(IUrunBS urunBS,
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


        public IViewComponentResult Invoke()
		{


            CategoriViewComponentViewModel model = new CategoriViewComponentViewModel();
            model.AnaKategoriler = _kategoriBS.GetAll(x => x.Aktif == true && x.UstKategoriId==null);

            model.AltKategoriler = _kategoriBS.GetAll(x => x.Aktif == true && x.UstKategoriId != null);

            return View(model);

		}
	}
}
