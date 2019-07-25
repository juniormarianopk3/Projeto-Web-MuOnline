using FluentValidation;
using MuOnlineWebMVC.Models.AccountViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Models.Validation
{
    public class RegisterValidator : AbstractValidator<RegisterMembInfoViewModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public RegisterValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.MembId)
                .NotEmpty().WithMessage("O login é obrigatório.")
                .Length(4, 10).WithMessage("O Login deve ter no mínimo {0} caracteres e no máximo {1} caracteres.")
                .Must(CheckUser).WithMessage("Usuário já cadastrado.");

            RuleFor(x => x.MembPwd)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .Length(4, 10).WithMessage("A senha deve ter no mínimo {0} caracteres e no máximo {1} caracteres.");

            RuleFor(x => x.MailAddr)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .Length(10, 50).WithMessage("O email deve ter no mínimo {0} caracteres e no máximo {1} caracteres.")
                .EmailAddress().WithMessage("Digite um endereço de email válido.")
                .Must(CheckEmail).WithMessage("Email já cadastrado.");
                

            
            RuleFor(x => x.SnoNumb)
                .NotEmpty().WithMessage("O personal id é obrigatório.")
                .Length(7, 7).WithMessage("O personal id deve ter no mínimo {0} caracteres e no máximo {1} caracteres.");

            RuleFor(x => x.MembName)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(1, 10).WithMessage("O nome deve ter no mínimo {0} caracteres e no máximo {1} caracteres.");
        }

        private bool CheckEmail(string email)
        {
            var emailChecked = _dbContext.MembInfo.Where(p => p.MailAddr.ToLower() == email.ToLower()).FirstOrDefault();
            return emailChecked ==null;
        }

        private bool CheckUser(string username)
        {
            var userChecked = _dbContext.MembInfo.Where(p => p.MembId == username).FirstOrDefault();
            return userChecked == null;
        }
    }
}
