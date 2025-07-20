using MediatR;

namespace FirstAPI.MedPatt.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(int id):IRequest<bool>;
    
}
