using Application.Common.Behaviours.Logging;
using Application.Features.Products.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries
{
    public class GetProductListQuery : IRequest<List<ProductDto>>, ILoggableRequest
    {
        public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetProductListQueryHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.Include(o => o.Category).ToListAsync();
                return _mapper.Map<List<ProductDto>>(products);
            }
        }
    }
}
