using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Categories.Commands;
public record UpdateCategoryCommand : IRequest
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool ExpenceIncomeType { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var findCategory = await _context.Category.FindAsync(new object[] { request.CategoryId });
        if (findCategory == null)
            throw new NotFoundException();

        findCategory.CategoryName = request.CategoryName;
        findCategory.ExpenceIncomeType = request.ExpenceIncomeType;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
