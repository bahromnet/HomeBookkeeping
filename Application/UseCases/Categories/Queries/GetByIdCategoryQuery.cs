using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Categories.Queries;
public record GetByIdCategoryQuery : IRequest<CategoryGetDto>
{
    public Guid CategoryId { get; set; }
}
public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
       
    public async Task<CategoryGetDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var findCategory = await _context.Category.FindAsync(new object[] { request.CategoryId });
        if (findCategory is null)
            throw new NotFoundException();
        var resMap = _mapper.Map<CategoryGetDto>(findCategory);
    
        return resMap;
    }
}
