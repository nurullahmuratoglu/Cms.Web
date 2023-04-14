using Cms.Web.Models;
using Cms.Web.ViewModel;
using FluentValidation;

namespace Cms.Web.Validation
{
    public class PoliklinikValidation: AbstractValidator<Policlinic>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} Alanı Boş olamaz";
        public PoliklinikValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Description).NotEmpty().WithMessage(NotEmptyMessage);
        }
    }
}
