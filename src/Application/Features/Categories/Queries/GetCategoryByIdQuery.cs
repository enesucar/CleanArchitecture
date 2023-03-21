using Application.Common.Exceptions;
using Application.Features.Categories.Commands;
using Application.Features.Categories.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }

        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
                if (category == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
