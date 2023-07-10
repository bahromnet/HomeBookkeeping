using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Bookkepings.Command
{
    public record class CreateBookkeepingCommand : IRequest<Guid>
    {
        public Guid BookkeepingId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class CreateBookkeepingCommandHandler : IRequestHandler<CreateBookkeepingCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;

        public CreateBookkeepingCommandHandler(ICurrentUserService userService, IApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<Guid> Handle(CreateBookkeepingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Bookkeeping
            {
                BookkeepingId = new Guid(),
                Amount = request.Amount,
                Comment = request.Comment,
                CategoryId = request.CategoryId,
                Created = DateTime.Now,
                CreatedBy = _userService.Id,
            };

            _context.Bookkeepings.Add(entity);
            if(entity is null)
            {
                throw new NotFoundException(nameof(Bookkepings), entity.BookkeepingId);
            }
            await _context.SaveChangesAsync(cancellationToken);

            return entity.BookkeepingId;
        }
    }

}
