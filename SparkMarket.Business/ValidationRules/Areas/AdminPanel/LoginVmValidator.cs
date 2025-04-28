using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SparkMarket.Model.ViewModel.Areas.AdminPanel;


namespace SparkMarket.Business.ValidationRules.Areas.AdminPanel
{
    public class LoginVmValidator : AbstractValidator<LoginVm>
    {
        public LoginVmValidator()
        {

            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen e-postanızı giriniz.").NotEmpty().WithMessage("Lütfen e-postanızı giriniz.").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            RuleFor(x => x.Sifre).NotNull().WithMessage("Lütfen e-postanızı giriniz.").NotEmpty().WithMessage("Lütfen şifrenizi giriniz.").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            RuleFor(x => x.GuvenlikKodu).NotNull().WithMessage("Lütfen e-postanızı giriniz.").NotEmpty().WithMessage("Lütfen şifrenizi giriniz.");


        }

    }
}
