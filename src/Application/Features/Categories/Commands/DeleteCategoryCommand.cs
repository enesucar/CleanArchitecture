using Application.Common.Exceptions;
using Application.Interfaces.Contexts;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
                if (category == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
