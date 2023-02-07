using FluentValidation;

namespace WebApiBookStore.BookOperations.UpdateBooks
{
    public class UpdateBooksValidator : AbstractValidator<UpdateBooksQuery>
    {
        public UpdateBooksValidator()
        {
            RuleFor(common => common.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(common => common.Model.GenreId).GreaterThan(0);
        }
    }
}
