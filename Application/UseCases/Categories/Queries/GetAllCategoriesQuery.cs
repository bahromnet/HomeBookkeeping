using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Categories.Queries;
public record GetAllCategoriesQuery : IRequest<List<CategoryGetDto>>;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllCategoriesQueryHandler(IApplicationDbContext context, IMapper _mapper)
    {
        _context = context;
        _mapper = _mapper;
    }
    
    public async Task<List<CategoryGetDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
         var allCategory =  await _context.Category.AsNoTracking().ToListAsync(cancellationToken);
        var resMap = _mapper.Map<List<CategoryGetDto>>(allCategory);
        return resMap;
    }
}
       
