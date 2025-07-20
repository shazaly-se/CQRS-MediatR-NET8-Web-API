using MediatR;

namespace FirstAPI.MedPatt.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(int Id, string Title, string Author, int PublishedYear) : IRequest<bool>;

    
}
