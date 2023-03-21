using Application.Features.Categories.Commands;
using Application.Features.Categories.Models;
using Application.Features.Products.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}
