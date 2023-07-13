using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Bookkepings.Command
{
    public class UpdateBookkeepingCommand : IRequest<bool>
    {
        public Guid BookkeepingId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class UpdateBookkeepingCommandHandler : IRequestHandler<UpdateBookkeepingCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;


        public UpdateBookkeepingCommandHandler(ICurrentUserService currentUser, IApplicationDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        public async Task<bool> Handle(UpdateBookkeepingCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Bookkeepings
                .FindAsync(new object[] { request.BookkeepingId }, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Bookkeeping), request.BookkeepingId);

            entity.BookkeepingId = request.BookkeepingId;
            entity.Amount = request.Amount;
            entity.Comment = request.Comment;
            entity.CategoryId = request.CategoryId;
            entity.LastModified = DateTime.Now;
            entity.LastModifiedBy = _currentUser.Id;

           

            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
