using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands;
public record DeleteCategoryCommand : IRequest
{
    public Guid CategoryId { get; set; }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var findCategory = await _context.Category.FindAsync(new object[] { request.CategoryId }, cancellationToken);
        if (findCategory is null)
            throw new NotFoundException
    }
}
