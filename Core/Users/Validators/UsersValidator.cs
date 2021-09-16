using FluentValidation;

namespace Core.Users.Validators

{
    public class UsersValidator : AbstractValidator<Users.Model.Users>
    {
        public static UsersValidator Validate()
        {
            return new UsersValidator();
        }

        public UsersValidator CreateUsersValidator()
        {
            RuleFor(model => model.Usuario)
            .NotEmpty()
            .WithMessage("O usuario é obrigatório");

            RuleFor(model => model.Email)
             .NotEmpty()
             .WithMessage("O Email da pessoa é obrigatório");

            RuleFor(model => model.Senha)
            .NotEmpty()
            .WithMessage("A senha é obrigatoria");

            
            return this;
        }

        public UsersValidator UpdateUsersValidator()
        {
            RuleFor(model => model.Usuario)
              .NotEmpty()
              .WithMessage("O usuario é obrigatório");

            RuleFor(model => model.Email)
             .NotEmpty()
             .WithMessage("O Email da pessoa é obrigatório");

            RuleFor(model => model.Senha)
            .NotEmpty()
            .WithMessage("A senha é obrigatoria");

            return this;
        }
    }
}
