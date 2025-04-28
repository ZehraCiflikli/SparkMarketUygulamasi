using AutoMapper;
using SparkMarket.Model.DTO;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;
using SparkMarket.Model.ViewModel.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.MappingRules
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KullniciSignupVm, Kullanici>().ReverseMap();

            CreateMap<UrunAddViewModel, Urun>().ReverseMap();
            CreateMap<Kullanici, KullaniciVm>().ForMember(x => x.Roller, o => o.MapFrom(x => x.KullaniciRols.Select(x => x.Rol.RolAdi))).ReverseMap();

            CreateMap<KullaniciAdre, KullaniciAdresVm>().ForMember(x => x.Sehir, o => o.MapFrom(x => x.Il.IlAdi)).ForMember(x => x.Semt, o => o.MapFrom(x => x.Ilce.IlceAdi)).ReverseMap();
            CreateMap<UpdateKullaniciVm, Kullanici>().ReverseMap();
            CreateMap<Kullanici, KullaniciDigerBilgilerVm>().ForMember(x => x.VergiNo, o => o.MapFrom(x => x.KullaniciKurumsals.FirstOrDefault().VergiNo)).ForMember(x => x.VergiDairesi, o => o.MapFrom(x => x.KullaniciKurumsals.FirstOrDefault().VergiDairesi)).ForMember(x => x.KullaniciId, o => o.MapFrom(x => x.Id)).ForMember(x => x.KullaniciTipi, o => o.MapFrom(x => x.KullaniciTipiNavigation.KullaniciTipiAdi)).ReverseMap();

            CreateMap<KategoriDTO, Kategori>().ReverseMap();

        }
    }
}
