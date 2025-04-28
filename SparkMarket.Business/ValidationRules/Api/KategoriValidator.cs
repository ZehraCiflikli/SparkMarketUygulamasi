using FluentValidation;
using SparkMarket.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.ValidationRules.Api
{

    public class KategoriValidator:AbstractValidator<KategoriDTO>
    {
        public KategoriValidator()
        {
            RuleFor(x => x.Aciklama).MinimumLength(5).WithMessage("Lütfen En az 5 karakter açıklama giriniz");
        }

    }

 
}
