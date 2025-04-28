using FluentValidation;
using SparkMarket.Business.Abstract;
using SparkMarket.Business.Concrete.Base;
using SparkMarket.Model.Entity;
using SparkMarket.Model.ViewModel.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.ValidationRules.Front
{
    public class KullaniciSignupValidator : AbstractValidator<KullniciSignupVm>
    {

        IKullaniciBS _kullaniciBS;
        public KullaniciSignupValidator(IKullaniciBS kullaniciBS)
        {
            _kullaniciBS = kullaniciBS;
            RuleFor(x => x.Adi).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");
            RuleFor(x => x.Soyadi).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez");
            RuleFor(x => x.Sifre).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Lütfen  en az 8 karekter giriniz. En az bir rakam kullanınız. ...");

            RuleFor(x => x.SifreTekrar).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Equal(x => x.Sifre).WithMessage("Şifreler Eşleşmiyor");

            RuleFor(x => x.SehirId).Must(SecildiMi).WithMessage("Lütfen Şehir Seçiniz..");

            RuleFor(x => x.Email).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Must(KullaniliyorMu).WithMessage("Bu Email Kullanılıyor").EmailAddress().WithMessage("Lütfen Geçerli Bir Email Giriniz.");
        }

        public bool SecildiMi(int arg)
        {
            if (arg == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool KullaniliyorMu(string arg)
        {

            Kullanici k = _kullaniciBS.Get(x => x.Email == arg);
            if (k != null)
            {
                // Bu email kullanılıyor
                return false;

            }
            else
            {
                // email yok kayıt olabilirsin
                return true;
            }


        }
    }
}
