using MediatR;

namespace FirstAPI.MedPatt.Books.Commands.CreateBook
{
    public record CreateBookCommand(string Title,string Author,int PublishedYear):IRequest<int>;
}
