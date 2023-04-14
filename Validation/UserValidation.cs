using Cms.Web.Models;
using Cms.Web.ViewModel;
using FluentValidation;

namespace Cms.Web.Validation
{

    public class UserValidation : AbstractValidator<UserViewModel>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} Alanı Boş olamaz";
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.SurName).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
            RuleFor(request => request.Password)
    .NotEmpty()
    .MinimumLength(8)
    .Matches("[A-Z]").WithMessage("'{PropertyName}' Bir Veya Daha fazla büyük harf içermelidir.")
    .Matches("[a-z]").WithMessage("'{PropertyName}' bir veya daha fazla küçük harf içermelidir.")
    .Matches(@"\d").WithMessage("'{PropertyName}' bir veya daha fazla rakam içermelidir.")
    .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}'bir veya daha fazla özel karakter içermelidir.")
    .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' maşağıdaki karakterleri £ # “” veya boşluk içermemelidir.");
        }
    }
}
