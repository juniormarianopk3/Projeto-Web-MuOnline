using FluentValidation;
using MuOnlineWebMVC.Models.ViewModels.PainelViewModels;

namespace MuOnlineWebMVC.Models.Validation
{
    public class ToChangeEmailValidator : AbstractValidator<ToChangeEmailViewModel>
    {

        public ToChangeEmailValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email não pode ficar em branco")
                .EmailAddress().WithMessage("Digite um email válido.")
                .Length(10, 50).WithMessage("O email tem ter entre {0} e {1} caracteres.");
                
                
            RuleFor(x => x.EmailComparable)
                .NotEmpty().WithMessage("O email não pode ficar em branco")
                .EmailAddress().WithMessage("Digite um email válido.")
                .Length(10, 50).WithMessage("O email tem ter entre {0} e {1} caracteres.");

            RuleFor(x => x.Pid)
                .NotEmpty().WithMessage("O pid não pode ficar em branco")
                .Length(7, 7).WithMessage("O pid tem ter entre {0} e {1} caracteres.");

            RuleFor(x=>x.Email).Equal(x=>x.EmailComparable).WithMessage("Os emails não conferem.");
        }    

       
    }
}
