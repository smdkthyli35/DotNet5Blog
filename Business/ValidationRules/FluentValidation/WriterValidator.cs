using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar ad-soyad kısmı boş geçilemez!");
            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("E-posta adresi boş geçilemez!");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapın!");
            RuleFor(w => w.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla elli (50) karakterlik veri girişi yapın!");
        }
    }
}
