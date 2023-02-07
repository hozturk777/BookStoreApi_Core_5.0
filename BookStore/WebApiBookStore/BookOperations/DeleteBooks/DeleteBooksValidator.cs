using FluentValidation;

namespace WebApiBookStore.BookOperations.DeleteBooks
{
    public class DeleteBooksValidator : AbstractValidator<DeleteBooksQuery>
    {
        public DeleteBooksValidator()
        {
            RuleFor(commond => commond.BookId).NotNull().WithMessage("Böyle Bir ID YOK");
            
        }
    }
}
