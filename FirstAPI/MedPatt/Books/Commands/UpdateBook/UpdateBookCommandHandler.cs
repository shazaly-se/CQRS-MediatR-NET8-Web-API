using FirstAPI.Data;
using MediatR;

namespace FirstAPI.MedPatt.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly ApplicationContext _context;
        public UpdateBookCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);
            if (book == null)
                return false;
            book.Title = request.Title;
            book.Author= request.Author;
            book.PublishedYear = request.PublishedYear;
            _context.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
