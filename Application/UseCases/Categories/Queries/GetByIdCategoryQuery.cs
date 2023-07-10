using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Queries;
public record GetByIdCategoryQuery : IRequest<Category>
{
    public Guid CategoryId { get; set; }
}
public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, Category>
{
    private readonly IApplicationDbContext _context;

    public GetByIdCategoryQueryHandler(IApplicationDbContext context)
        => _context = context;

    public async Task<Category> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var findCategory = await _context.Category.FindAsync(new object[] { request.CategoryId });
        if (findCategory is null)
            throw new NotFoundException();

        return findCategory;
    }
}
