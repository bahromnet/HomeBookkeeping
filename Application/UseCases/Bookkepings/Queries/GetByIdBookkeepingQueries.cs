using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Bookkepings.Queries
{
    public class GetByIdBookkeepingQueries : IRequest<BookkeepingGetDto>
    {
        public Guid BookkeepingId { get; set; }
    }

    public class GetByIdBookkeepingQueriesHandler : IRequestHandler<GetByIdBookkeepingQueries, BookkeepingGetDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdBookkeepingQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookkeepingGetDto> Handle(GetByIdBookkeepingQueries request, CancellationToken cancellationToken)
        {
            var findBookkepping =await _context.Bookkeepings.FindAsync(new object[] {request.BookkeepingId});
            if (findBookkepping is null)
                throw new NotFoundException();
            var bookkeepMap = _mapper.Map<BookkeepingGetDto>(findBookkepping);
            return bookkeepMap;
        }
    }


}
