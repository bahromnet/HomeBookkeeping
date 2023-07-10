using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Bookkepings.Queries
{
    public class GetAllBookkeepingQueries : IRequest<IEnumerable<BookkeepingGetDto>>
    {

    }

    public class GetAllBookkeepingQueriesHandler : IRequestHandler<GetAllBookkeepingQueries, IEnumerable<BookkeepingGetDto>>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetAllBookkeepingQueriesHandler(ICurrentUserService currentUserService, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public Task<IEnumerable<BookkeepingGetDto>> Handle(GetAllBookkeepingQueries request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
