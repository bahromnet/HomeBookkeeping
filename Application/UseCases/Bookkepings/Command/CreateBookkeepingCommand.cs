using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Bookkepings.Command
{
    public record class CreateBookkeepingCommand : IRequest<Guid>
    {
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
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
                BookkeepingId = Guid.NewGuid(),
                Amount = request.Amount,
                Comment = request.Comment,
                CategoryId = request.CategoryId,
                Created =request.CreatedAt,
                CreatedBy = _userService.Id,
            };

            _context.Bookkeepings.Add(entity);
          
            await _context.SaveChangesAsync(cancellationToken);

            return entity.BookkeepingId;
        }
    }

}
