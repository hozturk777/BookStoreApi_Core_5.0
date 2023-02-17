using FluentValidation;

namespace WebApiBookStore.Application.AuthorOperations.Commands.CreateAuthors
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(2);
            RuleFor(commond => commond.Model.DateOfBirth).NotEmpty().GreaterThan(0);
            
        }
    }
}
