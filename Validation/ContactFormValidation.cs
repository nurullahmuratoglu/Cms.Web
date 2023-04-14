using Cms.Web.Models;
using Cms.Web.ViewModel;
using FluentValidation;

namespace Cms.Web.Validation
{
    public class ContactFormValidation: AbstractValidator<ContactForm>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} Alanı Boş olamaz";
        public ContactFormValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Topic).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Message).NotEmpty().WithMessage(NotEmptyMessage);
        }
    }
}
