using Application.Common.Exceptions;
using Application.Features.Categories.Commands;
using Application.Features.Categories.Models;
using Application.Features.Products.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class EditProductCommand : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<EditProductCommand, ProductDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(EditProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id, cancellationToken);
                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                _mapper.Map(request, product);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}
