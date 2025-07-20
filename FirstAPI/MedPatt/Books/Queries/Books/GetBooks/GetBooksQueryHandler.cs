using FirstAPI.Data;
using FirstAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.MedPatt.Books.Queries.Books.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery,List<Book>>
    {
        private readonly ApplicationContext _context;
        public GetBooksQueryHandler(ApplicationContext context)
        {
            _context= context;
        }
        public async Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books= await _context.Books.ToListAsync(cancellationToken);
            return books;
        }
    }
}
