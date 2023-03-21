using Application.Features.Categories.Models;
using Application.Interfaces.Contexts;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Queries
{
    public class GetCategoryListQuery : IRequest<List<CategoryDto>>
    {
        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoryListQueryHandler(
                IApplicationDbContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.Categories.ToListAsync();
                return _mapper.Map<List<CategoryDto>>(categories);
            }
        }
    }
}
