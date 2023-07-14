using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Categories.Commands;
public record CreateCategoryCommand : IRequest<Guid>
{
    public string CategoryName { get; set; }
    public string ExpenceIncomeType { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context) 
        => _context = context;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new Category
        {
            CategoryName = request.CategoryName,
            ExpenceIncomeType = request.ExpenceIncomeType
        };

        await _context.Category.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return category.CategoryId;
    }
}