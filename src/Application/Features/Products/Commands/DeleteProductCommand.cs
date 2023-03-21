using Application.Common.Exceptions;
using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id, cancellationToken);
                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), request.Id);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
