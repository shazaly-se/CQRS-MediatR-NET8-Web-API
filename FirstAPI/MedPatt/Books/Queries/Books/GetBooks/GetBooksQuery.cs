using FirstAPI.Models;
using MediatR;

namespace FirstAPI.MedPatt.Books.Queries.Books.GetBooks
{
    public record GetBooksQuery:IRequest<List<Book>>;
    
}
