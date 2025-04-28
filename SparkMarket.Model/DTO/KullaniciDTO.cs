using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Model.DTO
{
    public class KullaniciDTO
    {
        public string Adi { get; set; } = null!;

        public string Soyadi { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? TckimlikNo { get; set; }

        public DateTime? DogumTarihi { get; set; }

    }
}
