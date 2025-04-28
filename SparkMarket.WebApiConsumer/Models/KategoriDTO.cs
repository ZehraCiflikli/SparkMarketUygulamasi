using Microsoft.AspNetCore.Mvc.Rendering;

namespace SparkMarket.WebApiConsumer.Models
{
    public class KategoriDTO
    {
        public int Id { get; set; }
        public string? KategoriAdi { get; set; }

        public string? Aciklama { get; set; }

        public string? Resim { get; set; }

        public int? UstKategoriId { get; set; }

        public string UstKategoriGorunum { get; set; }


        public List<KategoriDTO> Kategoriler { get; set; }
        public List<SelectListItem> KategoriList { get; set; }
    }
}
