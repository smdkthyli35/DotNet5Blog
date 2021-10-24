using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez!");
            RuleFor(b => b.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez!");
            RuleFor(b => b.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez!");

            RuleFor(b => b.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden az veri girişi yapın!"); 
            RuleFor(b => b.BlogTitle).MinimumLength(5).WithMessage("Lütfen 4 karakterden fazla veri girişi yapın!");

            RuleFor(b => b.BlogContent).MaximumLength(500).WithMessage("Lütfen 150 karakterden az veri girişi yapın!");
            RuleFor(b => b.BlogContent).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapın!");
        }
    }
}
