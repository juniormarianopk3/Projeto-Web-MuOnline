using FluentValidation;
using MuOnlineWebMVC.Models.ViewModels.PainelViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Models.Validation
{
    public class ToChangePasswordValidator : AbstractValidator<ToChangePasswordViewModel>
    {

        public ToChangePasswordValidator()
        {
            RuleFor(x => x.Password)
                .Length(4, 10).WithMessage("A senha tem que ter de 4 a 10 caracteres.")
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .Equal(x => x.ConfirmPassword).WithMessage("Os campos senha e confirmação de senha não conferem.");

            RuleFor(x => x.ConfirmPassword)
                .Length(4, 10).WithMessage("A confirmação da senha tem que ter de 4 a 10 caracteres.")
                .NotEmpty().WithMessage("A confirmação da senha é obrigatória.");
        }
       
    }
}
