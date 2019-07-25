using FluentValidation;
using MuOnlineWebMVC.Models.ViewModels.AccountViewModels;
using System.Linq;

namespace MuOnlineWebMVC.Models.Validation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O login é obrigatório")
                .Length(4, 10).WithMessage("O login deve ter entre {0} e {1} caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .Length(4, 10).WithMessage("A senha deve ter entre {0} e {1} caracteres.");

        }
    }
}
