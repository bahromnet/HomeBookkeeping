using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Bookkepings.Queries
{
    public class GetAllBookkeepingQueries : IRequest<List<BookkeepingGetDto>>
    {

    }

    public class GetAllBookkeepingQueriesHandler : IRequestHandler<GetAllBookkeepingQueries, List<BookkeepingGetDto>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBookkeepingQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookkeepingGetDto>> Handle(GetAllBookkeepingQueries request, CancellationToken cancellationToken)
        {
            List<Bookkeeping> res =  await _context.Bookkeepings.ToListAsync(cancellationToken);
            var resMap = _mapper.Map<List<BookkeepingGetDto>>(res);
            return resMap;
        }
       
    }
}
