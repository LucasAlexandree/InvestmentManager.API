using FluentValidation;

namespace InvestmentManager.Application.Validators
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("E-mail válido é obrigatório.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
        }
    }

    public class UserRegistrationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
