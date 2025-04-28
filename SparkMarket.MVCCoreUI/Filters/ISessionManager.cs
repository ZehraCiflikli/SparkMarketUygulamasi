using SparkMarket.Model.Entity;
using SparkMarket.MVCCoreUI.Areas.AdminPanel.Controllers;

namespace SparkMarket.MVCCoreUI.Filters
{
    public interface ISessionManager
    {

        public Kullanici AktifKullanici { get; set; }
        public Kullanici AktifYonetici { get; set; }
        public string GuvenlikKodu { get; set; }

        public List<Dosya> Dosyalar { get; set; }
        public bool YetkisiVarmi(int MenuId, int KullaniciId);

    }
}
