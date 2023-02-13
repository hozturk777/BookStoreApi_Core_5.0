using FluentValidation;

namespace WebApiBookStore.Application.GenreOperations.Commands.CreateGenres
{
    public class CreateGenresValidator : AbstractValidator<CreateGenresCommand>
    {
        public CreateGenresValidator()
        {
            RuleFor(commond => commond.Model.Name).NotEmpty();
            RuleFor(commond => commond.Model.Name).MinimumLength(2);
        }
    }
}
