using Microsoft.Extensions.DependencyInjection;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Data.Abstract;
using SparkMarket.Data.Concrete.Dapper;
using SparkMarket.Data.Concrete.EntityFramework.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            #region Business

            services.AddScoped<IBankaBS, BankaBS>();
            services.AddScoped<IBirimBs, BirimBS>();
            services.AddScoped<IFaturaBS, FaturaBS>();
            services.AddScoped<IFaturaDetayBS, FaturaDetayBS>();
            services.AddScoped<IFiyatTipiBS, FiyatTipiBS>();
            services.AddScoped<IIlBS, IlBs>();
            services.AddScoped<IIlceBS, IlceBS>();
            services.AddScoped<IIndirimBS, IndirimBS>();
            services.AddScoped<IKargoBS, KargoBS>();
            services.AddScoped<IKategoriBS, KategoriBS>();
            services.AddScoped<IKategoriOzellikBS, KategoriOzellikBS>();
            services.AddScoped<IKdvBS, KdvBS>();
            services.AddScoped<IKullaniciAdreBS, KullanicAdreBS>();
            services.AddScoped<IKullaniciBS, KullaniciBS>();
            services.AddScoped<IKullaniciKurumsalBS, KullaniciKurumsalBS>();
            services.AddScoped<IKullaniciRolBS, KullaniciRolBS>();
            services.AddScoped<IKullaniciTipiBS, KullaniciTipiBS>();
            services.AddScoped<IMarkaBS, MarkaBS>();
            services.AddScoped<IMenuBS, MenuBS>();
            services.AddScoped<IMenuYetkiBS, MenuYetkiBS>();
            services.AddScoped<IOdemeBS, OdemeBS>();
            services.AddScoped<IOdemeTuruBS, OdemeTuruBS>();
            services.AddScoped<IOzellikSecenekBS, OzellikSecenekBS>();
            services.AddScoped<IOzellikBS, OzellikBS>();
            services.AddScoped<IRolBS, RolBS>();
            services.AddScoped<ISepetBS, SepetBS>();
            services.AddScoped<ISipariBS, SipariBS>();
            services.AddScoped<ISiparisDetayBS, SiparisDetayBS>();
            services.AddScoped<ISiparisDurumBS, SiparisDurumBS>();
            services.AddScoped<ISiparisKargoBS, SiparisKargoBS>();
            services.AddScoped<ITaksitSecenekBS, TaksitSecenekBS>();
            services.AddScoped<ITeslimatTipiBS, TeslimatTipiBS>();
            services.AddScoped<IUrunBS, UrunBS>();
            services.AddScoped<IUrunIndirimBS, UrunIndirimBS>();
            services.AddScoped<IUrunOzellikDegerBS, UrunOzellikDegerBS>();
            services.AddScoped<IUrunFiyatBS, UrunFiyatBS>();
            services.AddScoped<IUrunResimBS, UrunResimBS>();
            services.AddScoped<IUrunYorumBS, UrunYorumBS>();

            services.AddScoped<IRaporBs, RaporBs>();

            #endregion


            #region Data

            services.AddScoped<IBankaRepository, EfBankaRepository>();
            services.AddScoped<IBankaRepositoryUOW, EfBankaRepositoryUOW>();
            services.AddScoped<IBirimRepository, EfBirimRepository>();
            services.AddScoped<IFaturaRepository, EfFaturaRepository>();
            services.AddScoped<IFaturaDetayRepository, EfFaturaDetayRepository>();
            services.AddScoped<IFiyatTipiRepository, EfFiyatTipiRepository>();
            services.AddScoped<IIlRepository, EfIlRepository>();
            services.AddScoped<IIlceRepository, EfIlceRepository>();
            services.AddScoped<IIndirimRepository, EfIndirimRepository>();
            services.AddScoped<IIndirimTipiRepository, EfIndirimTipiRepository>();
            services.AddScoped<IKargoRepository, EfKargoRepository>();
            services.AddScoped<IKategoriRepository, EfKategoriRepository>();
            services.AddScoped<IKategoriOzellikRepository, EfKategoriOzellikRepository>();
            services.AddScoped<IKdvRepository, EfKdvRepository>();
            services.AddScoped<IKullaniciAdreRepository, EfKullaniciAdreRepository>();
            services.AddScoped<IKullaniciRepository, EfKullaniciRepository>();
            services.AddScoped<IKullaniciKurumsalRepository, EfKullaniciKurumsalRepository>();
            services.AddScoped<IKullaniciRolRepository, EfKullaniciRolRepository>();
            services.AddScoped<IKullaniciTipiRepository, EfKullaniciTipiRepository>();
            services.AddScoped<IMarkaRepository, EfMarkaRepository>();
            services.AddScoped<IMenuRepository, EfMenuRepository>();
            services.AddScoped<IMenuYetkiRepository, EfMenuYetkiRepository>();
            services.AddScoped<IOdemeTuruRepository, EfOdemeTuruRepository>();
            services.AddScoped<IOdemeRepository, EfOdemeRepository>();
            services.AddScoped<IOzellikRepository, EfOzellikRepository>();
            services.AddScoped<IOzellikSecenekRepository, EfOzellikSecenekRepository>();
            services.AddScoped<IRolRepository, EfRolRepository>();
            services.AddScoped<ISepetRepository, EfSepetRepository>();
            services.AddScoped<ISipariRepository, EfSipariRepository>();
            services.AddScoped<ISiparisDetayRepository, EfSiparisDetayRepository>();
            services.AddScoped<ISiparisDurumRepository, EfSiparisDurumRepository>();
            services.AddScoped<ISiparisKargoRepository, EfSiparisKargoRepository>();
            services.AddScoped<ITaksitSecenekRepository, EfTaksitSecenekRepository>();
            services.AddScoped<ITeslimatTipiRepository, EfTeslimatTipiRepository>();
            services.AddScoped<IUrunRepository, EfUrunRepository>();
            services.AddScoped<IUrunFiyatRepository, EfUrunFiyatRepository>();
            services.AddScoped<IUrunIndirimRepository, EfUrunIndirimRepository>();
            services.AddScoped<IUrunOzellikDegerRepository, EfUrunOzellikDegerRepository>();
            services.AddScoped<IUrunResimRepository, EfUrunResimRepository>();
            services.AddScoped<IUrunYorumRepository, EfUrunYorumRepository>();
            services.AddScoped<IRaporRepository, EfRaporRepository>();


            #endregion



            return services;

        }


    }
}
