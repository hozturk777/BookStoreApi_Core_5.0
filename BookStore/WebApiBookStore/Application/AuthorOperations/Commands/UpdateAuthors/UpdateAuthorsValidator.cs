using FluentValidation;

namespace WebApiBookStore.Application.AuthorOperations.Commands.UpdateAuthors
{
    public class UpdateAuthorsValidator : AbstractValidator<UpdateAuthorsCommand>
    {
        public UpdateAuthorsValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.SurName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.DateOfBirth).NotEmpty().GreaterThan(0);
        }
    }
}
