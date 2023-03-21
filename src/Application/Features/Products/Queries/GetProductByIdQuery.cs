using Application.Common.Exceptions;
using Application.Features.Products.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}
