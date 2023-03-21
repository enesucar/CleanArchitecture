using Application.Features.Categories.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request);
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
