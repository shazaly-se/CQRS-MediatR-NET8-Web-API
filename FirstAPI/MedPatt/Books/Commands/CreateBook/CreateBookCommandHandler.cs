using FirstAPI.Data;
using FirstAPI.Models;
using MediatR;

namespace FirstAPI.MedPatt.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly ApplicationContext _context;
        public CreateBookCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book() { Title = request.Title, Author = request.Author, PublishedYear = request.PublishedYear };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
    }
}
