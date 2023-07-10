using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Bookkepings.Command
{
    public record class DeleteBookkeepingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteBookkeepingCommandHandler : IRequestHandler<DeleteBookkeepingCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteBookkeepingCommandHandler(ICurrentUserService currentUserService, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookkeepingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bookkeepings
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Bookkeeping), request.Id);

            _context.Bookkeepings.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
