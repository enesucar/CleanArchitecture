using Application.Common.Exceptions;
using Application.Features.Categories.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands
{
    public class EditCategoryCommand : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<EditCategoryCommand, CategoryDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
                if (category == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                _mapper.Map(request, category);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
