using FirstAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.MedPatt.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly ApplicationContext _context;
        public DeleteBookCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.id }, cancellationToken);
            if(book == null)
                return false;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
