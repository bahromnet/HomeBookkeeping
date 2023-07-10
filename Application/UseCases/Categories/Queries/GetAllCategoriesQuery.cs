using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Categories.Queries;
public record GetAllCategoriesQuery : IRequest<List<Category>>;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoriesQueryHandler(IApplicationDbContext context)
        => _context = context;

    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        => await _context.Category.AsNoTracking().ToListAsync(cancellationToken);
}
