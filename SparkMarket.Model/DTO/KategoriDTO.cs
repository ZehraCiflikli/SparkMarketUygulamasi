using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.DTO
{
    public class KategoriDTO
    {

        public int Id { get; set; }
        public string? KategoriAdi { get; set; }

        public string? Aciklama { get; set; }

        public string? Resim { get; set; }

        public int? UstKategoriId { get; set; }

        public string UstKategoriGorunum { get; set; }

    }
}
