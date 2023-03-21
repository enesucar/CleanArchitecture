using Application.Common.Exceptions;
using Application.Features.Products.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries
{
    public class GetProductListByCategoryIdQuery : IRequest<List<ProductDto>>
    {
        public Guid CategoryId { get; set; }

        public class GetProductListByCategoryIdQueryHandler : IRequestHandler<GetProductListByCategoryIdQuery, List<ProductDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetProductListByCategoryIdQueryHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(GetProductListByCategoryIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(o => o.CategoryId == request.CategoryId).ToListAsync(cancellationToken);
                return _mapper.Map<List<ProductDto>>(product);
            }
        }
    }
}
